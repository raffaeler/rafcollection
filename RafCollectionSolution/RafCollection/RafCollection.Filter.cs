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
		#region Filter
		/// <summary>
		/// Set a filter on the collection
		/// string.Empty remove the filter
		/// </summary>
		public string Filter
		{
			get { return _Filter; }
			set
			{
				_Filter = value;
				_CustomFilter = null;

				RecalcFilter(true);
				OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
			}
		}

		/// <summary>
		/// Set a filter on a collection based on a custom delegate
		/// </summary>
		/// <param name="CustomChoice"></param>
		public void SetCustomFilter(CustomChoiceDelegate<T> CustomChoice)
		{
			_Filter = string.Empty;
			_CustomFilter = CustomChoice;

			RecalcFilter(true);
			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
		}

		/// <summary>
		/// Recalculate the filter
		/// </summary>
		private void RecalcFilter(bool bForce)
		{
			FilterSortCreator<T> filter;
			if(!bForce)
			{
				if((_Filter == null || _Filter.Length == 0) && _CustomFilter == null)
					return;

				// When we are here is because the state of a single element has been modified
				// So it's sufficient to recalculate only the visibility of this item instead of all the items
				// Then we recalculate the invisible count
				if(_CustomFilter != null)
					filter = new FilterSortCreator<T>(_CustomFilter);
				else
					filter = new FilterSortCreator<T>(_Filter);
				_CurrentStorageElement.Visible = filter.IsVisible(_CurrentStorageElement.Storage.CollectedObject);
				return;
			}

			try
			{
				if(_CustomFilter != null)
					filter = new FilterSortCreator<T>(_CustomFilter);
				else
					filter = new FilterSortCreator<T>(_Filter);

				for(int j = 0; j < _ArrayCount; j++)
				{
					Box<T> Elem = BaseArray[j];
					Elem.Visible = filter.IsVisible(Elem.Storage.CollectedObject);
				}
			}
			catch(Exception)
			{
				Filter = string.Empty;
				return;
			}
			CalculateInvisibleCount();
		}
		#endregion

	}
}
