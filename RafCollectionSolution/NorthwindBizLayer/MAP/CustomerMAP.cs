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
using NorthwindBizLayer.Entities;

namespace NorthwindBizLayer.MAP
{
	internal static partial class Mapper
	{
		internal static Customer ReadCustomer(IDataReader dr, FieldDictionary Fields)
		{
			Customer item = new Customer();
			item.CustomerID = Values.GetString(dr, Fields, "CustomerID");
			item.CompanyName = Values.GetString(dr, Fields, "CompanyName");
			item.ContactName = Values.GetString(dr, Fields, "ContactName");
			item.ContactTitle = Values.GetString(dr, Fields, "ContactTitle");
			item.Address = Values.GetString(dr, Fields, "Address");
			item.City = Values.GetString(dr, Fields, "City");
			item.Region = Values.GetString(dr, Fields, "Region");
			item.PostalCode = Values.GetString(dr, Fields, "PostalCode");
			item.Country = Values.GetString(dr, Fields, "Country");
			item.Phone = Values.GetString(dr, Fields, "Phone");
			item.Fax = Values.GetString(dr, Fields, "Fax");
			return item;
		}


	}
}
