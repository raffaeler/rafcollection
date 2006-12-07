// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document

using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Vevy.Collections
{
	[Serializable]
	public class Box<T>
	{
		public Box(Storage<T> Storage, bool Visible)
		{
			_Storage = Storage;
			_Visible = Visible;
		}

		private Storage<T> _Storage;
		public Storage<T> Storage
		{
			get { return _Storage; }
			set { _Storage = value; }
		}

		private bool _Visible;
		public bool Visible
		{
			get { return _Visible; }
			set { _Visible = value; }
		}
	}

}

