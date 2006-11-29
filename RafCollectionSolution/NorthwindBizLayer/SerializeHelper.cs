// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NorthwindBizLayer
{
	/// <summary>
	/// Helper class to test serialization.
	/// Soap serialization is not supported anymore in Fx 2.0
	/// so we use only binary here
	/// </summary>
	public static class SerializeHelper
	{
		public static void Serialize(object o, string FileName)
		{
			IFormatter formatter = new BinaryFormatter();

			using(Stream stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				try
				{
					formatter.Serialize(stream, o);
				}
				catch(SerializationException err)
				{
					Trace.WriteLine(err.ToString());
					throw;
				}
				catch(Exception err)
				{
					Trace.WriteLine(err.ToString());
					throw;
				}
			}
		}


		public static object Deserialize(string FileName)
		{
			IFormatter formatter = new BinaryFormatter();

			using(Stream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				try
				{
					return formatter.Deserialize(stream);
				}
				catch(InvalidCastException err)
				{
					Trace.WriteLine(err.ToString());
				}
				catch(Exception err)
				{
					Trace.WriteLine(err.ToString());
				}
				return null;
			}
		}


	
	}
}

