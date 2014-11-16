using System;
using System.Linq;
using System.Linq.Expressions;

namespace TraktSharp.Examples.Helpers {

	/// <summary>
	/// From http://joelabrahamsson.com/getting-property-and-method-names-using-static-reflection-in-c/
	/// </summary>
	public static class StaticReflectionHelper {

		public static string GetMemberName<T>(this T instance, Expression<Func<T, object>> expression) { return GetMemberName(expression); }

		internal static string GetMemberName<T>(
			Expression<Func<T, object>> expression) {
			if (expression == null) { throw new ArgumentException("The expression cannot be null."); }
			return GetMemberName(expression.Body);
		}

		internal static string GetMemberName<T>(this T instance, Expression<Action<T>> expression) { return GetMemberName(expression); }

		internal static string GetMemberName<T>(Expression<Action<T>> expression) {
			if (expression == null) { throw new ArgumentException("The expression cannot be null."); }
			return GetMemberName(expression.Body);
		}

		private static string GetMemberName(Expression expression) {
			if (expression == null) { throw new ArgumentException("The expression cannot be null."); }
			if (expression is MemberExpression) { 
				var memberExpression = (MemberExpression)expression;
				return memberExpression.Member.Name;
			}
			if (expression is MethodCallExpression) {
				var methodCallExpression = (MethodCallExpression)expression;
				return methodCallExpression.Method.Name;
			}
			if (expression is UnaryExpression) {
				var unaryExpression = (UnaryExpression)expression;
				return GetMemberName(unaryExpression);
			}
			throw new ArgumentException("Invalid expression");
		}

		private static string GetMemberName(UnaryExpression unaryExpression) {
			if (unaryExpression.Operand is MethodCallExpression) {
				var methodExpression = (MethodCallExpression)unaryExpression.Operand;
				return methodExpression.Method.Name;
			}
			return ((MemberExpression)unaryExpression.Operand).Member.Name;
		}

	}

}