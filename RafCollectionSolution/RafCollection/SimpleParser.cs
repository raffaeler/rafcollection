// RafCollection, Copyright (c) 2006 Raffaele Rialdi
// Email: malta@vevy.com
// Italian blog: http://blogs.ugidotnet.org/raffaele
// English blog: http://msmvps.com/blogs/raffaele
// Project home: http://www.codeplex.com/RafCollection
// Documentation: look at the RafCollection.xps or RafColleciton.pdf document


// usage example
//
//SimpleParser Parser = new SimpleParser();
//SimpleParser.BooleanOperand expression;
//expression = Parser.Parse("(a>1) && (b<2 || (c>3 && d=5))");
//expression = Parser.Parse("(a>1 && b<2) || (c>3 && d=5)");
//expression = Parser.Parse("((a>1 && b<2 || c>3) && d=5");
//expression = Parser.Parse("a>1 && b<2 || c>3 && d=5");


using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;


namespace Vevy.Collections
{
	public class SimpleParser
	{
		public BooleanOperand Parse(string str)
		{
			Stack<ElementarExpressionString> st = new Stack<ElementarExpressionString>();
			BooleanOperand Left = null;
			ElementarExpressionString Current = new ElementarExpressionString();

			for(int i = 0; i < str.Length; i++)
			{
				if(str[i] == '(')
				{
					st.Push(Current);
					Current = new ElementarExpressionString();
					continue;
				}
				if(str[i] == ')')
				{
					ElementarExpressionString expr = st.Pop();

					string MaybeOperator = expr.Expression.Trim();
					if(MaybeOperator.Length == 2)	// operatore?
					{
						BooleanOperand exp = BooleanOperand.Create(Current.Expression);
						Left = new BooleanExpression(Left, MaybeOperator, exp);
						Current = new ElementarExpressionString();
						continue;
					}

					if(Current.Expression.Length > 0)
					{
						if(BooleanOperand.IsSimple(Current.Expression))
							continue;
						Left = BooleanOperand.Create(Current.Expression);
					}

					if(expr.Expression.Length > 0)
					{
						Left = new BooleanExpression(expr.Expression, Left);
					}

					Current = new ElementarExpressionString();
					continue;
				}
				Current.Append(str[i]);
			}

			if(Current.Expression.Length > 0)
			{
				Left = Build(Left, Current.Expression);
			}

			return Left;
		}

		internal BooleanOperand Build(BooleanOperand ParsedExp, string StringExp)
		{
			if(ParsedExp == null)
				return BooleanOperand.Create(StringExp);
			return new BooleanExpression(StringExp, ParsedExp);
		}



		internal class ElementarExpressionString
		{
			StringBuilder _Expression;
			public string Expression
			{
				get { return _Expression.ToString(); }
				set { _Expression = new StringBuilder(value); }
			}
			public ElementarExpressionString()
			{
				_Expression = new StringBuilder();
			}
			public ElementarExpressionString(string Expression)
			{
				_Expression = new StringBuilder(Expression);
			}
			public void Append(char c)
			{
				_Expression.Append(c);
			}
			public void Append(string s)
			{
				_Expression.Append(s);
			}

			public override string ToString()
			{
				return Expression.ToString();
			}
		}

		internal enum SimpleOperatorType
		{
			Equal,
			LesserEqual,
			Lesser,
			Greater,
			GreaterEqual
		}

		internal enum BooleanOperatorType
		{
			And,
			Or
		}

		public abstract class BooleanOperand
		{
			public abstract bool Eval(object obj);

			public static bool IsSimple(string ExpressionToEvaluate)
			{
				Regex re;
				Match m;
				re = new Regex(@"(?<exp1>.*)\s*(?<op>[&][&]|[|][|])\s*(?<exp2>.*)\s*");
				m = re.Match(ExpressionToEvaluate);
				if(m.Success)	// complex expression ==> a=1 && b>4
					return false;
				return true;
			}

