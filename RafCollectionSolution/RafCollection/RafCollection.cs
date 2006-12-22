// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

namespace Vevy.Collections
{
	/// <summary>
	/// Collection main class
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	public partial class RafCollection<T> :
		IComponent, IDisposable, IServiceProvider,	// equivalent to MarshalByValueComponent
		ICollection, ICollection<T>,
		IEnumerable, IEnumerable<T>,
		IList, IList<T>,
		IRaiseItemChangedEvents,
		ICancelAddNew,
		ITypedList,
		IBindingList, IBindingListView,
		IRevertibleChangeTracking, IChangeTracking
	{
		private Box<T>[] BaseArray;
		private int _ArrayCount;	// effective count of the elements, regardless any filter. Array will be almost ever larger.
		[NonSerialized]
		private object _syncRoot;

		#region Stato della collection
		private ObjectStateFilter _StateFilter;
		private string _Filter;
		private CustomChoiceDelegate<T> _CustomFilter;
		private int _InvisibleCount;

		// every time I return T, I mantain Storage<T> cached here for performance reasons.
		[NonSerialized]
		private Box<T> _CurrentStorageElement;

		// TODO: mantain a string instead of this since ListSortDescriptionCollection is not serializable
		[NonSerialized]
		private ListSortDescriptionCollection _SortDescriptions;

		private bool _IsSorted;
		private bool _AllowNew;
		private bool _AllowEdit;
		private bool _AllowRemove;

		[NonSerialized]
		PropertyChangedEventHandler _PropertyChangedEventHandler;
		#endregion

		/// <summary>
		/// Collection constructor
		/// </summary>
		public RafCollection()
		{
			_StateFilter = ObjectStateFilter.Current;
			_Filter = string.Empty;
			_InvisibleCount = 0;
			_CurrentStorageElement = null;

			_AllowNew = this.ItemTypeHasDefaultConstructor;
			_AllowEdit = true;
			_AllowRemove = true;
			_IsSorted = false;

			_SortDescriptions = null;
			CreateArray();

			// I create the event handler only once here
			_PropertyChangedEventHandler = new PropertyChangedEventHandler(CollectedItem_PropertyChanged);
		}


		#region internal array handling methods

		/// <summary>
		/// Create the initial array (1K)
		/// </summary>
		private void CreateArray()
		{
			BaseArray = new Box<T>[1024];
			_ArrayCount = 0;
		}

		/// <summary>
		/// Calculate the new array size
		/// (used when I have to add more items than the array capacity)
		/// </summary>
		private int NewArraySize
		{
			get
			{
				return BaseArray.Length + BaseArray.Length * 30 / 100 + 10;
			}
		}

		/// <summary>
		/// Expand array size
		/// </summary>
		private void GrowArray()
		{
			Box<T>[] NewArray = new Box<T>[NewArraySize];
			if(_ArrayCount > 0)
				Array.Copy(BaseArray, NewArray, _ArrayCount);
			BaseArray = NewArray;
		}
		#endregion


		#region Extra utility
		/// <summary>
		/// Verify if T has a default (parameterless) constructor
		/// If not, we cannot handle IBindingList.AddNew method
		/// </summary>
		private bool ItemTypeHasDefaultConstructor
		{
			get
			{
				Type t = typeof(T);
				if(t.IsPrimitive)
					return true;
				if(t.GetConstructor(
					System.Reflection.BindingFlags.CreateInstance |
					System.Reflection.BindingFlags.Public |
					System.Reflection.BindingFlags.Instance, null, new Type[0], null) != null)
					return true;
				return false;
			}
		}
		#endregion

		#region Methods/Properties that don't modify collected object state
		/// <summary>
		/// Set a filter on the collection based on the element's state
		/// </summary>
		public ObjectStateFilter StateFilter
		{
			get { return _StateFilter; }
			set
			{
				_StateFilter = value;
				CalculateInvisibleCount();
			}
		}

		/// <summary>
		/// Verify if an item is filtered with a particular ObjectStateFilter
		/// PendingAdded items are always visible
		/// </summary>
		/// <param name="Item">Item to verify</param>
		/// <param name="Filter">State to verify against the item</param>
		/// <returns>true/false</returns>
		private bool IsVisible(Box<T> Item, ObjectStateFilter Filter)
		{
			if(Item.Storage.Status == ObjectStatusType.PendingAdded)
				return true;
			bool bMaskedVisible = ((int)Item.Storage.Status & (int)Filter) > 0;
			if(bMaskedVisible)
			{
				if(Item.Visible)
					return true;
			}
			return false;
		}

		/// <summary>
		/// Verify if an item is filtered with the current filter
		/// </summary>
		/// <param name="Item"></param>
		/// <returns></returns>
		private bool IsVisible(Box<T> Item)
		{
			return IsVisible(Item, StateFilter);
		}

		/// <summary>
		/// Get the Storage(T) instance, given an instance of T
		/// Any applied filter is ignored and should evaluated from the caller
		/// </summary>
		/// <param name="Item">The object whose container we are looking for</param>
		/// <returns>The container</returns>
		internal Storage<T> GetInternalStorage(T Item)
		{
			if(Item.Equals(_CurrentStorageElement.Storage.CollectedObject))
				return _CurrentStorageElement.Storage;
			for(int i = 0; i < _ArrayCount; i++)
			{
				Box<T> Elem = BaseArray[i];
				if(Item.Equals(Elem.Storage.CollectedObject))
					return Elem.Storage;
			}
			return null;
		}

		/// <summary>
		/// Get the Box(Storage(T)) instance, given an instance of T
		/// Any applied filter is ignored and should evaluated from the caller
		/// </summary>
		/// <param name="Item">The object whose container we are looking for</param>
		/// <returns>The container</returns>
		internal Box<T> GetExternalStorage(T Item)
		{
			if(Item.Equals(_CurrentStorageElement.Storage.CollectedObject))
				return _CurrentStorageElement;
			for(int i = 0; i < _ArrayCount; i++)
			{
				Box<T> Elem = BaseArray[i];
				if(Item.Equals(Elem.Storage.CollectedObject))
					return Elem;
			}
			return null;
		}

		/// <summary>
		/// Change forcibly the state of an Item
		/// </summary>
		/// <param name="Item">Item to set</param>
		/// <param name="StatusType">State to force</param>
		public void SetObjectStatus(T Item, ObjectStatusType StatusType)
		{
			if(!Item.Equals(this._CurrentStorageElement.Storage.CollectedObject))
				_CurrentStorageElement = this.GetExternalStorage(Item);
			_CurrentStorageElement.Storage.Status = StatusType;
			if(!IsVisible(_CurrentStorageElement))
				_InvisibleCount++;
		}

		/// <summary>
		/// Change forcibly the state of an Item
		/// </summary>
		/// <param name="Item">Item to set</param>
		/// <param name="StatusType">State to force</param>
		protected void SetObjectStatus(Box<T> Item, ObjectStatusType StatusType)
		{
			if(!Item.Equals(this._CurrentStorageElement))
				_CurrentStorageElement = Item;
			_CurrentStorageElement.Storage.Status = StatusType;
			if(!IsVisible(_CurrentStorageElement))
				_InvisibleCount++;
		}

		/// <summary>
		/// Get the state of an Item
		/// </summary>
		/// <param name="Item">Item to get the state for</param>
		/// <returns>State of the item</returns>
		public ObjectStatusType GetObjectStatus(T Item)
		{
			if(!Item.Equals(this._CurrentStorageElement.Storage.CollectedObject))
				_CurrentStorageElement = this.GetExternalStorage(Item);
			return _CurrentStorageElement.Storage.Status;
		}

		/// <summary>
		/// TODO: unit testing needed here
		/// Copy in an array items of type T
		/// </summary>
		/// <param name="array">Array in which to copy the elements</param>
		/// <param name="arrayIndex">Array index to start the copy</param>
		public void CopyTo(T[] array, int arrayIndex)
		{
			if(array == null)
				throw new ArgumentNullException();

			for(int i = 0; i < _ArrayCount; i++)
			{
				Box<T> Elem = BaseArray[i];
				if(!IsVisible(Elem))
					continue;
				array[arrayIndex + i] = Elem.Storage.CollectedObject;
			}
		}


		/// <summary>
		/// SyncRoot used for synchronization (multithreading stuff)
		/// </summary>
		public object SyncRoot
		{
			get
			{
				if(this._syncRoot == null)
					System.Threading.Interlocked.CompareExchange(ref this._syncRoot, new object(), null);
				return this._syncRoot;
			}
		}

		/// <summary>
		/// GetEmumerator implementation
		/// </summary>
		/// <returns>IEnumerator(T)</returns>
		public IEnumerator<T> GetEnumerator()
		{
			for(int i = 0; i < _ArrayCount; i++)
			{
				Box<T> Elem = BaseArray[i];
				if(!IsVisible(Elem))
					continue;
				_CurrentStorageElement = Elem;
				yield return Elem.Storage.CollectedObject;
			}
		}

		/// <summary>
		/// AllowNew property
		/// </summary>
		public bool AllowNew
		{
			get { return this._AllowNew; }
			set
			{
				if(this.ItemTypeHasDefaultConstructor)
					_AllowNew = value;
			}
		}

		/// <summary>
		/// AllowEdit property
		/// </summary>
		public bool AllowEdit
		{
			get { return this._AllowEdit; }
			set { _AllowEdit = value; }
		}

		/// <summary>
		/// AllowRemove property
		/// </summary>
		public bool AllowRemove
		{
			get { return this._AllowRemove; }
			set { _AllowRemove = value; }
		}

		#endregion



	}


}

