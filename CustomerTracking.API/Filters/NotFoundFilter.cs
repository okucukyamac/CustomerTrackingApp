using CustomerTracking.Core.Models.Entities;
using CustomerTracking.Core.Models.Results;
using CustomerTracking.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomerTracking.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(a=>a.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponse<NoContent>.Fail(404, $"{typeof(T).Name} ({id}) not found"));

        }

    }
}
