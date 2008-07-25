// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Vevy.Collections
{
	public partial class RafCollection<T>
	{
		/// <summary>
		/// Every Add overload use this one
		/// </summary>
		/// <param name="Element">Box(T) to add to the collection</param>
		/// <returns>Index of the added item (Count-1)</returns>
		private int Add(Box<T> Element)
		{
			OnBeforeAdd(Element.Storage);
			_CurrentStorageElement = Element;

			if(BaseArray.Length == _ArrayCount)
				GrowArray();
			BaseArray[_ArrayCount] = Element;
			_ArrayCount++;

			RecalcFilter(false);
			if(!IsVisible(Element))
				_InvisibleCount++;
			int NewIndex = _ArrayCount -_InvisibleCount - 1;		// patched "-InvisibleCount" on June 17, 2007
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, NewIndex));

			OnAfterAdd(Element.Storage);
			return NewIndex;
		}

		/// <summary>
		/// Add an element to the collection
		/// </summary>
		/// <param name="Item">Item to add</param>
		/// <returns>Index of the added item (Count-1)</returns>
		public int Add(T Item)
		{
			Box<T> Elem = new Box<T>(new Storage<T>(Item, ObjectStatusType.Added), true);
			return Add(Elem);
		}

		/// <summary>
		/// Add an element to the collection
		/// </summary>
		/// <param name="Item">Item to add</param>
		/// <param name="StatusType">Item state to force for this item</param>
		/// <returns>Index of the added item (Count-1)</returns>
		public int Add(T Item, ObjectStatusType StatusType)
		{
			Box<T> Elem = new Box<T>(new Storage<T>(Item, StatusType), true);
			return Add(Elem);
		}

		/// <summary>
		/// Used to build a new View
		/// The same Storage(T) is added into a new Box object that is mantained from this collection
		/// Storage(T) state is not modified
		/// A new Box is created (see doc)
		/// </summary>
		/// <param name="Item">Item to look for in SourceList</param>
		/// <param name="SourceList">Source list in which to look for the element</param>
		/// <returns>Index of the added item (Count-1)</returns>
		public int Add(T Item, RafCollection<T> SourceList)
		{
			Box<T> Elem = SourceList.GetExternalStorage(Item);
			return Add(new Box<T>(Elem.Storage, Elem.Visible));
		}

		/// <summary>
		/// Create a new element of type T
		/// It's necessary that T has a default constructor (parameterless)
		/// </summary>
		/// <returns>Created item</returns>
		private T CreateT()
		{
			T NewObject = (T)Activator.CreateInstance(typeof(T));
			return NewObject;
		}

		/// <summary>
		/// Start a transaction (see IBindingList.AddNew) that will end with EndNew or CancelNew.
		/// </summary>
		/// <returns>The new element that has PendingAdded state</returns>
		public T AddNew()
		{
			if(!AllowNew)
				throw new NotSupportedException("AllowNew is false");

			// MSDN help in IBindingList.AddNew:
			// If the objects in this list implement the IEditableObject interface, 
			// calling the CancelEdit method should discard an object, 
			// not add it to the list, when the object was created using the AddNew method. 
			// The object should only be added to the list when the IEditableObject.EndEdit 
			// method is called. Therefore, you must sychronize the object and the list carefully.
			//
			// Fortunately we are implementing ICancelAddNew (see msdn) so it's no more neeeded
			// to support the combined scenario AddNew + IEditableObject that would have requested 
			// an event from the entity to the collection to notify the removal of the entity that has
			// a PendingAdded state

			T NewObject = CreateT();
			int NewIndex = this.Add(NewObject, ObjectStatusType.PendingAdded);		// <====
			return NewObject;
		}

		/// <summary>
		/// Cancel the add operation (started with AddNew)
		/// </summary>
		/// <param name="itemIndex">Index to remove</param>
		private void CancelNew(int itemIndex)	// ICancelAddNew
		{
			T Item = this[itemIndex];
			if(GetObjectStatus(Item) == ObjectStatusType.PendingAdded)
			{
				RemoveAt(itemIndex);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, itemIndex));
				//RecalcFilter();
				return;
			}
		}

		/// <summary>
		/// Commit the insertion of last AddNew item
		/// </summary>
		/// <param name="itemIndex">Index of the element to commit</param>
		private void EndNew(int itemIndex)	// ICancelAddNew
		{
			if(itemIndex < 0)
				return;
			T Item = this[itemIndex];
			if(GetObjectStatus(Item) == ObjectStatusType.PendingAdded)
			{
				Box<T> box = GetExternalStorage(Item);
				SetObjectStatus(box, ObjectStatusType.Added);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, itemIndex));
				_CurrentStorageElement = box;
				RecalcFilter(false);
				return;
			}
		}

		/// <summary>
		/// Insert an item into an index of the collection
		/// </summary>
		/// <param name="index">Index in which insert the item</param>
		/// <param name="value">Item to insert</param>
		public void Insert(int index, T value)
		{
			Insert(index, value, ObjectStatusType.Added);
		}

		/// <summary>
		/// TODO: verify a problem: Index is relative to the filter but GetNodeAt has pre-calculated this
		/// TODO: need unit testing
		/// 
		/// Insert an Item at the specified index forcing its state
		/// </summary>
		/// <param name="index">Index to insert the item</param>
		/// <param name="value">Item to insert</param>
		/// <param name="StatusType">State to force for the item</param>
		public void Insert(int index, T value, ObjectStatusType StatusType)
		{
			Storage<T> Store = new Storage<T>(value, StatusType);
			OnBeforeAdd(Store);
			if(index > _ArrayCount - _InvisibleCount)
				throw new ArgumentOutOfRangeException();

			if(BaseArray.Length == _ArrayCount)
				GrowArray();
			// calcolo il vero index
			int RealIndex = CalculateRealIndex(index);
			if(RealIndex == -1)
				RealIndex = Count;
			if(RealIndex < _ArrayCount)
			{
				Array.Copy(BaseArray, RealIndex, BaseArray, RealIndex + 1, _ArrayCount - RealIndex);
			}
			Box<T> Element = new Box<T>(Store, true);
			_CurrentStorageElement = Element;

			BaseArray[RealIndex] = Element;
			_ArrayCount++;
			RecalcFilter(false);
			if(!IsVisible(Element))
				_InvisibleCount++;
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));

			OnAfterAdd(Store);
		}


	}
}
