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
	public partial class RafCollection<T>
	{
		#region IComponent, IDisposable, IServiceProvider
		// 
		private ISite site;
		[NonSerialized]
		private EventHandlerList events;
		private static readonly object EventDisposed = new object();
		public event EventHandler Disposed
		{
			add { this.Events.AddHandler(EventDisposed, value); }
			remove { this.Events.RemoveHandler(EventDisposed, value); }
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual ISite Site
		{
			get { return this.site; }
			set { this.site = value; }
		}

		protected EventHandlerList Events
		{
			get
			{
				if(this.events == null)
					this.events = new EventHandlerList();
				return this.events;
			}
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool DesignMode
		{
			get
			{
				ISite site1 = this.site;
				if(site1 != null)
					return site1.DesignMode;
				return false;
			}
		}

		[Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual IContainer Container
		{
			get
			{
				ISite site1 = this.site;
				if(site1 != null)
					return site1.Container;
				return null;
			}
		}

		//		public override string ToString()
		//		{
		//			ISite site1 = this.site;
		//			if (site1 != null)
		//			{
		//				return (site1.Name + " [" + base.GetType().FullName + "]");
		//			}
		//			return base.GetType().FullName;
		//		}

		public virtual object GetService(Type service)
		{
			if(this.site != null)
			{
				return this.site.GetService(service);
			}
			return null;
		}

		~RafCollection()
		{
			this.Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if(disposing)
			{
				lock(this)
				{
					if((this.site != null) && (this.site.Container != null))
						this.site.Container.Remove(this);
					if(this.events != null)
					{
						EventHandler handler1 = (EventHandler)this.events[EventDisposed];
						if(handler1 == null)
							return;
						handler1(this, EventArgs.Empty);
					}
				}
			}
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion

		#region ICollection<T> Members
		int ICollection<T>.Count
		{
			get { return this.Count; }
		}

		bool ICollection<T>.IsReadOnly
		{
			get { return false; }
		}

		void ICollection<T>.Add(T item)
		{
			this.Add(item);
		}

		void ICollection<T>.Clear()
		{
			this.Clear();
		}

		bool ICollection<T>.Contains(T item)
		{
			return this.Contains(item);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			this.CopyTo(array, arrayIndex);
		}

		bool ICollection<T>.Remove(T item)
		{
			return this.Remove(item);
		}
		#endregion

		#region ICollection
		int ICollection.Count
		{
			get { return this.Count; }
		}
		bool ICollection.IsSynchronized
		{
			get { return false; }
		}
		object ICollection.SyncRoot
		{
			get { return this.SyncRoot; }
		}
		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo((T[])array, index);
		}
		#endregion

		#region IEnumerable<T> Members
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		#endregion

		#region IEnumerable Members
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		#endregion

		#region IList Members
		int IList.Add(object value)
		{
			return this.Add((T)value);
		}

		void IList.Clear()
		{
			this.Clear();
		}

		bool IList.Contains(object value)
		{
			return this.Contains((T)value);
		}

		int IList.IndexOf(object value)
		{
			return this.IndexOf((T)value);
		}

		void IList.Insert(int index, object value)
		{
			this.Insert(index, (T)value);
		}

		bool IList.IsFixedSize
		{
			get { return false; }
		}

		bool IList.IsReadOnly
		{
			get { return false; }
		}

		void IList.Remove(object value)
		{
			this.Remove((T)value);
		}

		void IList.RemoveAt(int index)
		{
			this.RemoveAt(index);
		}

		object IList.this[int index]
		{
			get { return this[index]; }
			set { this[index] = (T)value; }
		}
		#endregion

		#region IList<T> Members
		int IList<T>.IndexOf(T item)
		{
			return this.IndexOf(item);
		}

		void IList<T>.Insert(int index, T item)
		{
			this.Insert(index, item);
		}

		void IList<T>.RemoveAt(int index)
		{
			this.RemoveAt(index);
		}

		T IList<T>.this[int index]
		{
			get { return this[index]; }
			set { this[index] = value; }
		}
		#endregion

		#region IRaiseItemChangedEvents Members
		bool IRaiseItemChangedEvents.RaisesItemChangedEvents
		{
			get { return this.RaisesItemChangedEvents; }
		}
		#endregion

		#region ICancelAddNew Members
		void ICancelAddNew.CancelNew(int itemIndex)
		{
			this.CancelNew(itemIndex);
		}

		void ICancelAddNew.EndNew(int itemIndex)
		{
			this.EndNew(itemIndex);
		}
		#endregion

		#region ITypedList Members
		PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
		{
			Type t = GetPropertyType(listAccessors);
			PropertyDescriptorCollection p = TypeDescriptor.GetProperties(t);
			return p;
		}

		string ITypedList.GetListName(PropertyDescriptor[] listAccessors)
		{
			Type t = GetPropertyType(listAccessors);
			return t.Name;
		}
		protected Type GetPropertyType(PropertyDescriptor[] listAccessors)
		{
			Type t;
			if(listAccessors == null || listAccessors.Length == 0)
			{
				t = typeof(T);
			}
			else
			{
				try
				{
					// this is the case when the collected property is itself a collection
					// so the collection is a member of the collected object
					t = listAccessors[listAccessors.Length - 1].PropertyType;

					// I get the type of this collection looking in its indexer
					// (return type of the get indexer)
					System.Reflection.MemberInfo[] mis = t.GetMember("get_Item");
					t = (mis[0] as System.Reflection.MethodInfo).ReturnType;
				}
				catch(Exception)
				{
					t = typeof(T);
				}
			}
			return t;
		}
		#endregion

		#region IBindingList Members
		object IBindingList.AddNew()
		{
			return this.AddNew();
		}

		bool IBindingList.AllowEdit
		{
			get { return this.AllowEdit; }
		}

		bool IBindingList.AllowNew
		{
			get { return this.AllowNew; }
		}

		bool IBindingList.AllowRemove
		{
			get { return this.AllowRemove; }
		}

		void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
		{
			ListSortDescription[] sorts = new ListSortDescription[1];
			sorts[0] = new ListSortDescription(property, direction);
			ListSortDescriptionCollection lsdc = new ListSortDescriptionCollection(sorts);
			this.ApplySort(lsdc);
		}

		int IBindingList.Find(PropertyDescriptor property, object key)
		{
			return this.Find(property, key);
		}

		bool IBindingList.IsSorted
		{
			get { return this.IsSorted; }
		}

		[field: NonSerialized]
		public event ListChangedEventHandler ListChanged;
		//[NonSerialized]
		//private ListChangedEventHandler _OnListChanged;
		//// se non la esplicito è necessario marcare l'evento con [NonSerialized]
		//public event ListChangedEventHandler ListChanged	// IBindingList.ListChanged
		//{
		//    add { _OnListChanged += value; }
		//    remove { _OnListChanged -= value; }
		//}

		void IBindingList.AddIndex(PropertyDescriptor property)
		{
			this.AddIndex(property);
		}

		void IBindingList.RemoveIndex(PropertyDescriptor property)
		{
			this.RemoveIndex(property);
		}

		void IBindingList.RemoveSort()
		{
			this.RemoveSort();
		}

		ListSortDirection IBindingList.SortDirection
		{
			get { return this.SortDirection; }
		}

		PropertyDescriptor IBindingList.SortProperty
		{
			get { return this.SortProperty; }
		}

		bool IBindingList.SupportsChangeNotification
		{
			get { return this.SupportsChangeNotification; }
		}

		bool IBindingList.SupportsSearching
		{
			get { return this.SupportsSearching; }
		}

		bool IBindingList.SupportsSorting
		{
			get { return this.SupportsSorting; }
		}

		#endregion

		#region IBindingListView Members
		void IBindingListView.ApplySort(ListSortDescriptionCollection sorts)
		{
			this.ApplySort(sorts);
		}

		string IBindingListView.Filter
		{
			get { return this.Filter; }
			set { this.Filter = value; }
		}

		void IBindingListView.RemoveFilter()
		{
			this.Filter = string.Empty;
		}

		ListSortDescriptionCollection IBindingListView.SortDescriptions
		{
			get { return this.SortDescriptions; }
		}

		bool IBindingListView.SupportsAdvancedSorting
		{
			get { return true; }
		}

		bool IBindingListView.SupportsFiltering
		{
			get { return true; }
		}
		#endregion

		#region IChangeTracking Members
		void IChangeTracking.AcceptChanges()
		{
			this.AcceptChanges();
		}

		bool IChangeTracking.IsChanged
		{
			get { return this.HasChanges; }
		}

		#endregion

		#region IRevertibleChangeTracking Members

		void IRevertibleChangeTracking.RejectChanges()
		{
			this.RejectChanges();
		}

		#endregion


	}
}
