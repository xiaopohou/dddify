using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Dddify.DependencyInjection;

namespace Dddify.AspNetCore.ApiResult
{
    public class ApiResultFilter : IResultFilter
    {
        private readonly IApiResultWrapper _apiResultWrapper;

        public ApiResultFilter(IApiResultWrapper apiResultWrapper)
        {
            _apiResultWrapper = apiResultWrapper;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var disableApiResultWrapper = context.ActionDescriptor.HasAttrbute<NonWrapApiResultAttribute>();

            if (!disableApiResultWrapper)
            {
                context.Result = context.Result switch
                {
                    ObjectResult objectResult => new ObjectResult(_apiResultWrapper.Succeed(objectResult.Value)),
                    _ => new ObjectResult(_apiResultWrapper.Succeed()),
                };
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // do nothing.
        }
    }
}
