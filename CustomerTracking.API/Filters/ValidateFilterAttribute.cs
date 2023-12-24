using CustomerTracking.Core.Models.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerTracking.API.Filters
{
    public class ValidateFilterAttribute:ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(a => a.Errors).Select(a=>a.ErrorMessage).ToList();


                context.Result = new BadRequestObjectResult(CustomResponse<NoContent>.Fail(400, errors));

            }
        }
    }
}
