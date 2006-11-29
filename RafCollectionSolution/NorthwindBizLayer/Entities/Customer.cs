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
using System.Text.RegularExpressions;
using Vevy.Collections;


namespace NorthwindBizLayer.Entities
{
	[Serializable]
	public class CustomerCollection : RafCollection<Customer>
	{
	}


	[Serializable]
	public class Customer : INotifyPropertyChanged, IEditableObject, ICloneable
	{
		private string _CustomerID = string.Empty;
		private string _CompanyName = string.Empty;
		private string _ContactName = string.Empty;
		private string _ContactTitle = string.Empty;
		private string _Address = string.Empty;
		private string _City = string.Empty;
		private string _Region = string.Empty;
		private string _PostalCode = string.Empty;
		private string _Country = string.Empty;
		private string _Phone = string.Empty;
		private string _Fax = string.Empty;

		/// <summary>
		/// Default Contructor
		/// <summary>
		public Customer() { }

		#region Accessor properties
		public string CustomerID
		{
			get { return _CustomerID; }
			set { OnDataChanged(null); _CustomerID = value; OnDataChanged("CustomerID"); }
		}
		public string CompanyName
		{
			get { return _CompanyName; }
			set { OnDataChanged(null); _CompanyName = value; OnDataChanged("CompanyName"); }
		}
		public string ContactName
		{
			get { return _ContactName; }
			set { OnDataChanged(null); _ContactName = value; OnDataChanged("ContactName"); }
		}
		public string ContactTitle
		{
			get { return _ContactTitle; }
			set { OnDataChanged(null); _ContactTitle = value; OnDataChanged("ContactTitle"); }
		}
		public string Address
		{
			get { return _Address; }
			set { OnDataChanged(null); _Address = value; OnDataChanged("Address"); }
		}
		public string City
		{
			get { return _City; }
			set { OnDataChanged(null); _City = value; OnDataChanged("City"); }
		}
		public string Region
		{
			get { return _Region; }
			set { OnDataChanged(null); _Region = value; OnDataChanged("Region"); }
		}
		public string PostalCode
		{
			get { return _PostalCode; }
			set { OnDataChanged(null); _PostalCode = value; OnDataChanged("PostalCode"); }
		}
		public string Country
		{
			get { return _Country; }
			set { OnDataChanged(null); _Country = value; OnDataChanged("Country"); }
		}
		public string Phone
		{
			get { return _Phone; }
			set { OnDataChanged(null); _Phone = value; OnDataChanged("Phone"); }
		}
		public string Fax
		{
			get { return _Fax; }
			set { OnDataChanged(null); _Fax = value; OnDataChanged("Fax"); }
		}
		#endregion

		#region INotifyPropertyChanged Members
		[NonSerialized]
		private PropertyChangedEventHandler _PropertyChangedHandler;
		public event PropertyChangedEventHandler PropertyChanged
		{
			add { _PropertyChangedHandler += value; }
			remove { _PropertyChangedHandler -= value; }
		}

		protected virtual void OnDataChanged(string PropertyName)
		{
			if(_PropertyChangedHandler != null)
				_PropertyChangedHandler(this, new PropertyChangedEventArgs(PropertyName));
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
			Customer cust = new Customer();
			cust.CustomerID = CustomerID;
			cust.CompanyName = CompanyName;
			cust.ContactName = ContactName;
			cust.ContactTitle = ContactTitle;
			cust.Address = Address;
			cust.City = City;
			cust.Region = Region;
			cust.PostalCode = PostalCode;
			cust.Country = Country;
			cust.Phone = Phone;
			cust.Fax = Fax;
			return cust;
		}

		#endregion

		public override string ToString()
		{
			return CompanyName;
		}

	}





}
