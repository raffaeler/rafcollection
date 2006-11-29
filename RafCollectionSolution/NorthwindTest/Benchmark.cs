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
using Vevy.Collections;
using System.Windows.Forms;
using System.ComponentModel;

namespace NorthwindTest
{
	/// <summary>
	/// interface exposing methods used for testing
	/// </summary>
	public interface ITestBiz
	{
		void AddOne();
		void DeleteOne();
		void Clear();
	}

	/// <summary>
	/// A test class
	/// </summary>
	public class TestCustomClass : ITestBiz
	{
		private CustomClassCollection ccc;
		
		public TestCustomClass()
		{
			ccc = new CustomClassCollection();
		}

		public void AddOne()
		{
			RandomValues rnd = new RandomValues();
			CustomClass biz = new CustomClass(rnd.RandInt, rnd.RandInt,
				rnd.RandDecimal, rnd.RandDecimal,
				rnd.RandDouble, rnd.RandDouble,
				rnd.RandString, rnd.RandString,
				rnd.RandString, rnd.RandString,
				rnd.RandDateTime, rnd.RandDateTime);
			ccc.Add(biz);
		}

		public void DeleteOne()
		{
			ccc.RemoveAt(0);
		}

		public void Clear()
		{
			ccc.Clear();
		}
	}

	/// <summary>
	/// Another test class
	/// </summary>
	[Serializable]
	public class CustomClass : ICloneable, INotifyPropertyChanged
	{
		private int _c0;
		private int _c1;
		private decimal _c2;
		private decimal _c3;
		private double _c4;
		private double _c5;
		private string _c6;
		private string _c7;
		private string _c8;
		private string _c9;
		private DateTime _c10;
		private DateTime _c11;

		public int C0
		{
			get { return _c0; }
			set { OnDataChanged(null); _c0 = value; OnDataChanged("C0"); }
		}
		public int C1
		{
			get { return _c1; }
			set { OnDataChanged(null); _c1 = value; OnDataChanged("C1"); }
		}
		public decimal C2
		{
			get { return _c2; }
			set { OnDataChanged(null); _c2 = value; OnDataChanged("C2"); }
		}
		public decimal C3
		{
			get { return _c3; }
			set { OnDataChanged(null); _c3 = value; OnDataChanged("C3"); }
		}
		public double C4
		{
			get { return _c4; }
			set { OnDataChanged(null); _c4 = value; OnDataChanged("C4"); }
		}
		public double C5
		{
			get { return _c5; }
			set { OnDataChanged(null); _c5 = value; OnDataChanged("C5"); }
		}
		public string C6
		{
			get { return _c6; }
			set { OnDataChanged(null); _c6 = value; OnDataChanged("C6"); }
		}
		public string C7
		{
			get { return _c7; }
			set { OnDataChanged(null); _c7 = value; OnDataChanged("C7"); }
		}
		public string C8
		{
			get { return _c8; }
			set { OnDataChanged(null); _c8 = value; OnDataChanged("C8"); }
		}
		public string C9
		{
			get { return _c9; }
			set { OnDataChanged(null); _c9 = value; OnDataChanged("C9"); }
		}
		public DateTime C10
		{
			get { return _c10; }
			set { OnDataChanged(null); _c10 = value; OnDataChanged("C10"); }
		}
		public DateTime C11
		{
			get { return _c11; }
			set { OnDataChanged(null); _c11 = value; OnDataChanged("C11"); }
		}

		public CustomClass() { }
		public CustomClass(int c0, int c1,
			decimal c2, decimal c3,
			double c4, double c5,
			string c6, string c7,
			string c8, string c9,
			DateTime c10, DateTime c11)
		{
			_c0 = c0;
			_c1 = c1;
			_c2 = c2;
			_c3 = c3;
			_c4 = c4;
			_c5 = c5;
			_c6 = c6;
			_c7 = c7;
			_c8 = c8;
			_c9 = c9;
			_c10 = c10;
			_c11 = c11;
		}

		#region ICloneable Members

