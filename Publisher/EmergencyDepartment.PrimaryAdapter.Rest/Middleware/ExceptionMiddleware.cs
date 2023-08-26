using EmergencyDepartment.Domain.Exceptions;
using System.Net;

namespace EmergencyDepartment.PrimaryAdapter.Rest.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next) 
        { 
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (PatientNotFoundException)
            {
                var response = context.Response;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                await response.CompleteAsync();
            }
            catch (EDException edEx) when (edEx is OutOfRangeException || edEx is ValueNotProvidedException)
            {
                var response = context.Response;
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                await response.CompleteAsync();
            }
            catch
            {
                var response = context.Response;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}