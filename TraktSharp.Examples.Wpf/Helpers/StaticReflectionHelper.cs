using System;
using System.Linq;
using System.Linq.Expressions;

namespace TraktSharp.Examples.Wpf.Helpers {

	// Adapted from http://joelabrahamsson.com/getting-property-and-method-names-using-static-reflection-in-c/

	internal static class StaticReflectionHelper {

		internal static string GetMemberName<T>(this T instance, Expression<Func<T, object>> expression, bool includeParameters = false)
			=> GetMemberName(expression, includeParameters);

		internal static string GetMemberName<T>(Expression<Func<T, object>> expression, bool includeParameters = false) {
			if (expression == null) { throw new ArgumentException("The expression cannot be null."); }
			return GetMemberName(expression.Body, includeParameters);
		}

		internal static string GetMemberName<T>(this T instance, Expression<Action<T>> expression, bool includeParameters = false)
			=> GetMemberName(expression, includeParameters);

		internal static string GetMemberName<T>(Expression<Action<T>> expression, bool includeParameters = false) {
			if (expression == null) { throw new ArgumentException("The expression cannot be null."); }
			return GetMemberName(expression.Body, includeParameters);
		}

		private static string GetMemberName(Expression expression, bool includeParameters = false) {
			if (expression == null) { throw new ArgumentException("The expression cannot be null."); }
			if (expression is MemberExpression memberExpression) {
				return memberExpression.Member.Name;
			}
			if (expression is MethodCallExpression methodCallExpression) {
				var ret = methodCallExpression.Method.Name;
				if (includeParameters) {
					ret += $"({string.Join(", ", methodCallExpression.Method.GetParameters().Select(p => p.Name).ToList())})";
					return ret;
				}
			}
			if (expression is UnaryExpression unaryExpression) { return GetMemberName(unaryExpression); }
			throw new ArgumentException("Invalid expression");
		}

		private static string GetMemberName(UnaryExpression unaryExpression) =>
			unaryExpression.Operand is MethodCallExpression methodExpression
				? methodExpression.Method.Name
				: ((MemberExpression)unaryExpression.Operand).Member.Name;

	}

}