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

namespace Vevy.Collections
{
	public partial class RafCollection<T>
	{
		/// <summary>
		/// Reverse the collection item order
		/// </summary>
		public void Reverse()
		{
			Array.Reverse(BaseArray, 0, _ArrayCount);
			//RecalcFilter();
			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}


		#region Sort
		/// <summary>
		/// Sort the collection using a custom delegate for comparison
		/// </summary>
		/// <param name="comparer"></param>
		public void Sort(IComparer<T> comparer)
		{
			if(_ArrayCount <= 1)
				return;

			Array.Sort<Box<T>>(BaseArray, 0, _ArrayCount, new ProxyStorageComparer(comparer));
			//RecalcFilter();
			_IsSorted = true;
			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}

		/// <summary>
		/// Proxy class for the comparison delegate
		/// Since the collection deals with Box objects, the role of this proxy is
		/// to compare the inner objects T instead of Box objets.
		/// </summary>
		private class ProxyStorageComparer : IComparer<Box<T>>
		{
			IComparer<T> _comparer;
			public ProxyStorageComparer(IComparer<T> comparer)
			{
				_comparer = comparer;
			}
			int IComparer<Box<T>>.Compare(Box<T> x, Box<T> y)
			{
				return _comparer.Compare(x.Storage.CollectedObject, y.Storage.CollectedObject);
			}
		}

		/// <summary>
		/// Sort the collection
		/// This overload require T implementing IComparable or IComparable(T)
		/// </summary>
		public void Sort()
		{
			Sort(String.Empty);
		}

		/// <summary>
		/// Sort the collection using a sort syntax like:
		/// property1 ASC, property2 DESC, ...
		/// </summary>
		/// <param name="SortString">Comma separated expression with ASC or DESC as property suffix</param>
		public void Sort(string SortString)
		{
			if(SortString == null || SortString.Length == 0)
			{
				// sort using IComparable or IComparable<T> in T
				if(RafCollection<T>.CollectedObjectImplementInterface("IComparable") ||
					RafCollection<T>.CollectedObjectImplementInterface("IComparable<>"))
				{
					this.Sort(new StandardComparison());
					_IsSorted = true;
					return;
				}
				throw new NotSupportedException("Sort without sort string need IComparable or IComparable<T>");
			}
			ApplySort(ParseSortingProps(SortString));
		}

		/// <summary>
		/// Default comparison class used when T implements IComparable o IComparable<T>
		/// </summary>
		private class StandardComparison : IComparer<T>
		{
			#region IComparer<T> Members
			int IComparer<T>.Compare(T x, T y)
			{
				if(x is IComparable)
					return ((IComparable)x).CompareTo(y);

				return ((IComparable<T>)x).CompareTo(y);
			}
			#endregion
		}

		/// <summary>
		/// Core sort function. All sorting function uses this method.
		/// If the ListSortDescriptionCollection are the same stored
		/// in the collection, the collection is sorted yet, 
		/// so it returns immediately
		/// </summary>
		/// <param name="sorts">List of SortDescription</param>
		public void ApplySort(ListSortDescriptionCollection sorts)
		{
			if(sorts == null)
				return;
			bool bMatch = false;
			if(_IsSorted && _SortDescriptions != null && _SortDescriptions.Count == sorts.Count)
			{
				bMatch = true;
				for(int i = 0; i < sorts.Count; i++)
				{
					ListSortDescription ldsSource = sorts[i];
					ListSortDescription ldsTarget = _SortDescriptions[i];

					if(ldsSource.PropertyDescriptor != ldsTarget.PropertyDescriptor ||
						ldsSource.SortDirection != ldsTarget.SortDirection)
					{
						bMatch = false;
						break;
					}
				}
			}
			// descriptors are the same of previous sort operation? just exit
			if(bMatch)
				return;

			_SortDescriptions = sorts;
			Sort(new DescriptorComparison(sorts));	// IComparer<T>
			_IsSorted = true;
		}

