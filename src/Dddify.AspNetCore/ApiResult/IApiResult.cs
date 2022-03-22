using System.Collections.Generic;

namespace Dddify.AspNetCore.ApiResult
{
    public interface IApiResult
    {
        /// <summary>
        /// If request is success.
        /// </summary>
        bool Success { get; set; }

        /// <summary>
        /// The message display to user.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// The unique request ID.
        /// </summary>
        string TraceId { get; set; }
    }

    public interface IApiResult<T> : IApiResult
    {
        /// <summary>
        /// The bussiness data.
        /// </summary>
        T Data { get; set; }
    }

    public interface IApiResultWithError : IApiResult
    {
        /// <summary>
        /// The errors of validation failures.
        /// </summary>
        IDictionary<string, string[]> Error { get; set; }
    }
}
