﻿using System;
using System.Reflection;
using System.Threading.Tasks;

namespace BaseLib
{
    /// <summary>
    /// InternalAsyncHelper
    /// </summary>
    internal static class InternalAsyncHelper
    {
        public static async Task AwaitTaskWithFinally(Task actualReturnValue, Action<Exception> finalAction)
        {
            Exception exception = null;

            try
            {
                await actualReturnValue;
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction(exception);
            }
        }

        public static async Task AwaitTaskWithPostActionAndFinally(Task actualReturnValue, Func<Task> postAction, Action<Exception> finalAction)
        {
            Exception exception = null;
            try
            {
                await actualReturnValue;
                await postAction();
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction(exception);
            }
        }

        public static async Task AwaitTaskWithPreActionAndPostActionAndFinally(Func<Task> actualReturnValue, Func<Task> preAction = null, Func<Task> postAction = null, Action<Exception> finalAction = null)
        {
            Exception exception = null;
            try
            {
                if (preAction != null)
                {
                    await preAction();
                }
                await actualReturnValue();
                if (postAction != null)
                {
                    await postAction();
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction?.Invoke(exception);
            }
        }

        public static async Task<T> AwaitTaskWithFinallyAndGetResult<T>(Task<T> actualReturnValue, Action<Exception> finalAction)
        {
            Exception exception = null;
            try
            {
                return await actualReturnValue;
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction(exception);
            }
        }

        public static object CallAwaitTaskWithFinallyAndGetResult(Type taskReturnType, object actualReturnValue, Action<Exception> finalAction)
        {
            return typeof(InternalAsyncHelper).GetMethod("AwaitTaskWithFinallyAndGetResult", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(taskReturnType).Invoke(null, new object[2]
            {
            actualReturnValue,
            finalAction
            });
        }

        public static async Task<T> AwaitTaskWithPostActionAndFinallyAndGetResult<T>(Task<T> actualReturnValue, Func<Task> postAction, Action<Exception> finalAction)
        {
            Exception exception = null;
            try
            {
                T result = await actualReturnValue;
                await postAction();
                return result;
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction(exception);
            }
        }

        public static object CallAwaitTaskWithPostActionAndFinallyAndGetResult(Type taskReturnType, object actualReturnValue, Func<Task> action, Action<Exception> finalAction)
        {
            return typeof(InternalAsyncHelper).GetMethod("AwaitTaskWithPostActionAndFinallyAndGetResult", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(taskReturnType).Invoke(null, new object[3]
            {
            actualReturnValue,
            action,
            finalAction
            });
        }

        public static async Task<T> AwaitTaskWithPreActionAndPostActionAndFinallyAndGetResult<T>(Func<Task<T>> actualReturnValue, Func<Task> preAction = null, Func<Task> postAction = null, Action<Exception> finalAction = null)
        {
            Exception exception = null;
            try
            {
                if (preAction != null)
                {
                    await preAction();
                }
                T result = await actualReturnValue();
                if (postAction != null)
                {
                    await postAction();
                }
                return result;
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction?.Invoke(exception);
            }
        }

        public static object CallAwaitTaskWithPreActionAndPostActionAndFinallyAndGetResult(Type taskReturnType, Func<object> actualReturnValue, Func<Task> preAction = null, Func<Task> postAction = null, Action<Exception> finalAction = null)
        {
            return typeof(InternalAsyncHelper).GetMethod("AwaitTaskWithPreActionAndPostActionAndFinallyAndGetResult", BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(taskReturnType).Invoke(null, new object[4]
            {
            actualReturnValue,
            preAction,
            postAction,
            finalAction
            });
        }
    }
}