			/// <summary>
			/// Create a SimpleExpression or a BooleanExpression based on the string that this method receive
			/// </summary>
			/// <param name="SimpleExpression"></param>
			/// <returns></returns>
			public static BooleanOperand Create(string ExpressionToEvaluate)
			{
				Regex re;
				Match m;
				re = new Regex(@"(?<exp1>.*)\s*(?<op>[&][&]|[|][|])\s*(?<exp2>.*)\s*");
				m = re.Match(ExpressionToEvaluate);
				if(m.Success)	// complex expression ==> a=1 && b>4
				{
					// exp2 is a simple expression for sure
					BooleanOperand exp2 = BooleanOperand.Create(m.Groups["exp2"].Value);
					BooleanOperatorType Operator = BooleanExpression.GetBooleanOperator(m.Groups["op"].Value);
					BooleanOperand exp1 = BooleanOperand.Create(m.Groups["exp1"].Value);

					BooleanExpression be = new BooleanExpression(exp1, Operator, exp2);

					return be;
				}

				// At this point it's a simple expression
				re = new Regex(@"(?:(?<left>\w+)\s*(?<op>[=]|[>]|[<]|[<][=]|[>][=])\s*(?<right>[\x22]?\w+[\x22]?))");
				m = re.Match(ExpressionToEvaluate);
				if(!m.Success)
					throw new Exception("Invalid SimpleExpression: " + ExpressionToEvaluate);

				string Property = m.Groups["left"].Value;
				string Value = m.Groups["right"].Value;
				SimpleOperatorType ExpressionOperator = SimpleExpression.GetExpressionOperator(m.Groups["op"].Value);

				SimpleExpression simple = new SimpleExpression(Property, ExpressionOperator, Value);
				return simple;
			}
		}

		internal class SimpleExpression : BooleanOperand
		{
			string _Property;
			public string Property
			{
				get { return _Property; }
				set { _Property = value; }
			}

			SimpleOperatorType _Operator;
			public SimpleOperatorType Operator
			{
				get { return _Operator; }
				set { _Operator = value; }
			}

			object _Value;
			public object Value
			{
				get { return _Value; }
				set { _Value = value; }
			}

			public SimpleExpression(string Property, SimpleOperatorType Operator, object Value)
			{
				_Property = Property;
				_Operator = Operator;
				_Value = Value;
			}

			public static SimpleOperatorType GetExpressionOperator(string str)
			{
				SimpleOperatorType Operator = SimpleOperatorType.Equal;

				switch(str)
				{
					case "=":
						Operator = SimpleOperatorType.Equal;
						break;
					case "<":
						Operator = SimpleOperatorType.Lesser;
						break;
					case ">":
						Operator = SimpleOperatorType.Greater;
						break;
					case "<=":
						Operator = SimpleOperatorType.LesserEqual;
						break;
					case ">=":
						Operator = SimpleOperatorType.GreaterEqual;
						break;
					default:
						throw new Exception("Invalid Operator: " + str);
				}
				return Operator;
			}

			public override bool Eval(object obj)
			{
				PropertyDescriptor pi = null;
				PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(obj);
				foreach(PropertyDescriptor pd in pdc)
				{
					if(pd.Name == Property)
					{
						pi = pd;
						break;
					}
				}
				if(pi == null)
					return false;

				object val = pi.GetValue(obj);
				if(!(val is IComparable))
					return false;

				object ConvertedValue = Convert.ChangeType(Value, pi.PropertyType);

				int Result = ((IComparable)val).CompareTo(ConvertedValue);
				switch(Result)
				{
					case 0:
						if(Operator == SimpleOperatorType.Equal || Operator == SimpleOperatorType.GreaterEqual || Operator == SimpleOperatorType.LesserEqual)
							return true;
						return false;
					case 1:
						if(Operator == SimpleOperatorType.Greater || Operator == SimpleOperatorType.GreaterEqual)
							return true;
						return false;
					case -1:
						if(Operator == SimpleOperatorType.Lesser || Operator == SimpleOperatorType.LesserEqual)
							return true;
						return false;
				}
				return false;
			}
			public override string ToString()
			{
				return string.Format("{0} {1} {2}", Property, Operator, Value);
			}
		}

