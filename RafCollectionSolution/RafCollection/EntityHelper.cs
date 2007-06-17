// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

using System;
using System.Collections.Generic;
using System.Text;

#if !PocketPC
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
#endif
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace Vevy.Collections
{
	public static class EntityHelper
	{

		/// <summary>
		/// Makes a deep copy of a serializable object
		/// Cloning in this way is very slow but avoid the need to implement ICloneable interface
		/// Furthermore typically (from a collection perspective) it's more useful a shallow copy
		/// than a deep copy and this is another reason for poor performances using this method.
		/// </summary>
		/// <param name="o">object to clone</param>
		/// <returns>cloned object</returns>
		public static object SerializeClone(object o)
		{
#if PocketPC
			return ReflectionClone(o);
#else
			IFormatter formatter = new BinaryFormatter();
			using(Stream stream = new MemoryStream())
			{
				try
				{
					formatter.Serialize(stream, o);
					stream.Seek(0, SeekOrigin.Begin);
					return formatter.Deserialize(stream);
				}
				catch(SerializationException err)
				{
					Debug.WriteLine(err.ToString());
					throw;
				}
				catch(Exception err)
				{
					Debug.WriteLine(err.ToString());
					throw;
				}
			}
#endif
		}

		/// <summary>
		/// Makes a shallow copy of an object by copying all the get properties
		/// of the source object to the set properties of the target object
		/// 
		/// As a general purpose method, not all the object can be cloned this way.
		/// If getter and setter are 'asymmetric' this system doesn't work
		/// </summary>
		/// <param name="o">object to clone</param>
		/// <returns>cloned object</returns>
		public static object ReflectionClone(object o)
		{
			if(o == null)
				throw new ArgumentNullException();
			PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(o);
			object NewObject = Activator.CreateInstance(o.GetType());
			foreach(PropertyDescriptor pd in pdc)
			{
				if(pd.ShouldSerializeValue(o) && !pd.IsReadOnly)
				{
					try
					{
						object val = pd.GetValue(o);
						pd.SetValue(NewObject, val);
					}
					catch(Exception)
					{
						Debug.WriteLine("ReflectionClone property failure on " + pd.Name);
					}
				}
			}
			return NewObject;
		}


		#region IEditableObject Helpers
		/// <summary>
		/// Helper method for entities that need a quick implementation of BeginEdit
		/// </summary>
		/// <param name="sender">Entity itself</param>
		/// <param name="Clone">An object reference used to store the clone</param>
		public static void BeginEdit(object sender, ref object Clone)
		{
			Clone = SerializeClone(sender);
		}

		/// <summary>
		/// Helper method for entities that need a quick implementation of CancelEdit
		/// </summary>
		/// <param name="sender">Entity itself</param>
		/// <param name="Clone">An object reference used to store the clone</param>
		public static void CancelEdit(object sender, ref object Clone)
		{
			if(Clone == null)
				return;
			PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(sender);
			foreach(PropertyDescriptor pd in pdc)
			{
				if(pd.ShouldSerializeValue(sender) && !pd.IsReadOnly)
				{
					try
					{
						object val = pd.GetValue(Clone);
						pd.SetValue(sender, val);
					}
					catch(Exception)
					{
						Debug.WriteLine("CancelEdit Clone property failure on " + pd.Name);
					}
				}
			}
			Clone = null;
		}

		/// <summary>
		/// Helper method for entities that need a quick implementation of EndEdit
		/// </summary>
		/// <param name="sender">Entity itself</param>
		/// <param name="Clone">An object reference used to store the clone</param>
		public static void EndEdit(object sender, ref object Clone)
		{
			Clone = null;
		}
		#endregion



	}
}
