﻿using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using BaseLib.WebApi;
using Ayo.Core;

namespace Ayo.API.Filters
{
    /// <summary>
    /// 全局的错误响应消息处理
    /// </summary>
    public class GlobalExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public GlobalExceptionFilter()
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                //处理包装ModelState
                Dictionary<string, IEnumerable<string>> modelStateErrors = new Dictionary<string, IEnumerable<string>>();
                foreach (var state in context.ModelState)
                {
                    string key = state.Key;
                    var errors = state.Value.Errors;
                    if (errors != null && errors.Count > 0)
                    {
                        IEnumerable<string> errorMessages = errors.Select(error =>
                        {
                            return error.Exception != null ? error.Exception.Message : (String.IsNullOrEmpty(error.ErrorMessage) ? "An error has occurred " : error.ErrorMessage);
                        });
                        if (errorMessages.Count() > 0)
                        {
                            modelStateErrors.Add(key, errorMessages);
                        }
                    }
                    BaseLibResponse<Dictionary<string, IEnumerable<string>>> response = new BaseLibResponse<Dictionary<string, IEnumerable<string>>>();
                    response.SetMessage(BizError.PARAMTER_VALIDATION_ERROR.ErrCode.ToString(), BizError.PARAMTER_VALIDATION_ERROR.ErrMessage);
                    response.Result = modelStateErrors;
                    context.Result = new ObjectResult(response)
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                    };
                }
            }
        }

        //继承IActionFilter
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is BizException bizException)
            {
                context.Result = new ObjectResult(bizException.CommonError)
                {
                    StatusCode = 200,
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is Exception exception)
            {
                BaseLibResponse response = new BaseLibResponse();
                response.SetMessage(BizError.UNKNOWN_ERROR.ErrCode.ToString(), exception.Message);
                context.Result = new ObjectResult(response)
                {
                    StatusCode = 200,
                };
                LogError(exception, context.HttpContext);
                context.ExceptionHandled = true;
            }
        }

        private void LogError(Exception ex, HttpContext context)
        {
            var logger = BaseLib.BaseLibEngine.Instance.Resolve<ILogger>();
            var req = context.Request;
            var url = req.GetAbsoluteUri();
            if (context != null && context.Request != null)
            {
                GlobalExceptionDto error = new GlobalExceptionDto()
                {
                    Method = req.Method.ToString().ToUpper(),
                    Url = url,
                    QueryString = req.QueryString.ToString(),
                    Body = "",
                    ClientIp = context.GetClientIp(),
                    Exception = ex.StackTrace?.ToString()
                };

                try
                {
                    req.EnableBuffering();
                    using (var mem = new MemoryStream())
                    using (var reader = new StreamReader(mem))
                    {
                        context.Request.Body.CopyTo(mem);
                        mem.Seek(0, SeekOrigin.Begin);
                        error.Body = reader.ReadToEnd();
                    }
                    context.Request.Body.Position = 0;
                }
                catch
                {
                }

                logger.Error(error.SerializeToJson());
            }
        }
    }
}