		internal class BooleanExpression : BooleanOperand
		{
			BooleanOperand _Left;
			public BooleanOperand Left
			{
				get { return _Left; }
				set { _Left = value; }
			}
			BooleanOperand _Right;
			public BooleanOperand Right
			{
				get { return _Right; }
				set { _Right = value; }
			}
			BooleanOperatorType _BooleanOperator;
			public BooleanOperatorType BooleanOperator
			{
				get { return _BooleanOperator; }
				set { _BooleanOperator = value; }
			}

			public BooleanExpression(string Left, BooleanOperand Right)
			{
				Regex re = new Regex(@"(?:(?<exp>\S+)\s*(?<op>[&][&]|[|][|])\s*)|(?:(?<op>[&][&]|[|][|])\s*(?<exp>\S+)\s*)");
				Match m = re.Match(Left);
				if(!m.Success)
					throw new Exception("Invalid SimpleExpression: " + Left);

				//SimpleExpression exp = new SimpleExpression(m.Groups["exp"].Value);
				BooleanOperand exp = BooleanOperand.Create(m.Groups["exp"].Value);
				this.Left = exp;
				this.Right = Right;

				string op = m.Groups["op"].Value;
				BooleanOperator = BooleanExpression.GetBooleanOperator(op);
			}

			public BooleanExpression(BooleanOperand Left, BooleanOperatorType Operator, BooleanOperand Right)
			{
				_Left = Left;
				_BooleanOperator = Operator;
				_Right = Right;
			}

			public BooleanExpression(BooleanOperand Left, string Operator, BooleanOperand Right)
			{
				_Left = Left;
				_BooleanOperator = BooleanExpression.GetBooleanOperator(Operator);
				_Right = Right;
			}


			public static BooleanOperatorType GetBooleanOperator(string OperatorValue)
			{
				BooleanOperatorType Op = BooleanOperatorType.And;
				switch(OperatorValue)
				{
					case "&&":
						Op = BooleanOperatorType.And;
						break;
					case "||":
						Op = BooleanOperatorType.Or;
						break;
				}
				return Op;
			}
			public override bool Eval(object obj)
			{
				bool left = Left.Eval(obj);
				bool right = Right.Eval(obj);
				switch(BooleanOperator)
				{
					case BooleanOperatorType.And:
						return left && right;
					case BooleanOperatorType.Or:
						return left || right;
				}

				return false;
			}

			public override string ToString()
			{
				return string.Format("({0} {1} {2})", _Left, _BooleanOperator, _Right);
			}


		}

	}

	// Test class
	//public class T1
	//{
	//    int _FieldInt;
	//    public int FieldInt
	//    {
	//        get { return _FieldInt; }
	//        set { _FieldInt = value; }
	//    }
	//    string _FieldString;
	//    public string FieldString
	//    {
	//        get { return _FieldString; }
	//        set { _FieldString = value; }
	//    }

	//    public T1(int a, string b)
	//    {
	//        _FieldInt = a;
	//        _FieldString = b;
	//    }
	//}


		//private void Test()
		//{
		//    T1 obj = new T1(5, "Hello world");

		//    SimpleParser Parser = new SimpleParser();
		//    SimpleParser.BooleanOperand expression;
		//    expression = Parser.Parse("FieldString>=He");
		//    Console.WriteLine("{0}", expression.Eval(obj));

		//    expression = Parser.Parse("FieldString>=Ciao && FieldInt=5");
		//    Console.WriteLine("{0}", expression.Eval(obj));

		//    expression = Parser.Parse("FieldString=Ciao && FieldInt >10");
		//    Console.WriteLine("{0}", expression.Eval(obj));


		//    //SimpleExpression exp1 = new SimpleExpression("FieldString", SimpleOperatorType.GreaterEqual, "Ci");
		//    //SimpleExpression exp2 = new SimpleExpression("FieldInt", SimpleOperatorType.LessEqual, 10);
		//    //BooleanExpression expbool = new BooleanExpression(exp1, BooleanOperatorType.And, exp2);
		//    //bool b = expbool.Eval(obj);

		//    //Console.WriteLine("{0}", b);
		//}


}
