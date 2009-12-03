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
	public class OrderDetailCollection : RafCollection<OrderDetail>
	{
	}


	[Serializable]
	public class OrderDetail : INotifyPropertyChanged, IEditableObject, ICloneable
	{
		private int _OrderID;
		private int _ProductID;
		private decimal _UnitPrice;
		private int _Quantity;
		private decimal _Discount;

		public OrderDetail()
		{
		}

		#region Properties
		public int OrderID
		{
			get { return _OrderID; }
			set { OnDataChanged(null); _OrderID = value; OnDataChanged("OrderID"); }
		}

		public int ProductID
		{
			get { return _ProductID; }
			set { OnDataChanged(null); _ProductID = value; OnDataChanged("ProductID"); }
		}

		public decimal UnitPrice
		{
			get { return _UnitPrice; }
			set { OnDataChanged(null); _UnitPrice = value; OnDataChanged("UnitPrice"); }
		}

		public int Quantity
		{
			get { return _Quantity; }
			set { OnDataChanged(null); _Quantity = value; OnDataChanged("Quantity"); }
		}

		public decimal Discount
		{
			get { return _Discount; }
			set { OnDataChanged(null); _Discount = value; OnDataChanged("Discount"); }
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
			OrderDetail item = new OrderDetail();
			item.OrderID = OrderID;
			item.ProductID = ProductID;
			item.UnitPrice = UnitPrice;
			item.Quantity = Quantity;
			item.Discount = Discount;
			return item;
		}

		#endregion

		public override string ToString()
		{
			return OrderID.ToString() + " " + ProductID.ToString();
		}
	}

}
