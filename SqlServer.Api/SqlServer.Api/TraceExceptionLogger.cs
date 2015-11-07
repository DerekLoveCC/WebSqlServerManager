using System.Web.Http.ExceptionHandling;

namespace SqlServer.Api
{
    public class TraceExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            Elmah.ErrorSignal.FromCurrentContext().Raise(context.Exception);
        }
    }
}