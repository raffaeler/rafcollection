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
		/// Returns true if at least one of the elements has changed after last AcceptChanges
		/// </summary>
		public bool HasChanges
		{
			get
			{
				int i = 0;
				for(int j = 0; j < _ArrayCount; j++)
				{
					Box<T> Elem = BaseArray[j];
					if(!HasChangesElement(Elem.Storage))
						continue;
					i++;
					return true;
				}
				//return i;
				return false;
			}
		}

		/// <summary>
		/// Check HasChanges on a specific Item
		/// </summary>
		/// <param name="Item">Item to read the state from</param>
		/// <returns>true it it's changed, that is different from Normal state</returns>
		private bool HasChangesElement(Storage<T> Item)
		{
			return Item.Status != ObjectStatusType.Normal;
		}

		/// <summary>
		/// Commit any changes on all the elements
		/// </summary>
		public void AcceptChanges()
		{
			// iterate in the inverse order so that I can make definitive deletions
			for(int j = _ArrayCount-1; j>=0  ; j--)
			{
				Box<T> Elem = BaseArray[j];
				AcceptChanges(Elem);
			}
			//RecalcFilter();	// not necessary!
			CalculateInvisibleCount();
		}

		/// <summary>
		/// Commit the changes of a specific element
		/// </summary>
		/// <param name="Elem">Element to commit</param>
		private void AcceptChanges(Box<T> Elem)
		{
			// definitive removal?
			if(Elem.Storage.Status == ObjectStatusType.Deleted)
			{
				OnBeforeRemove(Elem.Storage);
				RemoveAtFinal(RealIndexOf(Elem.Storage.CollectedObject));
				OnAfterRemove(Elem.Storage);
				return;
			}
			// all the others become Normal
			Elem.Storage.AcceptChanges();
		}

		/// <summary>
		/// Rollback of the changes on all the elements
		/// </summary>
		public void RejectChanges()
		{
			// now we support pre-cloning of the elements when NotifyPropertyChanged
			// with null string trick is not implemented (see doc)
			//if(!Storage<T>.CollectedObjectImplementINotifyPropertyChanging ||
			//    !Storage<T>.CollectedObjectImplementICloneable)
			//    throw new NotSupportedException("Object should implement INotifyPropertyChanging and ICloneable to be able to reject changes");

			List<Box<T>> ToDelete = new List<Box<T>>();
			for(int j = 0; j < _ArrayCount; j++)
			{
				Box<T> Elem = BaseArray[j];
				if(!RejectChanges(Elem))
					ToDelete.Add(Elem);
			}

			foreach(Box<T> Elem in ToDelete)
			{
				int RealIndex = this.RealIndexOf(Elem.Storage.CollectedObject);
				OnBeforeRemove(Elem.Storage);
				RemoveAtFinal(RealIndex);
				OnAfterRemove(Elem.Storage);
			}

			CalculateInvisibleCount();
			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}

		/// <summary>
		/// Rollback a spefici item changes
		/// </summary>
		/// <param name="Elem">Element to rollback</param>
		/// <returns>false if the item should be removed from the collection</returns>
		private bool RejectChanges(Box<T> Elem)
		{
			if(Elem.Storage.Status == ObjectStatusType.Added || Elem.Storage.Status == ObjectStatusType.PendingAdded)
				return false;	// this item should be deleted from the collection

			if(Elem.Storage.Status != ObjectStatusType.Normal)
				Elem.Storage.RejectChanges();
			return true;
		}

	}
}
