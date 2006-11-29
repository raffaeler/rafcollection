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
		internal static Order ReadOrder(IDataReader dr, FieldDictionary Fields)
		{
			Order item = new Order();
			item.OrderID = Values.GetInt32(dr, Fields, "OrderID");
			item.CustomerID = Values.GetString(dr, Fields, "CustomerID");
			item.EmployeeID = Values.GetInt32(dr, Fields, "EmployeeID");
			item.OrderDate = Values.GetDateTime(dr, Fields, "OrderDate");
			item.RequiredDate = Values.GetDateTime(dr, Fields, "RequiredDate");
			item.ShippedDate = Values.GetDateTime(dr, Fields, "ShippedDate");
			item.ShipVia = Values.GetInt32(dr, Fields, "ShipVia");
			item.Freight = Values.GetDecimal(dr, Fields, "Freight");
			item.ShipName = Values.GetString(dr, Fields, "ShipName");
			item.ShipAddress = Values.GetString(dr, Fields, "ShipAddress");
			item.ShipCity = Values.GetString(dr, Fields, "ShipCity");
			item.ShipRegion = Values.GetString(dr, Fields, "ShipRegion");
			item.ShipPostalCode = Values.GetString(dr, Fields, "ShipPostalCode");
			item.ShipCountry = Values.GetString(dr, Fields, "ShipCountry");
			return item;
		}


	}
}

