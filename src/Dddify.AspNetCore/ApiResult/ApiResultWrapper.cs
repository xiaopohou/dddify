using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Dddify.AspNetCore.ApiResult
{
    public class ApiResultWrapper : IApiResultWrapper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiResultWrapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string TraceId => _httpContextAccessor.HttpContext.TraceIdentifier;

        public IApiResult Succeed() => new ApiResult
        {
            Success = true,
            Message = "ok",
            TraceId = TraceId
        };

        public IApiResult Succeed(string message) => new ApiResult
        {
            Success = true,
            Message = message,
            TraceId = TraceId
        };

        public IApiResult<T> Succeed<T>(T data) => new ApiResult<T>
        {
            Success = true,
            Data = data,
            Message = "ok",
            TraceId = TraceId
        };

        public IApiResult Failed(string message) => new ApiResult
        {
            Success = false,
            Message = message,
            TraceId = TraceId
        };

        public IApiResultWithError Failed(IDictionary<string, string[]> errors) => new ApiResultWithError
        {
            Success = false,
            Error = errors,
            TraceId = TraceId
        };
    }
}
