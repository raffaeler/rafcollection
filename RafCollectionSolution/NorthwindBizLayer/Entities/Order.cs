// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

// [Raffaele]
// Commented lines will be used in the future
// I have the classes for all the northind db
// but they should be refactored so I haven't published them
// If you need them, please let me know

using System;
using System.Collections.Generic;
using System.Text;

using Vevy.Collections;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Diagnostics;
//using NorthwindBizLayer.Validators;

namespace NorthwindBizLayer.Entities
{
	[Serializable]
	public class OrderCollection : RafCollection<Order>
	{
	}

	[Serializable]
//	[EntityValidator(typeof(OrderValidator))]
//	[EntityValidator(typeof(OrderValidator))]
//	[EntityValidator(typeof(OrderValidator))]
	public class Order : INotifyPropertyChanged, IEditableObject, ICloneable
	{
		private int _OrderID;
		private string _CustomerID;
		private int _EmployeeID;
		private System.DateTime _OrderDate;
		private System.DateTime _RequiredDate;
		private System.DateTime _ShippedDate;
		private int _ShipVia;
		private decimal _Freight;
		private string _ShipName;
		private string _ShipAddress;
		private string _ShipCity;
		private string _ShipRegion;
		private string _ShipPostalCode;
		private string _ShipCountry;

		//private OrderDetailCollection _OrderDetails;
		//public OrderDetailCollection OrderDetails
		//{
		//    get { return _OrderDetails; }
		//}

		private CustomerCollection _Customers;
		public CustomerCollection Customers
		{
			get { return _Customers; }
		}

		//private EmployeeCollection _Employees;
		//public EmployeeCollection Employees
		//{
		//    get { return _Employees; }
		//}

		/// <summary>
		/// Default Contructor
		/// <summary>
		public Order()
		{
		    _Customers = new CustomerCollection();
		//    _Employees = new EmployeeCollection();
		//    _OrderDetails = new OrderDetailCollection();
		}
		/// <summary>
		/// 
		/// <summary>
		internal Order(CustomerCollection customers/*, EmployeeCollection employees, OrderDetailCollection details*/)
		{
		    _Customers = customers;
		//    _Employees = employees;
		//    _OrderDetails = details;
		}

		#region Accessor properties con INotifyPropertyChanged prima e dopo
		public int OrderID
		{
			get { return _OrderID; }
			set { OnDataChanged(null); _OrderID = value; OnDataChanged("OrderID"); }
		}
		public string CustomerID
		{
			get { return _CustomerID; }
			set { OnDataChanged(null); _CustomerID = value; OnDataChanged("CustomerID"); }
		}
		public int EmployeeID
		{
			get { return _EmployeeID; }
			set { OnDataChanged(null); _EmployeeID = value; OnDataChanged("EmployeeID"); }
		}
		public System.DateTime OrderDate
		{
			get { return _OrderDate; }
			set { OnDataChanged(null); _OrderDate = value; OnDataChanged("OrderDate"); }
		}
		public System.DateTime RequiredDate
		{
			get { return _RequiredDate; }
			set { OnDataChanged(null); _RequiredDate = value; OnDataChanged("RequiredDate"); }
		}
		public System.DateTime ShippedDate
		{
			get { return _ShippedDate; }
			set { OnDataChanged(null); _ShippedDate = value; OnDataChanged("ShippedDate"); }
		}
		public int ShipVia
		{
			get { return _ShipVia; }
			set { OnDataChanged(null); _ShipVia = value; OnDataChanged("ShipVia"); }
		}
		public decimal Freight
		{
			get { return _Freight; }
			set { OnDataChanged(null); _Freight = value; OnDataChanged("Freight"); }
		}
		public string ShipName
		{
			get { return _ShipName; }
			set { OnDataChanged(null); _ShipName = value; OnDataChanged("ShipName"); }
		}
		public string ShipAddress
		{
			get { return _ShipAddress; }
			set { OnDataChanged(null); _ShipAddress = value; OnDataChanged("ShipAddress"); }
		}
		public string ShipCity
		{
			get { return _ShipCity; }
			set { OnDataChanged(null); _ShipCity = value; OnDataChanged("ShipCity"); }
		}
		public string ShipRegion
		{
			get { return _ShipRegion; }
			set { OnDataChanged(null); _ShipRegion = value; OnDataChanged("ShipRegion"); }
		}
		public string ShipPostalCode
		{
			get { return _ShipPostalCode; }
			set { OnDataChanged(null); _ShipPostalCode = value; OnDataChanged("ShipPostalCode"); }
		}
		public string ShipCountry
		{
			get { return _ShipCountry; }
			set { OnDataChanged(null); _ShipCountry = value; OnDataChanged("ShipCountry"); }
		}
		#endregion

		#region INotifyPropertyChanged Members
		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnDataChanged(string PropertyName)
		{
			if(PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
		}
		#endregion

		#region IEditableObject
		object _Self;
		public void BeginEdit()
		{
			EntityHelper.BeginEdit(this, ref _Self);
		}

		public void CancelEdit()
		{
			EntityHelper.CancelEdit(this, ref _Self);
		}

		public void EndEdit()
		{
			EntityHelper.EndEdit(this, ref _Self);
		}
		#endregion

		#region ICloneable Members

		/// <summary>
		/// Shallow copy
		/// </summary>
		/// <returns>Cloned object</returns>
		public object Clone()
		{
			Order order = new Order(_Customers/*, _Employees, _OrderDetails*/);
			order.OrderID = OrderID;
			order.CustomerID = CustomerID;
			order.EmployeeID = EmployeeID;
			order.OrderDate = OrderDate;
			order.RequiredDate = RequiredDate;
			order.ShippedDate = ShippedDate;
			order.ShipVia = ShipVia;
			order.Freight = Freight;
			order.ShipName = ShipName;
			order.ShipAddress = ShipAddress;
			order.ShipCity = ShipCity;
			order.ShipRegion = ShipRegion;
			order.ShipPostalCode = ShipPostalCode;
			order.ShipCountry = ShipCountry;
			return order;
		}

		#endregion

		public override string ToString()
		{
			return OrderID.ToString() + " " + ShipCity;
		}

	}

}
