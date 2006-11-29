// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Vevy.DBHelper
{
	public class FieldDictionary : Dictionary<string, int>
	{
		public FieldDictionary()
			: base()
		{
		}

		public FieldDictionary(int Capacity)
			: base(Capacity)
		{
		}

	}

	public class Values
	{
		static bool ReconvertDecimals = false;

		#region Funzioni di mapping per il DBNull
		public static DateTime GetDateTime(IDataReader dr, FieldDictionary Fields, string FieldName)
		{
			return GetDateTime(dr, Fields, FieldName, DateTime.MinValue);
		}
		public static DateTime GetDateTime(IDataReader dr, FieldDictionary Fields, string FieldName, DateTime NullValue)
		{
			if(Fields.ContainsKey(FieldName))
				return GetDateTime(dr, Fields[FieldName], NullValue);
			else
				return NullValue;
		}
		public static DateTime GetDateTime(IDataReader dr, int Index)
		{
			return GetDateTime(dr, Index, DateTime.MinValue);
		}
		public static DateTime GetDateTime(IDataReader dr, int Index, DateTime NullValue)
		{
			object o = dr[Index];
			if(!(o is DateTime)) return NullValue;
			return (DateTime)o;
		}


		public static Decimal GetDecimal(IDataReader dr, FieldDictionary Fields, string FieldName)
		{
			return GetDecimal(dr, Fields, FieldName, 0);
		}
		public static Decimal GetDecimal(IDataReader dr, FieldDictionary Fields, string FieldName, Decimal NullValue)
		{
			if(Fields.ContainsKey(FieldName))
				return GetDecimal(dr, Fields[FieldName], NullValue);
			else
				return NullValue;
		}
		public static Decimal GetDecimal(IDataReader dr, int Index)
		{
			return GetDecimal(dr, Index, 0);
		}
		public static Decimal GetDecimal(IDataReader dr, int Index, Decimal NullValue)
		{
			object o = dr[Index];
			if(!(o is Decimal)) return NullValue;

			decimal d = (Decimal)o;
			//int[] bits = decimal.GetBits(d);
			if(ReconvertDecimals)
				return D2D(d);
			else
				return d;
		}

		public static double GetDouble(IDataReader dr, FieldDictionary Fields, string FieldName)
		{
			return GetDouble(dr, Fields, FieldName, 0);
		}
		public static double GetDouble(IDataReader dr, FieldDictionary Fields, string FieldName, double NullValue)
		{
			if(Fields.ContainsKey(FieldName))
				return GetDouble(dr, Fields[FieldName], NullValue);
			else
				return NullValue;
		}
		public static double GetDouble(IDataReader dr, int Index)
		{
			return GetDouble(dr, Index, 0);
		}
		public static double GetDouble(IDataReader dr, int Index, double NullValue)
		{
			object o = dr[Index];
			if(!(o is double)) return NullValue;
			return (double)o;
		}

		public static float GetFloat(IDataReader dr, FieldDictionary Fields, string FieldName)
		{
			return GetFloat(dr, Fields, FieldName, 0);
		}
		public static float GetFloat(IDataReader dr, FieldDictionary Fields, string FieldName, float NullValue)
		{
			if(Fields.ContainsKey(FieldName))
				return GetFloat(dr, Fields[FieldName], NullValue);
			else
				return NullValue;
		}
		public static float GetFloat(IDataReader dr, int Index)
		{
			return GetFloat(dr, Index, 0);
		}
		public static float GetFloat(IDataReader dr, int Index, float NullValue)
		{
			object o = dr[Index];
			if(!(o is float)) return NullValue;
			return (float)o;
		}

		public static Int32 GetInt32(IDataReader dr, FieldDictionary Fields, string FieldName)
		{
			return GetInt32(dr, Fields, FieldName, 0);
		}
		public static Int32 GetInt32(IDataReader dr, FieldDictionary Fields, string FieldName, Int32 NullValue)
		{
			if(Fields.ContainsKey(FieldName))
				return GetInt32(dr, Fields[FieldName], NullValue);
			else
				return NullValue;
		}
		public static Int32 GetInt32(IDataReader dr, int Index)
		{
			return GetInt32(dr, Index, 0);
		}
		public static Int32 GetInt32(IDataReader dr, int Index, Int32 NullValue)
		{
			object o = dr[Index];
			if(o is Int32)
				return (Int32)o;
			if(o is Int16)
				return (Int32)((Int16)o);

			return NullValue;
		}

		public static short GetShort(IDataReader dr, FieldDictionary Fields, string FieldName)
		{
			return GetShort(dr, Fields, FieldName, 0);
		}
		public static short GetShort(IDataReader dr, FieldDictionary Fields, string FieldName, short NullValue)
		{
			if(Fields.ContainsKey(FieldName))
				return GetShort(dr, Fields[FieldName], NullValue);
			else
				return NullValue;
		}
		public static short GetShort(IDataReader dr, int Index)
		{
			return GetShort(dr, Index, 0);
		}
		public static short GetShort(IDataReader dr, int Index, short NullValue)
		{
			object o = dr[Index];
			if(!(o is short)) return NullValue;
			return (short)o;
		}

		public static bool GetBoolean(IDataReader dr, FieldDictionary Fields, string FieldName)
		{
			return GetBoolean(dr, Fields, FieldName, false);
		}
		public static bool GetBoolean(IDataReader dr, FieldDictionary Fields, string FieldName, bool NullValue)
		{
			if(Fields.ContainsKey(FieldName))
				return GetBoolean(dr, Fields[FieldName], NullValue);
			else
				return NullValue;
		}
		public static bool GetBoolean(IDataReader dr, int Index)
		{
			return GetBoolean(dr, Index, false);
		}
		public static bool GetBoolean(IDataReader dr, int Index, bool NullValue)
		{
			object o = dr[Index];
			if(!(o is bool)) return NullValue;
			return (bool)o;
		}

		public static Guid GetGuid(IDataReader dr, FieldDictionary Fields, string FieldName)
		{
			return GetGuid(dr, Fields, FieldName, Guid.Empty);
		}
		public static Guid GetGuid(IDataReader dr, FieldDictionary Fields, string FieldName, Guid NullValue)
		{
			if(Fields.ContainsKey(FieldName))
				return GetGuid(dr, Fields[FieldName], NullValue);
			else
				return NullValue;
		}
		public static Guid GetGuid(IDataReader dr, int Index)
		{
			return GetGuid(dr, Index, Guid.Empty);
		}
		public static Guid GetGuid(IDataReader dr, int Index, Guid NullValue)
		{
			object o = dr[Index];
			if(!(o is Guid)) return NullValue;
			return (Guid)o;
		}

		public static string GetString(IDataReader dr, FieldDictionary Fields, string FieldName)
		{
			return GetString(dr, Fields, FieldName, null);
		}
		public static string GetString(IDataReader dr, FieldDictionary Fields, string FieldName, string NullValue)
		{
			if(Fields.ContainsKey(FieldName))
				return GetString(dr, Fields[FieldName], NullValue);
			else
				return NullValue;
		}
		public static string GetString(IDataReader dr, int Index)
		{
			return GetString(dr, Index, null);
		}
		public static string GetString(IDataReader dr, int Index, string NullValue)
		{
			object o = dr[Index];
			if(!(o is string)) return NullValue;
			return (string)o;
		}

		public static byte[] GetBytes(IDataReader dr, FieldDictionary Fields, string FieldName)
		{
			return GetBytes(dr, Fields, FieldName, null);
		}
		public static byte[] GetBytes(IDataReader dr, FieldDictionary Fields, string FieldName, byte[] NullValue)
		{
			if(Fields.ContainsKey(FieldName))
				return GetBytes(dr, Fields[FieldName], NullValue);
			else
				return NullValue;
		}
		public static byte[] GetBytes(IDataReader dr, int Index)
		{
			return GetBytes(dr, Index, null);
		}
		public static byte[] GetBytes(IDataReader dr, int Index, byte[] NullValue)
		{
			object o = dr[Index];
			if(!(o is byte[])) return NullValue;
			return (byte[])o;
		}

		#endregion

		#region Funzione di set con sostituzione del DBNull
		public static void SetValue(IDbCommand cmd, string ParName, object Value)
		{
			SetValue(cmd, ParName, Value, DateTime.MinValue);
		}
		public static void SetValue(IDbCommand cmd, string ParName, object Value, object NullValue)
		{
			if(Value == NullValue)
				cmd.Parameters[ParName] = DBNull.Value;
			else
				cmd.Parameters[ParName] = Value;
		}
		#endregion

		#region Decimal to decimal conversion for Compact Framework support
		/// <summary>
		/// power of 10 to make the computation faster
		/// </summary>
		private static decimal[] P10 = new decimal[] {
			1M, 
			10M, 
			100M, 
			1000M, 
			10000M, 
			100000M, 
			1000000M, 
			10000000M,
			100000000M, 
			1000000000M, 
			10000000000M,
			100000000000M,
			1000000000000M,
			10000000000000M,
			100000000000000M,
			1000000000000000M,
			10000000000000000M,
			100000000000000000M,
			1000000000000000000M,
			10000000000000000000M,
			100000000000000000000M
		};

		/// <summary>
		/// Compact framework load data in a different internal format form Decimals
		/// This brings to weird format where you see the zeros after the decimal points
		/// Since decimal is not a a IEEE format but a "snapshot", you cannot cut decimals
		/// in different ways
		/// </summary>
		/// <param name="d">decimal number to convert (loaded from SQLCE)</param>
		/// <returns>converted number</returns>
		private static decimal D2D(decimal d)
		{
			int[] bits = decimal.GetBits(d);

			// - I used fewer local variables for performance reasons
			// - Table P10 is the fastest method to avoid computations
			// - decimal.Divide is the most performant method to do this job

			return decimal.Divide(new decimal(bits[0], bits[1], bits[2], (bits[3] & 0x80000000) != 0, 0),
				P10[(byte)(bits[3] >> 16)]);
		}
		#endregion



	}





}
