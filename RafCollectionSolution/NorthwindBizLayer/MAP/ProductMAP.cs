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
		internal static Product ReadProduct(IDataReader dr, FieldDictionary Fields)
		{
			Product item = new Product();
			item.ProductID = Values.GetInt32(dr, Fields, "ProductID");
			item.ProductName = Values.GetString(dr, Fields, "ProductName");
			item.SupplierID = Values.GetInt32(dr, Fields, "SupplierID");
			item.CategoryID = Values.GetInt32(dr, Fields, "CategoryID");
			item.QuantityPerUnit = Values.GetString(dr, Fields, "QuantityPerUnit");
			item.UnitPrice = Values.GetDecimal(dr, Fields, "UnitPrice");
			item.UnitsInStock = Values.GetInt32(dr, Fields, "UnitsInStock");
			item.UnitsOnOrder = Values.GetInt32(dr, Fields, "UnitsOnOrder");
			item.Discontinued = Values.GetBoolean(dr, Fields, "Discontinued");
			return item;
		}


	}
}

