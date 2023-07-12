using TicTacToe.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace TicTacToe.Controllers;
public abstract class BaseController : ControllerBase
{
    protected BadRequestObjectResult FormErrorsRepsonse(List<ValidationFailure> validationErrors)
    {
        var errors = validationErrors.Aggregate(new Dictionary<string, List<string>>(), (acc, next) =>
        {
            if (acc.ContainsKey(next.PropertyName))
            {
                acc[next.PropertyName].Add(next.ErrorMessage);
            }
            else
            {
                acc.Add(next.PropertyName, new List<string> { next.ErrorMessage });
            }

            return acc;
        });

        return BadRequest(new FormErrorResponse(errors));
    }
}

