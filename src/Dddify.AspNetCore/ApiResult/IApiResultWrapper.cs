using System.Collections.Generic;

namespace Dddify.AspNetCore.ApiResult;

public interface IApiResultWrapper
{
    IApiResult Succeed();
    IApiResult Succeed(string message);
    IApiResult<T> Succeed<T>(T data);
    IApiResult Failed(string message);
    IApiResultWithError Failed(IDictionary<string, string[]> errors);
}
