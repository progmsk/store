using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace Store.Web
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ExceptionFilter(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            if (webHostEnvironment.IsDevelopment())
                return;

            if (context.Exception.TargetSite.Name == "ThrowNoElementsException")
            {
                context.Result = new ViewResult
                {
                    ViewName = "NotFound",
                    StatusCode = 404,
                };
            }
        }
    }
}
