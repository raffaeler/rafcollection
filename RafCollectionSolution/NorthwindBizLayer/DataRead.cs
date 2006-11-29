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
using Vevy.DBHelper;


namespace NorthwindBizLayer
{
	public class DataRead
	{
		/// <summary>
		/// Delegate signature for RunQuery method
		/// </summary>
		/// <param name="dr">An IDataReader used to read rows</param>
		/// <param name="Fields">See documentation</param>
		/// <param name="Param">A custom parameter for the delegate</param>
		public delegate void ProcessRow(IDataReader dr, FieldDictionary Fields, object Param);

		// esegue una query e per ogni riga chiama il delegate specificato con il parametro specificato
		/// <summary>
		/// Run a query and for each row of the resultset
		/// it calls the ProcessRow delegate
		/// </summary>
		/// <param name="cmd">Command with a valid connection assigned</param>
		/// <param name="pr">Delegate to be called for each row</param>
		/// <param name="Param">A parameter to be passed to the delegate.
		/// Typically a collection in ehich to add the created entity</param>
		/// <returns>The number of rows</returns>
		public static int RunQuery(IDbCommand cmd, ProcessRow pr, object Param)
		{
			int Count = 0;
			IDataReader dr = null;
			bool IsConnectionOpen = (cmd.Connection.State == ConnectionState.Open);
			if(!IsConnectionOpen)
				cmd.Connection.Open();
			try
			{
				dr = cmd.ExecuteReader();
				FieldDictionary dic = GetFields(dr);
				while(dr.Read())
				{
					pr(dr, dic, Param);
					Count++;
				}
			}
			catch(Exception err)
			{
				throw err;
			}
			finally
			{
				if(dr != null)
					dr.Close();
				if(!IsConnectionOpen)
					cmd.Connection.Close();
			}
			return Count;
		}

		/// <summary>
		/// Get the column metatada from the DataReader and store it in a Dictionary
		/// This Dictionary could be cached for better performances
		/// </summary>
		/// <param name="dr">IDataReader from which obtaining metadata</param>
		/// <returns>The dictionary</returns>
		public static FieldDictionary GetFields(IDataReader dr)
		{
			int FieldCount = dr.FieldCount;
			FieldDictionary dic = new FieldDictionary(FieldCount);
			for(int i = 0; i < FieldCount; i++)
			{
				dic.Add(dr.GetName(i), i);
			}
			return dic;
		}



	}
}
