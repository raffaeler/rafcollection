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
		/// Gets the count of the visible items in the collection
		/// </summary>
		public int Count
		{
			get
			{
				return _ArrayCount - _InvisibleCount;
			}
		}

		/// <summary>
		/// Gets the total number of items (unfiltered) in the collection
		/// </summary>
		public int UnfilteredCount
		{
			get
			{
				return _ArrayCount;
			}
		}

		/// <summary>
		/// Given the filtered index, it gets back the real one (the one without filters)
		/// For example:
		/// - say there are four elements 
		/// - the third (index 2) is marked as deleted
		/// - the actual filter hides deleted items
		/// If we give index = 2 to this method, we get 3 that is the index without filters
		/// and alseo the last item of the collection 
		/// </summary>
		/// <param name="index">filtered index</param>
		/// <returns>real index</returns>
		private int CalculateRealIndex(int index)
		{
			int j = 0;
			for(int i = 0; i < _ArrayCount; i++)
			{
				Box<T> Elem = BaseArray[i];
				if(!IsVisible(Elem))
					continue;
				if(index == j)
					return i;
				j++;
			}
			return -1;	// should never occur
		}

		/// <summary>
		/// Replace an item with another one
		/// </summary>
		/// <param name="ItemToReplace">Item to replace</param>
		/// <param name="NewItem">New item to insert</param>
		public void Replace(T ItemToReplace, T NewItem)
		{
			// onbefore, onafter events called from the indexer
			int index = this.IndexOf(ItemToReplace);
			this[index] = NewItem;
			// OnListChanged event called from the indexer
			//OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
		}

		/// <summary>
		/// Indexer of the collection
		/// </summary>
		/// <param name="index">Index to get/set</param>
		/// <returns>Item</returns>
		public T this[int index]
		{
			get
			{
				if(index >= _ArrayCount - _InvisibleCount)
					throw new ArgumentOutOfRangeException();

				int RealIndex = CalculateRealIndex(index);
				Box<T> Elem = BaseArray[RealIndex];
				_CurrentStorageElement = Elem;
				return Elem.Storage.CollectedObject;
			}

			set
			{
				if(index >= _ArrayCount - _InvisibleCount)
					throw new ArgumentOutOfRangeException();

				int RealIndex = CalculateRealIndex(index);
				Box<T> Elem = BaseArray[RealIndex];
				Storage<T> Subst = Elem.Storage;
				OnBeforeRemove(Subst);
				OnBeforeAdd(Subst);
				Elem.Storage.CollectedObject = value;
				OnAfterRemove(Subst);
				OnAfterAdd(Subst);
				if(Elem.Storage.Status == ObjectStatusType.Normal)
				{
					Elem.Storage.Status = ObjectStatusType.Modified;
					if(!IsVisible(Elem))
						_InvisibleCount++;
				}
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
			}
		}


		/// <summary>
		/// Get the index of the collection where the Element is
		/// If the collection is filtered, the index is a filtered index
		/// If the item is filtered or is not in the collection it returns -1
		/// </summary>
		/// <param name="item">Element to look for</param>
		/// <returns>-1 if the element is not found or an integer greater equal zero</returns>
		public int IndexOf(T item)
		{
			int j = 0;
			for(int i = 0; i < _ArrayCount; i++)
			{
				Box<T> Elem = BaseArray[i];
				if(!IsVisible(Elem))
					continue;
				if(Elem.Storage.CollectedObject.Equals(item))
				{
					_CurrentStorageElement = Elem;
					return j;
				}
				j++;
			}
			return -1;
		}

		/// <summary>
		/// Get the real index of the collection where the Element is
		/// Even if the collection is filtered, the real element index is 
		/// returned if it is found
		/// -1 as return value is possible only if the element is not part
		/// of the collection
		/// </summary>
		/// <param name="item">Element to look for</param>
		/// <returns>-1 if the element is not found or an integer greater equal zero</returns>
		private int RealIndexOf(T item)
		{
			int j = 0;
			for(int i = 0; i < _ArrayCount; i++)
			{
				Box<T> Elem = BaseArray[i];
				if(Elem.Storage.CollectedObject.Equals(item))
				{
					return j;
				}
				j++;
			}
			return -1;
		}


		/// <summary>
		/// Recalculate the number of elements that are not visible due to the filters
		/// </summary>
		private void CalculateInvisibleCount()
		{
			int i = 0;
			for(int j = 0; j < _ArrayCount; j++)
			{
				Box<T> Elem = BaseArray[j];
				if(IsVisible(Elem))
					continue;
				i++;
			}
			_InvisibleCount = i;
		}

		/// <summary>
		/// Verify if an index is part of the collection
		/// The filter is applied so if the element is filtered false is returned.
		/// </summary>
		/// <param name="item">Item to verify</param>
		/// <returns>True if it's part of the collection</returns>
		public bool Contains(T item)
		{
			return this.IndexOf(item) > -1;
		}

	}
}
