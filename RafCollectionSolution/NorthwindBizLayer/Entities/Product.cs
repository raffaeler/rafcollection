using System;
using System.Collections.Generic;
using System.Text;

using Vevy.Collections;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Diagnostics;


namespace NorthwindBizLayer.Entities
{
	[Serializable]
	public class ProductCollection : RafCollection<Product>
	{
	}


	[Serializable]
	public class Product : INotifyPropertyChanged, IEditableObject, ICloneable
	{
		private int _ProductID;
		private string _ProductName;
		private int _SupplierID;
		private int _CategoryID;
		private string _QuantityPerUnit;
		private decimal _UnitPrice;
		private int _UnitsInStock;
		private int _UnitsOnOrder;
		private bool _Discontinued;

		public Product()
		{
		}

		#region Properties
		public int ProductID
		{
			get { return _ProductID; }
			set { OnDataChanged(null); _ProductID = value; OnDataChanged("ProductID"); }
		}

		public string ProductName
		{
			get { return _ProductName; }
			set { OnDataChanged(null); _ProductName = value; OnDataChanged("ProductName"); }
		}

		public int SupplierID
		{
			get { return _SupplierID; }
			set { OnDataChanged(null); _SupplierID = value; OnDataChanged("SupplierID"); }
		}

		public int CategoryID
		{
			get { return _CategoryID; }
			set { OnDataChanged(null); _CategoryID = value; OnDataChanged("CategoryID"); }
		}

		public string QuantityPerUnit
		{
			get { return _QuantityPerUnit; }
			set { OnDataChanged(null); _QuantityPerUnit = value; OnDataChanged("QuantityPerUnit"); }
		}

		public decimal UnitPrice
		{
			get { return _UnitPrice; }
			set { OnDataChanged(null); _UnitPrice = value; OnDataChanged("UnitPrice"); }
		}

		public int UnitsInStock
		{
			get { return _UnitsInStock; }
			set { OnDataChanged(null); _UnitsInStock = value; OnDataChanged("UnitsInStock"); }
		}

		public int UnitsOnOrder
		{
			get { return _UnitsOnOrder; }
			set { OnDataChanged(null); _UnitsOnOrder = value; OnDataChanged("UnitsOnOrder"); }
		}

		public bool Discontinued
		{
			get { return _Discontinued; }
			set { OnDataChanged(null); _Discontinued = value; OnDataChanged("Discontinued"); }
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
			Product item = new Product();
			item.ProductID = ProductID;
			item.ProductName = ProductName;
			item.SupplierID = SupplierID;
			item.CategoryID = CategoryID;
			item.QuantityPerUnit = QuantityPerUnit;
			item.UnitPrice = UnitPrice;
			item.UnitsInStock = UnitsInStock;
			item.UnitsOnOrder = UnitsOnOrder;
			item.Discontinued = Discontinued;
			return item;
		}

		#endregion

		public override string ToString()
		{
			return ProductID.ToString() + " " + ProductName;
		}
	}

}
