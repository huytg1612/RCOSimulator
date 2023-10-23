using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Services;
using System.Configuration;

namespace RCOSimilator.API.RCOAuthentication
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute() : base(typeof(ApiKeyAuthFilter))
        {
        }
    }

    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        IUnitOfWork _unitOfWork;
        public ApiKeyAuthFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var config = _unitOfWork.GetService<IConfiguration>();
            var token = context.HttpContext.Request.Headers[config.GetValue<string>("APIKey")].ToString();
            var service = _unitOfWork.GetService<LoginService>();
            if (!service.IsTokenValid(token))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
