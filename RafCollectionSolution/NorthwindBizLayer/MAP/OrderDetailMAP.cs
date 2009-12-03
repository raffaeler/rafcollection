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
		internal static OrderDetail ReadOrderDetail(IDataReader dr, FieldDictionary Fields)
		{
			OrderDetail item = new OrderDetail();
			item.OrderID = Values.GetInt32(dr, Fields, "OrderID");
			item.ProductID = Values.GetInt32(dr, Fields, "ProductID");
			item.UnitPrice = Values.GetDecimal(dr, Fields, "UnitPrice");
			item.Quantity = Values.GetInt32(dr, Fields, "Quantity");
			item.Discount = Values.GetDecimal(dr, Fields, "Discount");
			return item;
		}


	}
}

