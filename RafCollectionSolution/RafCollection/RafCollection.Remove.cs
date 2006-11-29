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
		/// Remove all the collection elements without changing their state
		/// </summary>
		public void Clear()
		{
			for(int j = 0; j < _ArrayCount; j++)
			{
				Box<T> Elem = BaseArray[j];
				OnBeforeRemove(Elem.Storage);
				OnAfterRemove(Elem.Storage);
			}
			_ArrayCount = 0;

			_CurrentStorageElement = null;
			_InvisibleCount = 0;
			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}


		/// <summary>
		/// Mark the item as deleted
		/// If it was previously marked as deleted, it's removed definitively
		/// </summary>
		/// <param name="item">Item to remove or mark as removed</param>
		/// <returns>true if the Item is found, false if it's not found in the collection</returns>
		public bool Remove(T item)
		{
			int index = IndexOf(item);
			int RealIndex = this.RealIndexOf(item);
			if(RealIndex >= 0)
			{
				Box<T> Element = BaseArray[RealIndex];
				if(!IsVisible(Element))
					return false;
				if(Element.Storage.Status == ObjectStatusType.Added)
				{
					OnBeforeRemove(Element.Storage);
					RemoveAtFinal(RealIndex);
					OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
					OnAfterRemove(Element.Storage);
					return true;
				}
				Element.Storage.Status = ObjectStatusType.Deleted;
				if(!IsVisible(Element))
					_InvisibleCount++;
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
				return true;
			}
			return false;
		}

		/// <summary>
		/// Mark the item at the specified Index as deleted
		/// If it was previously marked as deleted, it's removed definitively
		/// </summary>
		/// <param name="index">index of the element to remove</param>
		public void RemoveAt(int index)
		{
			if(index >= _ArrayCount - _InvisibleCount)
				throw new ArgumentOutOfRangeException();

			int RealIndex = CalculateRealIndex(index);
			Box<T> Element = BaseArray[RealIndex];	// it's visible for sure since Index is the Index of visible items
			if(Element.Storage.Status == ObjectStatusType.Added ||
				Element.Storage.Status == ObjectStatusType.PendingAdded)
			{
				OnBeforeRemove(Element.Storage);
				RemoveAtFinal(RealIndex);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
				OnAfterRemove(Element.Storage);
				return;
			}
			Element.Storage.Status = ObjectStatusType.Deleted;
			// Now that is marked as deleted, it could no more be visible depending on the filter
			if(!IsVisible(Element))
				_InvisibleCount++;
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
			return;
		}

		/// <summary>
		/// Defitively remove an Item found at the specified Index
		/// </summary>
		/// <param name="index">index of the element to remove</param>
		private void RemoveAtFinal(int RealIndex)
		{
			// it's better to call onbeforeremove and onafterremove calls from the caller of this method
			// and not here since we have only the index and not the element
			_ArrayCount--;
			if(RealIndex < _ArrayCount)
			{
				Array.Copy(BaseArray, RealIndex + 1, BaseArray, RealIndex, _ArrayCount - RealIndex);
			}
			BaseArray[_ArrayCount] = default(Box<T>);
			//RecalcFilter();	// not necessary
			CalculateInvisibleCount();	// can be optimized changing only _InvisibleCount depending if the item was visible or not before removal
		}

	}
}
