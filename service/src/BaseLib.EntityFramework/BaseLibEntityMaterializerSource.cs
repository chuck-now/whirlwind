using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BaseLib.Reflection;
using BaseLib.Timing;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace BaseLib.EntityFramework
{
    /// <summary>
    /// BaseLibEntityMaterializerSource
    /// </summary>
    public class BaseLibEntityMaterializerSource : EntityMaterializerSource
    {
        private static readonly MethodInfo NormalizeDateTimeMethod =
           typeof(BaseLibEntityMaterializerSource).GetTypeInfo().GetMethod(nameof(NormalizeDateTime), BindingFlags.Static | BindingFlags.NonPublic);

        private static readonly MethodInfo NormalizeNullableDateTimeMethod =
            typeof(BaseLibEntityMaterializerSource).GetTypeInfo().GetMethod(nameof(NormalizeNullableDateTime), BindingFlags.Static | BindingFlags.NonPublic);

        public override Expression CreateReadValueExpression(Expression valueBuffer, Type type, int index, IPropertyBase propertyBase)
        {
            if (ShouldDisableDateTimeNormalization(propertyBase))
            {
                return base.CreateReadValueExpression(valueBuffer, type, index, propertyBase);
            }

            if (type == typeof(DateTime))
            {
                return Expression.Call(
                    NormalizeDateTimeMethod,
                    base.CreateReadValueExpression(valueBuffer, type, index, propertyBase)
                );
            }

            if (type == typeof(DateTime?))
            {
                return Expression.Call(
                    NormalizeNullableDateTimeMethod,
                    base.CreateReadValueExpression(valueBuffer, type, index, propertyBase)
                );
            }

            return base.CreateReadValueExpression(valueBuffer, type, index, propertyBase);
        }

        private static DateTime NormalizeDateTime(DateTime value)
        {
            return value;
        }

        private static DateTime? NormalizeNullableDateTime(DateTime? value)
        {
            if (value == null)
            {
                return null;
            }

            return value.Value;
        }

        private static bool ShouldDisableDateTimeNormalization(IPropertyBase propertyBase)
        {
            if (propertyBase == null)
            {
                return false;
            }

            if (propertyBase.PropertyInfo == null)
            {
                return false;
            }

            if (propertyBase.PropertyInfo.IsDefined(typeof(DisableDateTimeNormalizationAttribute), true))
            {
                return true;
            }

            propertyBase.TryGetMemberInfo(false, false, out var memberInfo, out _);
            return ReflectionHelper.GetSingleAttributeOfMemberOrDeclaringTypeOrDefault<DisableDateTimeNormalizationAttribute>(memberInfo) != null;
        }
    }
}