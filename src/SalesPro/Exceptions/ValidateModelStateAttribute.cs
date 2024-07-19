using Microsoft.AspNetCore.Mvc.Filters;

namespace SalesPro.Exceptions
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                throw new InvalidModelStateException(context.ModelState);
            }
        }
    }
}