		public object Clone()
		{
			CustomClass clone = new CustomClass();
			clone.C0 = _c0;
			clone.C1 = _c1;
			clone.C2 = _c2;
			clone.C3 = _c3;
			clone.C4 = _c4;
			clone.C5 = _c5;
			clone.C6 = _c6;
			clone.C7 = _c7;
			clone.C8 = _c8;
			clone.C9 = _c9;
			clone.C10 = _c10;
			clone.C11 = _c11;
			return clone;
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
	}

	public class CustomClassCollection : RafCollection<CustomClass>
	{ }

	public class TestDataSet : ITestBiz
	{
		private DataSet ds;
		public TestDataSet()
		{
			ds = new DataSet();
			DataTable dt = ds.Tables.Add();
			dt.Columns.Add("C0", typeof(int));
			dt.Columns.Add("C1", typeof(int));
			dt.Columns.Add("C2", typeof(decimal));
			dt.Columns.Add("C3", typeof(decimal));
			dt.Columns.Add("C4", typeof(double));
			dt.Columns.Add("C5", typeof(double));
			dt.Columns.Add("C6", typeof(string));
			dt.Columns.Add("C7", typeof(string));
			dt.Columns.Add("C8", typeof(string));
			dt.Columns.Add("C9", typeof(string));
			dt.Columns.Add("C10", typeof(DateTime));
			dt.Columns.Add("C11", typeof(DateTime));
		}

		public void AddOne()
		{
			RandomValues rnd = new RandomValues();
			DataTable dt = ds.Tables[0];
			dt.Rows.Add(new object[] {rnd.RandInt, rnd.RandInt, 
										 rnd.RandDecimal, rnd.RandDecimal, 
										 rnd.RandDouble, rnd.RandDouble, 
										 rnd.RandString, rnd.RandString, 
										 rnd.RandString, rnd.RandString,
										 rnd.RandDateTime, rnd.RandDateTime});
		}

		public void DeleteOne()
		{
			DataTable dt = ds.Tables[0];
			dt.Rows.RemoveAt(0);
		}

		public void Clear()
		{
			// Clear doesn't really remove as RafCollection Remove does.
			// So they cannot be compared
			//ds.Tables[0].Clear();	

			int Count = ds.Tables[0].Rows.Count;
			for(int i = 0; i < Count; i++)
				ds.Tables[0].Rows.RemoveAt(0);
		}
	}

	public class RandomValues
	{
		public int RandInt
		{
			get { return 0; }
		}

		public decimal RandDecimal
		{
			get { return 0m; }
		}

		public double RandDouble
		{
			get { return 0.0; }
		}

		public string RandString
		{
			get
			{
				return string.Empty;
			}
		}

		public DateTime RandDateTime
		{
			get
			{
				return DateTime.MinValue;
			}
		}
	}

	public class RandomValues2
	{
		private Random rnd = new Random(DateTime.Now.Millisecond);
		public int RandInt
		{
			get { return Convert.ToInt32(rnd.NextDouble()); }
		}

		public decimal RandDecimal
		{
			get { return Convert.ToDecimal(rnd.NextDouble()); }
		}

		public double RandDouble
		{
			get { return rnd.NextDouble(); }
		}

		public string RandString
		{
			get
			{
				int Len = 30;
				char[] ch = new char[Len];
				for(int i = 0; i < Len; i++)
					ch[i] = Convert.ToChar((UInt16)(int)rnd.NextDouble());
				return new string(ch);
			}
		}

		public DateTime RandDateTime
		{
			get
			{
				return DateTime.MinValue.AddMilliseconds(rnd.NextDouble());
			}
		}
	}

	public static class Benchmark
	{
		public static TimeSpan DoSpeedTest(ITestBiz obj, int times) //1000000
		{
			DateTime d1 = DateTime.Now;
			for (int i = 0; i < times; i++)
			{
				obj.AddOne();
				obj.DeleteOne();
			}

			for (int j = 0; j < 1000; j++)	// 1000
			{
				for (int i = 0; i < 10000; i++)
				{
					obj.AddOne();
				}
				obj.Clear();
			}
			DateTime d2 = DateTime.Now;

			return d2 - d1;
		}

		public static void DoMemoryTest(ITestBiz obj, int times) //500000
		{
			for (int i = 0; i < times; i++)
				obj.AddOne();

			MessageBox.Show("Take the snapshot");
			obj.Clear();
			return;
		}
	}
}
