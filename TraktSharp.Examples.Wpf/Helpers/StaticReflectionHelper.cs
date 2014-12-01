using System;
using System.Linq;
using System.Linq.Expressions;

namespace TraktSharp.Examples.Wpf.Helpers {

	// From http://joelabrahamsson.com/getting-property-and-method-names-using-static-reflection-in-c/

	public static class StaticReflectionHelper {

		public static string GetMemberName<T>(this T instance, Expression<Func<T, object>> expression, bool includeParameters = false) {
			return GetMemberName(expression, includeParameters);
		}

		public static string GetMemberName<T>(Expression<Func<T, object>> expression, bool includeParameters = false) {
			if (expression == null) { throw new ArgumentException("The expression cannot be null."); }
			return GetMemberName(expression.Body, includeParameters);
		}

		public static string GetMemberName<T>(this T instance, Expression<Action<T>> expression, bool includeParameters = false) {
			return GetMemberName(expression, includeParameters);
		}

		public static string GetMemberName<T>(Expression<Action<T>> expression, bool includeParameters = false) {
			if (expression == null) { throw new ArgumentException("The expression cannot be null."); }
			return GetMemberName(expression.Body, includeParameters);
		}

		private static string GetMemberName(Expression expression, bool includeParameters = false) {
			if (expression == null) { throw new ArgumentException("The expression cannot be null."); }
			var memberExpression = expression as MemberExpression;
			if (memberExpression != null) {
				return memberExpression.Member.Name;
			}
			var methodCallExpression = expression as MethodCallExpression;
			if (methodCallExpression != null) {
				var ret = methodCallExpression.Method.Name;
				if (includeParameters) {
					ret += string.Format("({0})", string.Join(", ", methodCallExpression.Method.GetParameters().Select(p => p.Name).ToList()));
					return ret;
				}
			}
			var unaryExpression = expression as UnaryExpression;
			if (unaryExpression != null) { return GetMemberName(unaryExpression); }
			throw new ArgumentException("Invalid expression");
		}

		private static string GetMemberName(UnaryExpression unaryExpression) {
			var methodExpression = unaryExpression.Operand as MethodCallExpression;
			return methodExpression != null ? methodExpression.Method.Name : ((MemberExpression)unaryExpression.Operand).Member.Name;
		}

	}

}