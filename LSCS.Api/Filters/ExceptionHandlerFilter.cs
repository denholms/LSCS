﻿using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using log4net;
using LSCS.Api.Exceptions;

namespace LSCS.Api.Filters
{
    public sealed class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (ExceptionHandlerFilter));

        public override void OnException(HttpActionExecutedContext context)
        {
            // 404 Error Code
            if (context.Exception is DocumentNotFoundException)
            {
                context.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent(String.Format(CultureInfo.InvariantCulture,
                        "The resource at \"{0}\" does not exist.", context.Request.RequestUri.AbsoluteUri))
                };
                return;
            }

            // 400 Error Code
            if (context.Exception is InvalidQueryException)
            {
                context.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(context.Exception.Message)
                };
                return;
            }

            // 500 Error Code
            Log.Error("The server encountered an unhandled exception.", context.Exception);
            context.Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new StringContent("The server encountered an unexpected error.")
            };
        }
    }
}