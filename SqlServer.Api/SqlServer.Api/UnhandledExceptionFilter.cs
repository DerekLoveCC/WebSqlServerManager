using System.Web;
using System.Web.Http.Filters;

namespace SqlServer.Api
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(actionExecutedContext.Exception);
        }
    }
}