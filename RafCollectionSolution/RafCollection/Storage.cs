// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

// Collected objects should:
// - be serializable
// - implement INotifyPropertyChanged (see doc)
// - implement ICloneable
// Events should:
// - be marked as [NonSerialized] or [field:NonSerialized]
// - restored back during deserialization with:
// [OnDeserialized]
// private void OnDeserialized(StreamingContext context) { ... }


using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Vevy.Collections
{
	[Serializable]
	public class Storage<T> : IRevertibleChangeTracking, IChangeTracking, INotifyPropertyChanged
	{
		private ObjectStatusType _Status;
		private T _Clone;
		private T _CollectedObject;

		public ObjectStatusType Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		public T CollectedObject
		{
			get { return _CollectedObject; }
			set { _CollectedObject = value; }
		}

		public Storage(T Object, ObjectStatusType StatusType)
			: this(Object)
		{
			Status = StatusType;
		}

		public Storage(T Object)
		{
			_CollectedObject = Object;
			_Clone = default(T);
			_Status = ObjectStatusType.Normal;
		}

		private void SubscribeEvents(T Item)
		{
			if(Item is INotifyPropertyChanged)
				((INotifyPropertyChanged)Item).PropertyChanged += new PropertyChangedEventHandler(Object_PropertyChanged);

			// this interface has been stripped for performance reasons
			// now we use INotifyPropertyChanged with null parameter
			//if(Item is INotifyPropertyChanging)
			//    ((INotifyPropertyChanging)Item).PropertyChanging += new PropertyChangingEventHandler(Object_PropertyChanging);
		}

		private void UnsubscribeEvents(T Item)
		{
			if(Item is INotifyPropertyChanged)
				((INotifyPropertyChanged)Item).PropertyChanged -= new PropertyChangedEventHandler(Object_PropertyChanged);

			// this interface has been stripped for performance reasons
			// now we use INotifyPropertyChanged with null parameter
			//if(Item is INotifyPropertyChanging)
			//    ((INotifyPropertyChanging)Item).PropertyChanging -= new PropertyChangingEventHandler(Object_PropertyChanging);
		}

		private void Object_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if(e.PropertyName == null)	// property is going to change
				SaveClone(false);
			else
				OnPropertyChanged(sender, e);	// property is changed
		}

		/// <summary>
		/// Makes a copy of the object
		/// 1. If object implement INotifyPropertyChanged (with a null parameter)
		/// 2. if the object don't implement INotifyPropertyChanged with null paramter trick (see doc)
		///    they will be preemptively copied during Add or AcceptChanges in the collection.
		///	   This is a slow and memory expensive operation
		/// </summary>
		public void SaveClone(bool bForce)
		{
			if(!bForce && _Clone != null)
				return;
			if(Storage<T>.CollectedObjectImplementICloneable)
			{
				ICloneable obj = (ICloneable)CollectedObject;
				_Clone = (T)obj.Clone();
			}
			else
			{
				_Clone = (T)EntityHelper.SerializeClone(_CollectedObject);
			}
			SubscribeEvents(_Clone);
		}

		public void AcceptChanges()
		{
			_Status = ObjectStatusType.Normal;
			if(_CollectedObject is INotifyPropertyChanged)	// INotifyPropertyChanging
				_Clone = default(T);
			else
				SaveClone(true);
		}

		public void RejectChanges()
		{
			if(_CollectedObject is IEditableObject)
				((IEditableObject)_CollectedObject).CancelEdit();
			if(object.Equals(_Clone, default(T)))
				return;
			_CollectedObject = _Clone;
			if(_CollectedObject is INotifyPropertyChanged)	// INotifyPropertyChanging
				_Clone = default(T);
			else
				SaveClone(true);
			_Status = ObjectStatusType.Normal;
			_PropertyChanged(this, new PropertyChangedEventArgs(""));
		}

		public bool IsChanged
		{
			get
			{
				return _Status != ObjectStatusType.Normal;
			}
		}

		public override string ToString()
		{
			return _CollectedObject.ToString();
		}

		#region Static properties to know if T implements some interfaces
		public static bool CollectedObjectImplementINotifyPropertyChanged
		{
			get
			{
				return CollectionUtilities.TypeImplementInterface(typeof(T), "INotifyPropertyChanged");
			}
		}

		/// <summary>
		/// Maybe used in the future
		/// </summary>
		public static bool CollectedObjectImplementINotifyPropertyChanging
		{
			get
			{
				return CollectionUtilities.TypeImplementInterface(typeof(T), "INotifyPropertyChanging");
			}
		}

		public static bool CollectedObjectImplementICloneable
		{
			get
			{
				return CollectionUtilities.TypeImplementInterface(typeof(T), "ICloneable");
			}
		}
		#endregion

		#region INotifyPropertyChanged Members
		[NonSerialized]
		private PropertyChangedEventHandler _PropertyChanged;
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				SubscribeEvents(_CollectedObject);
				_PropertyChanged += value;
			}
			remove
			{
				_PropertyChanged -= value;
				UnsubscribeEvents(_CollectedObject);
			}
		}

		private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if(_PropertyChanged != null)
			{
				if(_Status == ObjectStatusType.Normal)
					_Status = ObjectStatusType.Modified;
				_PropertyChanged(this, e);
			}
		}
		#endregion

		#region IRevertibleChangeTracking Members
		void IRevertibleChangeTracking.RejectChanges()
		{
			this.RejectChanges();
		}
		#endregion

		#region IChangeTracking Members
		void IChangeTracking.AcceptChanges()
		{
			this.AcceptChanges();
		}

		bool IChangeTracking.IsChanged
		{
			get { return this.IsChanged; }
		}
		#endregion

	}

}