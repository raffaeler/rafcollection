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
using System.Runtime.Serialization;

// This is the DataSet types used to manage Row State, version and filter
//
//public enum DataRowState
//{
//    Detached = 1,					// 0000'0001	// non lo uso
//    Unchanged = 2,				// 0000'0010	// Normal
//    Added = 4,					// 0000'0100	// Added
//    Deleted = 8,					// 0000'1000	// Deleted
//    Modified = 0x10,				// 0001'0000	// Modified
//}

//public enum DataViewRowState
//{
//    None = 0,						// 0000'0000
//    Unchanged = 2,				// 0000'0010	// idem
//    Added = 4,					// 0000'0100	// idem
//    Deleted = 8,					// 0000'1000	// idem
//    ModifiedCurrent = 0x10,		// 0001'0000	// idem
//    CurrentRows = 0x16,			// 0001'0110	// unchanged + added + modifiedcurrent

//    ModifiedOriginal = 0x20,		// 0010'0000	// la versione originale di quelle che sono state modificate
//    OriginalRows = 0x2a,			// 0010'1010	// unchanged + deleted + modifiedoriginal
//}

//public enum DataRowVersion
//{
//    Original = 0x100,				// 0000'0001.0000'0000
//    Current = 0x200,				// 0000'0010.0000'0000
//    Proposed = 0x400				// 0000'0100.0000'0000
//    Default = 0x600,				// 0000'0110.0000'0000
//}



namespace Vevy.Collections
{

	public enum ObjectStatusType	// analog to DataSet DataRowState
	{
		Normal = 2,
		Added = 4,
		Deleted = 8,
		Modified = 0x10,
		PendingAdded = 0x40,
		// Detached					// I am not interested in Detached entities
	}

	[Flags]
	public enum ObjectStateFilter	// analog to DataSet DataRowVersion
	{
		//NoFilter = 0,				// No filter
		Normal = 2,					// not modified at all
		Inserted = 4,				// inserted
		Deleted = 8,				// deleted
		Updated = 0x10,				// modified
		Current = 0x16,				// normal + inserted + updated (no deleted)
		CurrentAll = 0x1E,			// normal + inserted + updated + deleted
		OriginalModified = 0x20,	// original version of the modified entities
		OriginalAll = 0x2a,			// original version of the (modified + deleted + unchanged) entities
		//Custom,		// custom filter via delegate
	}

	#region INotifyPropertyChanging is not used (see Doc)

	//public interface INotifyPropertyChanging
	//{
	//    event PropertyChangingEventHandler PropertyChanging;
	//}

	//public delegate void PropertyChangingEventHandler(object sender, PropertyChangingEventArgs e);

	//public class PropertyChangingEventArgs : EventArgs
	//{
	//    private readonly string _PropertyName;
	//    public PropertyChangingEventArgs(string PropertyName)
	//    {
	//        _PropertyName = PropertyName;
	//    }

	//    public virtual string PropertyName
	//    {
	//        get{return _PropertyName;}
	//    }
	//}

	#endregion


	/// <summary>
	/// Delegate used to filter entities
	/// </summary>
	/// <typeparam name="T">Entity type</typeparam>
	/// <param name="Item">Entity to evaluate for filter</param>
	/// <returns>true for visible, false for invisible</returns>
	public delegate bool CustomChoiceDelegate<T>(T Item);


	internal class FilterSortCreator<T> //: IComparer, IComparer<T>
	{
		private string _Filter;
		private CustomChoiceDelegate<T> _CustomChoice;

		// maybe this class can be used for sorting too
		//private string _Sort;

		/// <summary>
		/// Constructor used to filter by string
		/// Can be used with the parser or by building an assembly with codedom
		/// </summary>
		/// <param name="Filter"></param>
		public FilterSortCreator(string Filter)
		{
			_Filter = Filter;
			//_CustomChoice = BuildAssembly();
		}

		/// <summary>
		/// Filtering will be done using this custom delegate
		/// </summary>
		/// <param name="CustomChoice"></param>
		public FilterSortCreator(CustomChoiceDelegate<T> CustomChoice)
		{
			_Filter = string.Empty;
			_CustomChoice = CustomChoice;
		}

		/// <summary>
		/// Get the delegate used to filter entities
		/// </summary>
		public CustomChoiceDelegate<T> CustomChoice
		{
			get { return _CustomChoice; }
		}

		/// <summary>
		/// Build an assembly via CodeDom?
		/// </summary>
		private CustomChoiceDelegate<T> BuildAssembly()
		{
			// codedom etc. ...
			return null;
		}

		/// <summary>
		/// Decide if the entity is visible (not filtered) or not
		/// </summary>
		/// <param name="Item">Item to evaluate</param>
		/// <returns>true for visible, false for invisible</returns>
		public bool IsVisible(T Item)
		{
			// if a delegate is valorized, use it
			if(CustomChoice != null)
				return CustomChoice(Item);

			// if no filter is set, always return true (no filter is applied)
			if(_Filter == null || _Filter.Length == 0)
				return true;

			// use the parser to evaluate the string
			return GenericFilter(Item);
		}

		/// <summary>
		/// Analyze simple expression of this kind:
		/// PropertyName [Operator] Value && || ...
		/// Where [Operator] is the symbol for Lesser, LesserEqual, Equal, Greater or GreaterEqual
		/// </summary>
		/// <param name="Item"></param>
		/// <returns></returns>
		private bool GenericFilter(T Item)
		{
			SimpleParser Parser = new SimpleParser();
			SimpleParser.BooleanOperand Expression;
			Expression = Parser.Parse(_Filter);
			return Expression.Eval(Item);
		}

	}

}