		/// <summary>
		/// Generic comparison class that uses reflection
		/// Given a ListSortDescriptionCollection, it can compare objects
		/// using IComparer(T)
		/// </summary>
		private class DescriptorComparison : IComparer<T>
		{
			private ListSortDescriptionCollection _Sorts;
			public DescriptorComparison(ListSortDescriptionCollection Sorts)
			{
				_Sorts = Sorts;
			}
			#region IComparer<T> Members
			int IComparer<T>.Compare(T x, T y)
			{
				foreach(ListSortDescription sort in _Sorts)
				{
					object vx = sort.PropertyDescriptor.GetValue(x);
					object vy = sort.PropertyDescriptor.GetValue(y);
					if(vx is IComparable)
					{
						int Result = ((IComparable)vx).CompareTo(vy) * (sort.SortDirection == ListSortDirection.Descending ? -1 : 1);
						if(Result == 0)
							continue;
						return Result;
					}
				}
				return 0;
			}
			#endregion
		}

		/// <summary>
		/// Not implemented
		/// TODO: this method could be usefult if we support the insert order
		/// Calling this method should order the collection using insert order
		/// Insert order is described in the doc
		/// </summary>
		public void RemoveSort()
		{
			//throw new Exception("The method or operation is not implemented.");
			//OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}

		/// <summary>
		/// Sorting is always supported
		/// </summary>
		public bool SupportsSorting
		{
			get { return true; }
		}

		/// <summary>
		/// Before sorting the collection, it's considered unsorted
		/// TODO: if we handle the sorting order, we can return always true
		/// or perhaps it could be better to return false to indicate the 
		/// sorting order
		/// </summary>
		public bool IsSorted
		{
			get { return _IsSorted; }
		}

		/// <summary>
		/// This mehods converts a sort string to a ListSortDescriptionCollection
		/// The sort string should have the form:
		/// property1, property2 ASC, property3 DESC, ...
		/// </summary>
		/// <param name="Filter">Sort string</param>
		/// <returns>ListSortDescriptionCollection</returns>
		private ListSortDescriptionCollection ParseSortingProps(string SortingProps)
		{
			if(SortingProps == null)
				throw new ArgumentException();
			try
			{
				PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(typeof(T));
				string[] Props = SortingProps.Split(',');
				ListSortDescription[] lsd = new ListSortDescription[Props.Length];
				for(int i = 0; i < Props.Length; i++)
				{
					string str = Props[i];

					string Temp = str.Trim().ToLower();
					ListSortDirection direction;
					if(Temp.EndsWith("desc"))
						direction = ListSortDirection.Descending;
					else
						direction = ListSortDirection.Ascending;
					string[] PropName = Temp.Split(' ');
					PropertyDescriptor pd = pdc.Find(PropName[0], true);

					lsd[i] = new ListSortDescription(pd, direction);
				}
				ListSortDescriptionCollection lsdc = new ListSortDescriptionCollection(lsd);
				return lsdc;
			}
			catch(Exception)
			{
				return null;
			}
		}

		/// <summary>
		/// This is only to satisfy IBindingList.SortDirection interface method
		/// SortDescriptions is better
		/// </summary>
		private ListSortDirection SortDirection
		{
			get
			{
				if(_SortDescriptions == null || _SortDescriptions.Count == 0)
					return ListSortDirection.Ascending;
				return _SortDescriptions[0].SortDirection;
			}
		}

		/// <summary>
		/// This is only to satisfy IBindingList.SortDirection interface method
		/// SortDescriptions is better
		/// </summary>
		private PropertyDescriptor SortProperty
		{
			get
			{
				if(_SortDescriptions == null || _SortDescriptions.Count == 0)
					return null;
				return _SortDescriptions[0].PropertyDescriptor;
			}
		}

		/// <summary>
		/// Return the ListSortDescriptionCollection of the current Sort
		/// </summary>
		public ListSortDescriptionCollection SortDescriptions
		{
			get { return _SortDescriptions; }
		}
		#endregion
	}
}
