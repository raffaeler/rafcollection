// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Vevy.Collections
{
	public partial class RafCollection<T>
	{
		/// <summary>
		/// Event that occurs before serializing
		/// </summary>
		/// <param name="context"></param>
		[OnSerializing]
		protected void OnBeforeSerialize(StreamingContext context)
		{
		}

		/// <summary>
		/// Before deserializing I should restore all the INotifyPropertyChanged events
		/// TODO: maybe it's better to merge delegates in order to avoid duplicate subscriptions
		/// </summary>
		/// <param name="context"></param>
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			for(int i = 0; i < _ArrayCount; i++)
			{
				Box<T> Elem = BaseArray[i];
				if(Elem.Storage.CollectedObject is INotifyPropertyChanged)
				{
					Elem.Storage.PropertyChanged += _PropertyChangedEventHandler;
				}
			}
		}


		#region Notifiche di add / remove
		/// <summary>
		/// Virtual function called before adding an item to the collection
		/// </summary>
		protected virtual void OnBeforeAdd(Storage<T> Item)
		{
			if(Item.CollectedObject is INotifyPropertyChanged)
			{
				Item.PropertyChanged += _PropertyChangedEventHandler;
			}
			else
			{
				Item.SaveClone(true);
			}

            ////if(RafCollection<T>.CollectedObjectImplementInterface("INotifyPropertyChanged"))
			//if(Item.CollectedObject is INotifyPropertyChanged)
			//{
			//	Item.PropertyChanged += _PropertyChangedEventHandler;
			//}
		}

		/// <summary>
		/// Virtual function called after item insertion
		/// </summary>
		protected virtual void OnAfterAdd(Storage<T> Item)
		{
		}

		/// <summary>
		/// Virtual function called before removing an item
		/// </summary>
		protected virtual void OnBeforeRemove(Storage<T> Item)
		{
			if(Item.CollectedObject is INotifyPropertyChanged)
			{
				Item.PropertyChanged -= _PropertyChangedEventHandler;
			}
			else
			{
				//Item.AcceptChanges();
			}

            ////if(RafCollection<T>.CollectedObjectImplementInterface("INotifyPropertyChanged"))
			//if(Item.CollectedObject is INotifyPropertyChanged)
			//{
			//    Item.PropertyChanged -= _PropertyChangedEventHandler;
			//}
		}

		/// <summary>
		/// Virtual function called after the removal of an item
		/// </summary>
		protected virtual void OnAfterRemove(Storage<T> Item)
		{
		}
		#endregion


		/// <summary>
		/// If T implements INotifyProperyChanged, then it's possible to receive notifications from the collection
		/// </summary>
		private bool RaisesItemChangedEvents
		{
			get { return RafCollection<T>.CollectedObjectImplementInterface("INotifyPropertyChanged"); }
		}

		/// <summary>
		/// If T implements INotifyProperyChanged, then it's possible to receive notifications from the collection
		/// </summary>
		private bool SupportsChangeNotification
		{
			get { return RafCollection<T>.CollectedObjectImplementInterface("INotifyPropertyChanged"); }
		}

		/// <summary>
		/// Wrapper for the OnListChanged event that is called from the list to
		/// inform the control that a specific Item has changed/inserted/deleted
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnListChanged(ListChangedEventArgs e)
		{
			if(ListChanged != null)
				ListChanged(this, e);
		}

		/// <summary>
		/// Handler that receives Storage(T) notifications if a T property has changed
		/// </summary>
		/// <param name="sender">An object of type T</param>
		/// <param name="e">Name of the property that has changed</param>
		private void CollectedItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if(!(sender is Storage<T>))
				return;
			Storage<T> Item = (Storage<T>)sender;
			string PropertyName = e.PropertyName;
			ObjectStatusType StatusType = Item.Status;
			// Its state has been modified in Storage(T) inside OnPropertyChanged method

			int index = this.IndexOf(Item.CollectedObject);
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
		}


	}
}
