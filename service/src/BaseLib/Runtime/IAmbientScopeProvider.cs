﻿using System;

namespace BaseLib.Runtime
{
    /// <summary>
    /// IAmbientScopeProvider
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAmbientScopeProvider<T>
    {
        T GetValue(string contextKey);

        IDisposable BeginScope(string contextKey, T value);
    }
}