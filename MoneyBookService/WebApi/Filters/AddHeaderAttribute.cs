using Microsoft.AspNetCore.Mvc.Filters;

namespace MoneyBookService.WebApi.Filters
{
    // https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1
    public class AddHeaderAttribute : ResultFilterAttribute
    {
        private readonly string name_;
        private readonly string value_;

        public AddHeaderAttribute(string name, string value)
        {
            name_ = name;
            value_ = value;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers[name_] = new[] { value_ };
            base.OnResultExecuting(context);
        }
    }
}
