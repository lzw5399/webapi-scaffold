using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Core.Filters
{
    public class GlobalExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
            Order = 2;
        }

        public void OnException(ExceptionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
