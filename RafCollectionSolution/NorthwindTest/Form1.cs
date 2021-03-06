// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NorthwindBizLayer;
using NorthwindBizLayer.Entities;
using System.Text.RegularExpressions;
using Vevy.Collections;

namespace NorthwindTest
{
	public partial class Form1 : Form
	{
		DataLayer _Dal;

		public Form1()
		{
			InitializeComponent();
			_Dal = new DataLayer(Properties.Settings.Default.NorthwindConnectionString);
		}

		private OrderCollection LoadAll()
		{
			OrderCollection Orders = _Dal.GetAllOrders();
			foreach(Order order in Orders)
			{
				CustomerCollection customers = _Dal.GetCustomerByCustomerId(order.CustomerID);
				if(customers.Count > 0)
					order.Customer = customers[0];

				OrderDetailCollection details = _Dal.GetOrderDetailsByOrderId(order.OrderID);
				foreach(OrderDetail detail in details)
				{
					order.OrderDetails.Add(detail);

					ProductCollection products = _Dal.GetProductByProductId(detail.ProductID);
					if(products.Count > 0)
						detail.Product = products[0];
				}
			}
			return Orders;
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			//OrderCollection AllOrders = LoadAll();
			//SerializeHelper.Serialize(AllOrders, "AllOrders.bin");
			//CustomerCollection AllCustomers = _Dal.GetAllCustomers();
			//SerializeHelper.Serialize(AllCustomers, "AllCustomers.bin");


			OrderCollection Orders = _Dal.GetAllOrders();
			int count = Orders.Count;
			for(int i = 10; i < count; i++)
				Orders.RemoveAt(10);
			Orders.AcceptChanges();
			Console.WriteLine(Orders.HasChanges);
		//	Orders.StateFilter = ObjectStateFilter.CurrentAll;

			Console.WriteLine(Orders.ToString(true));
			Orders.RemoveAt(3);
			Orders.RemoveAt(4);
			Console.WriteLine(Orders.ToString(true));
			Orders.RejectChanges();
			Console.WriteLine(Orders.ToString(true));


/*
OrderCollection Orders = _Dal.GetAllOrders();
if (Orders.Count == 0) return;
Order order = Orders[0];
Customer customer = new Customer();
order.Customers.Add(customer);
System.Diagnostics.Debug.WriteLine("before rejectchanges order.Customers.Count " + order.Customers.Count);
Orders.RejectChanges();
System.Diagnostics.Debug.WriteLine("after rejectchanges order.Customers.Count " + Orders[0].Customers.Count);

//Before the RejectChanges the order.Customers.Count = 1
//After the RejectChanges the order.Customers.Count = 1 
*/
		}

		private void tsbLoad_Click(object sender, EventArgs e)
		{
			OrderCollection Orders = _Dal.GetAllOrders();
			orderCollectionBindingSource.DataSource = Orders;
			tscbColumnFilter.ComboBox.DataSource = typeof(Order).GetProperties();
			tscbColumnFilter.ComboBox.DisplayMember = "Name";
		}

		private void tstFilter_TextChanged(object sender, EventArgs e)
		{
			OrderCollection Orders = orderCollectionBindingSource.DataSource as OrderCollection;
			if(Orders == null)
				return;
			if(tstFilter.Text.Length == 0)
			{
				Orders.Filter = string.Empty;
				return;
			}

			Orders.Filter = tscbColumnFilter.ComboBox.Text + tscbOperator.ComboBox.Text + tstFilter.Text;
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			OrderCollection Orders = orderCollectionBindingSource.DataSource as OrderCollection;
			Orders.AcceptChanges();
		}

		private void btReject_Click(object sender, EventArgs e)
		{
			OrderCollection Orders = orderCollectionBindingSource.DataSource as OrderCollection;
			Orders.RejectChanges();
		}

		private void btIsChanged_Click(object sender, EventArgs e)
		{
			OrderCollection Orders = orderCollectionBindingSource.DataSource as OrderCollection;
			lblIsChanged.Text = Orders.HasChanges.ToString();
		}

		private void tsbMemTestDataSet_Click(object sender, EventArgs e)
		{
			Benchmark.DoMemoryTest(new TestDataSet(), 1000000);
		}

		private void tsbMemTestCollection_Click(object sender, EventArgs e)
		{
			Benchmark.DoMemoryTest(new TestCustomClass(), 1000000);
		}

		private void tsbSpeedTest_Click(object sender, EventArgs e)
		{
			TimeSpan t;
			int times = 10;// 500000;

			t = Benchmark.DoSpeedTest(new TestDataSet(), times);
			lblDataSet.Text = "Dataset " + t.ToString();
			double s1 = t.TotalSeconds;

			t = Benchmark.DoSpeedTest(new TestCustomClass(), times);
			lblCustom.Text = "Custom " + t.ToString();
			double s2 = t.TotalSeconds;

			double p1 = (s2 - s1) * 100.0 / s1;
			double p2 = (s2 - s1) * 100.0 / s2;

			lblDataSet.Text = lblDataSet.Text + "  " + p1.ToString("0.00") + "%";
			lblCustom.Text = lblCustom.Text + "  " + p2.ToString("0.00") + "%";
		}

		private void tsbAssertTests_Click(object sender, EventArgs e)
		{
		}

		private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			
			if (e.Button == MouseButtons.Left)
			{
				DataGridViewColumnHeaderCell hCell = dataGridView2.Columns[e.ColumnIndex].HeaderCell;
				switch (hCell.SortGlyphDirection)
				{
					case SortOrder.None:
						hCell.SortGlyphDirection = SortOrder.Ascending;
						break;
					case SortOrder.Ascending:
						hCell.SortGlyphDirection = SortOrder.Descending;
						break;
					case SortOrder.Descending:
						hCell.SortGlyphDirection = SortOrder.None;
						break;
				}				
			}
		}

		private void btSerializeTest_Click(object sender, EventArgs e)
		{
			OrderCollection Orders = orderCollectionBindingSource.DataSource as OrderCollection;
			if(Orders == null)
				return;
			try
			{
				SerializeHelper.Serialize(Orders, "SerializeText.bin");
				OrderCollection OrdersClone = SerializeHelper.Deserialize("SerializeText.bin") as OrderCollection;
			}
			catch(Exception err)
			{
				MessageBox.Show(err.ToString());
				return;
			}
			MessageBox.Show("Test Ok");

		}
	}
}