using Application.Users;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SharedKernel.Errors;
using System.Net;

namespace WebApi.Extensions;

public static class ResultExtensions
{
    public static IResult ToActionResult<TEntity, TError>(
        this Result<TEntity, TError> result) =>
            result.Match(
                success => Results.Ok(success),
                failure => failure switch
                    {
                        Error error when error.StatusCode == (int)HttpStatusCode.BadRequest => Results.BadRequest(failure),
                        Error error when error.StatusCode == (int)HttpStatusCode.NotFound => Results.NotFound(failure),
                        Error error when error.StatusCode == (int)HttpStatusCode.Unauthorized => Results.Unauthorized(),
                        Error error when error.StatusCode == (int)HttpStatusCode.Forbidden => Results.Forbid(),
                        Error error when error.StatusCode == (int)HttpStatusCode.Conflict => Results.Conflict(failure),
                        Error error when error.StatusCode == (int)HttpStatusCode.UnsupportedMediaType => Results.StatusCode((int)HttpStatusCode.UnsupportedMediaType),
                        Error error when error.StatusCode == (int)HttpStatusCode.Locked => Results.StatusCode((int)HttpStatusCode.Locked),
                        _ => Results.Problem()
                    });
}
