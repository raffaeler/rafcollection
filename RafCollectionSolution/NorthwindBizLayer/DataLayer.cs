// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using NorthwindBizLayer.Entities;
using NorthwindBizLayer.MAP;
using System.Data;
using Vevy.DBHelper;

namespace NorthwindBizLayer
{
	public class DataLayer
	{
		private string _strCnn;
		public DataLayer(string strCnn)
		{
			_strCnn = strCnn;
		}

		//internal void CategoryProc(IDataReader dr, FieldDictionary Fields, object Param)
		//{
		//    CategoryCollection coll = Param as CategoryCollection;
		//    Category item = Mapper.ReadCategory(dr, Fields);
		//    coll.Add(item);
		//}

		internal static void CustomerProc(IDataReader dr, FieldDictionary Fields, object Param)
		{
			CustomerCollection coll = Param as CustomerCollection;
			Customer item = Mapper.ReadCustomer(dr, Fields);
			coll.Add(item);
		}

		//internal static void EmployeeProc(IDataReader dr, FieldDictionary Fields, object Param)
		//{
		//    EmployeeCollection coll = Param as EmployeeCollection;
		//    Employee item = Mapper.ReadEmployee(dr, Fields);
		//    coll.Add(item);
		//}

		//internal static void OrderDetailProc(IDataReader dr, FieldDictionary Fields, object Param)
		//{
		//    OrderDetailCollection coll = Param as OrderDetailCollection;
		//    OrderDetail item = Mapper.ReadOrderDetail(dr, Fields);
		//    coll.Add(item);
		//}

		internal static void OrderProc(IDataReader dr, FieldDictionary Fields, object Param)
		{
			OrderCollection coll = Param as OrderCollection;
			Order item = Mapper.ReadOrder(dr, Fields);
			coll.Add(item);
		}

		//internal static void ProductProc(IDataReader dr, FieldDictionary Fields, object Param)
		//{
		//    ProductCollection coll = Param as ProductCollection;
		//    Product item = Mapper.ReadProduct(dr, Fields);
		//    coll.Add(item);
		//}

		//internal static void SupplierProc(IDataReader dr, FieldDictionary Fields, object Param)
		//{
		//    SupplierCollection coll = Param as SupplierCollection;
		//    Supplier item = Mapper.ReadSupplier(dr, Fields);
		//    coll.Add(item);
		//}



//        public CustomerCollection GetAllCustomers()
//        {
//            string str = @"select CustomerID, CompanyName, ContactName, ContactTitle, Address, City,
//				Region, PostalCode, Country, Phone, Fax from Customers";
//            SqlCommand cmd = new SqlCommand(str, new SqlConnection(_strCnn));

//            CustomerCollection cc = new CustomerCollection();
//            DataRead.RunQuery(cmd, new DataRead.ProcessRow(CustomerProc), cc);
//            cc.AcceptChanges();
//            return cc;
//        }

//        public OrderDetailCollection GetAllOrderDetails()
//        {
//            string str = @"select OrderID, ProductID, UnitPrice, Quantity, Discount
//							from [Order Details]";
//            SqlCommand cmd = new SqlCommand(str, new SqlConnection(_strCnn));

//            OrderDetailCollection cc = new OrderDetailCollection();
//            DataRead.RunQuery(cmd, new DataRead.ProcessRow(OrderDetailProc), cc);
//            cc.AcceptChanges();
//            return cc;
//        }

//        public OrderDetailCollection GetOrderDetailsByOrderId(int OrderId)
//        {
//            string str = @"select OrderID, ProductID, UnitPrice, Quantity, Discount
//							from [Order Details] where OrderId = @OrderId";
//            SqlCommand cmd = new SqlCommand(str, new SqlConnection(_strCnn));
//            cmd.Parameters.Add("@OrderId", SqlDbType.Int, 0, "OrderId");
//            cmd.Parameters[0].Value = OrderId;

//            OrderDetailCollection cc = new OrderDetailCollection();
//            DataRead.RunQuery(cmd, new DataRead.ProcessRow(OrderDetailProc), cc);
//            cc.AcceptChanges();
//            return cc;
//        }


		public OrderCollection GetAllOrders()
		{
			string str = @"select OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate,
							ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry
							from Orders";
			SqlCommand cmd = new SqlCommand(str, new SqlConnection(_strCnn));

			OrderCollection cc = new OrderCollection();
			DataRead.RunQuery(cmd, new DataRead.ProcessRow(OrderProc), cc);
			cc.AcceptChanges();
			return cc;
		}


//        public ProductCollection GetAllProducts()
//        {
//            string str = @"select ProductID, ProductName, SupplierID, CategoryID, 
//						QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, 
//						ReorderLevel, Discontinued
//						from Products";
//            SqlCommand cmd = new SqlCommand(str, new SqlConnection(_strCnn));

//            ProductCollection cc = new ProductCollection();
//            DataRead.RunQuery(cmd, new DataRead.ProcessRow(ProductProc), cc);
//            cc.AcceptChanges();
//            return cc;
//        }

//        public ProductCollection GetProductByProductId(int ProductId)
//        {
//            string str = @"select ProductID, ProductName, SupplierID, CategoryID, 
//						QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, 
//						ReorderLevel, Discontinued
//						from Products where ProductId=@ProductId";
//            SqlCommand cmd = new SqlCommand(str, new SqlConnection(_strCnn));
//            cmd.Parameters.Add("@ProductId", SqlDbType.Int, 0, "ProductId");
//            cmd.Parameters[0].Value = ProductId;

//            ProductCollection cc = new ProductCollection();
//            DataRead.RunQuery(cmd, new DataRead.ProcessRow(ProductProc), cc);
//            cc.AcceptChanges();
//            return cc;
//        }

	
	}
}
