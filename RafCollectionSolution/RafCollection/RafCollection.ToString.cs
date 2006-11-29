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
		#region ToString()
		/// <summary>
		/// Given some properties (Properties) of an object (obj)
		/// this method returns the dump of the values of the given properties
		/// The ToString overloads helps diagnosing collection content and is
		/// particularly useful inside VS.NET debugger
		/// </summary>
		/// <param name="Properties">Property or Property1, Property2</param>
		/// <param name="obj">object to dump</param>
		/// <param name="Postfix">string to append before ")"</param>
		/// <returns>PropertyValue or (PropertyValue1, PropertyValue2, ...)</returns>
		private string GetValuesForProperties(string Properties, T obj, string Postfix)
		{
			if(Properties == null)
				return obj.ToString();
			if(Properties.Trim().Length == 0 && Postfix.Length == 0)
				return obj.ToString();

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			try
			{
				string[] Props = Properties.Split(',');
				if(Props.Length > 1)
					sb.Append("(");
				if(Props[0].Length != 0)
				{
					PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(obj);
					for(int i = 0; i < Props.Length; i++)
					{
						string Prop = Props[i].Trim();
						PropertyDescriptor pd = pdc.Find(Prop, true);
						if(pd == null)
							sb.AppendFormat("{0}=[Invalid Property]", Prop);
						else
						{
							object PropValue = pd.GetValue(obj);
							sb.AppendFormat("{0}={1}", Prop, PropValue);
						}
						if(i != Props.Length - 1)
							sb.Append(", ");
					}
				}
				if(Postfix.Length != 0)
				{
					if(Props[0].Length != 0)
						sb.Append(" ");
					sb.AppendFormat("[{0}]", Postfix);
				}
				if(Props.Length > 1)
					sb.Append(")");
			}
			catch(Exception Err)
			{
				System.Diagnostics.Debug.WriteLine(Err.ToString());
				string str = sb.ToString();
				if(str.EndsWith(")"))
					return str;
				else
					return str + ")";
			}
			return sb.ToString();
		}


		/// <summary>
		/// Dump the collection content with a maximum of 15 elements
		/// Properties is a comma separated values of properties to dump
		/// </summary>
		/// <param name="Properties">Comma separated values of properties to dump</param>
		/// <returns>Formatted dump string</returns>
		public string ToString(string Properties)
		{
			return ToString(Properties, false, 15);
		}

		/// <summary>
		/// Dump the collection content with a maximum of 15 elements
		/// </summary>
		/// <param name="DumpState">true to dump object state (inserted/updated/...)</param>
		/// <returns>Formatted dump string</returns>
		public string ToString(bool DumpState)
		{
			return ToString(string.Empty, DumpState, 15);
		}

		/// <summary>
		/// Dump the collection
		/// </summary>
		/// <param name="Properties">Comma separated values of properties to dump</param>
		/// <param name="DumpState">true to dump object state (inserted/updated/...)</param>
		/// <returns>Formatted dump string</returns>
		public string ToString(string Properties, bool DumpState)
		{
			return ToString(Properties, DumpState, 15);
		}

		/// <summary>
		/// Dump the collection content
		/// Properties is a comma separated values of properties to dump
		/// </summary>
		/// <param name="Properties">Comma separated values of properties to dump</param>
		/// <param name="DumpState">true to dump object state (inserted/updated/...)</param>
		/// <param name="MaxObjects">maximum number of object to dump in the string, or -1 to print them all</param>
		/// <returns>Formatted dump string</returns>
		public string ToString(string Properties, bool DumpState, int MaxObjects)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append("{");
			if(Properties == null || Properties.Length == 0)
				sb.AppendFormat("Count={0}", this.Count);
			bool bFirstElement = true;
			for(int i = 0; i < _ArrayCount; i++)
			{
				Box<T> Elem = BaseArray[i];
				if(!IsVisible(Elem))
					continue;

				if(bFirstElement)
				{
					if(Properties == null || Properties.Length == 0)
						sb.Append(": ");
					bFirstElement = false;
					sb.AppendFormat("{0}", GetValuesForProperties(Properties, Elem.Storage.CollectedObject, DumpState ? MapStateSymbol(Elem.Storage.Status) : string.Empty));
				}
				else
				{
					sb.AppendFormat(", {0}", GetValuesForProperties(Properties, Elem.Storage.CollectedObject, DumpState ? MapStateSymbol(Elem.Storage.Status) : string.Empty));
				}
				if(MaxObjects != -1 && i == MaxObjects)
				{
					sb.AppendFormat(", ...");
					break;
				}
			}
			sb.Append("}");
			return sb.ToString();
		}

		/// <summary>
		/// Dump the collection content with a maximum of 15 elements
		/// </summary>
		/// <returns>Formatted dump string</returns>
		public override string ToString()
		{
			return ToString(string.Empty);
		}

		/// <summary>
		/// Return a symbol to represent the state of the object
		/// Used by the ToString() methods of this collection<para/>
		/// Normal       = <para/>
		/// Added        + <para/>
		/// Deleted      X <para/>
		/// Modified     U <para/>
		/// PendingAdded P <para/>
		/// </summary>
		/// <param name="StatusType">State to obtain the corresponding symbol</param>
		/// <returns>The symbol representing the given state</returns>
		private string MapStateSymbol(ObjectStatusType StatusType)
		{
			switch(StatusType)
			{
				case ObjectStatusType.Normal:
					return "=";
				case ObjectStatusType.Added:
					return "+";
				case ObjectStatusType.Deleted:
					return "X";
				case ObjectStatusType.Modified:
					return "U";
				case ObjectStatusType.PendingAdded:
					return "P";
			}
			return "?";
		}
		#endregion
	}
}
