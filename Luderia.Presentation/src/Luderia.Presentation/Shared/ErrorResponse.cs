using Microsoft.AspNetCore.Mvc;

namespace Luderia.Presentation.Shared;

public static class ErrorResponseFormatter
{
    public static ProblemDetails ToProblemDetais(this Result result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException("Cannot create a problem details from a successful result");

        if (result.Error is DomainError domainError)
        {
            var detail = domainError.Message;
            var type = domainError.Type;
            var title = domainError.Title;

            return new ProblemDetails
            {
                Title = title,
                Detail = detail,
                Status = 400,
                Type = type,
            };
        }

        return new ProblemDetails
        {
            Title = "An error occurred",
            Detail = "An internal error occurred",
            Status = 500,
            Type = "https://httpstatuses.com/500",
        };
    }

    public static ProblemDetails ToProblemDetais<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException("Cannot create a problem details from a successful result");

        var temp = Result.Failure(result.Error!);

        return ToProblemDetais(temp);

    }

    public static ObjectResult ProblemResponse(this ControllerBase controller, Result result)
    {
        var problem = result.ToProblemDetais();
        return controller.Problem(problem.Detail, problem.Instance, problem.Status, problem.Title, problem.Type);
    }

    public static ObjectResult ProblemResponse<T>(this ControllerBase controller, Result<T> result)
    {
        var problem = result.ToProblemDetais();
        return controller.Problem(problem.Detail, problem.Instance, problem.Status, problem.Title, problem.Type);
    }
}
