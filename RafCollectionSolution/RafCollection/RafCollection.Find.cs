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
	partial class RafCollection<T>
	{
		#region Find
		/// <summary>
		/// Collection always support searching.
		/// If there is no specific support, we use a generic inspection via reflection
		/// </summary>
		public bool SupportsSearching
		{
			get { return true; }
		}

		/// <summary>
		/// Find occurs on the Visible items only
		/// Find return the index of the first item where Key value is found 
		/// on a property called PropertyName
		/// </summary>
		/// <param name="property">Name of the property to look for</param>
		/// <param name="key">Value to look for in that property</param>
		/// <returns>Index found or -1</returns>
		public int Find(string PropertyName, object Key)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
			PropertyDescriptor pd = properties.Find(PropertyName, true);
			if(pd == null)
				return -1;
			return Find(pd, Key);
		}

		/// <summary>
		/// Find occurs on the Visible items only
		/// Find return the index of the first item where Key value is found 
		/// on a property
		/// </summary>
		/// <param name="property">PropertyDescriptor of the property to look for</param>
		/// <param name="key">Value to look for in that property</param>
		/// <returns>Index found or -1</returns>
		protected int Find(PropertyDescriptor property, object key)
		{
			foreach(T obj in this)
			{
				object PropValue = property.GetValue(obj);
				if(PropValue == null && key == null) return this.IndexOf(obj);
				if(PropValue == null || key == null) continue;
				if(PropValue is IComparable)
				{
					if(((IComparable)PropValue).CompareTo(key) == 0)
						return this.IndexOf(obj);
				}
			}
			return -1;
		}

		/// <summary>
		/// Wrapper to satisfy IBindingList interface. Not used
		/// </summary>
		/// <param name="property">PropertyDescriptor of the property to use as index</param>
		protected void AddIndex(PropertyDescriptor property)
		{
		}

		/// <summary>
		/// Wrapper to satisfy IBindingList interface. Not used
		/// </summary>
		/// <param name="property">PropertyDescriptor of the property to use as index</param>
		protected void RemoveIndex(PropertyDescriptor property)
		{
		}
		#endregion

	}
}
