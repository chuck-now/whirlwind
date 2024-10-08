﻿using System;
using System.Linq;
using System.Reflection;

namespace BaseLib.Domain.Uow
{
    /// <summary>
    /// UnitOfWorkDefaultOptionsExtensions
    /// </summary>
    internal static class UnitOfWorkDefaultOptionsExtensions
    {
        public static UnitOfWorkAttribute GetUnitOfWorkAttributeOrNull(this IUnitOfWorkDefaultOptions unitOfWorkDefaultOptions, MethodInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(true).OfType<UnitOfWorkAttribute>().ToArray();
            if (attrs.Length > 0)
            {
                return attrs[0];
            }

            attrs = methodInfo.DeclaringType.GetTypeInfo().GetCustomAttributes(true).OfType<UnitOfWorkAttribute>().ToArray();
            if (attrs.Length > 0)
            {
                return attrs[0];
            }

            if (unitOfWorkDefaultOptions.IsConventionalUowClass(methodInfo.DeclaringType))
            {
                return new UnitOfWorkAttribute();
            }

            return null;
        }

        public static bool IsConventionalUowClass(this IUnitOfWorkDefaultOptions unitOfWorkDefaultOptions, Type type)
        {
            return unitOfWorkDefaultOptions.ConventionalUowSelectors.Any(selector => selector(type));
        }
    }
}