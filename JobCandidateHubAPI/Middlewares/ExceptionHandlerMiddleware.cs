using JobCandidateHubAPI.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace JobCandidateHubAPI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next.Invoke(context);
            }
            catch (HttpStatusCodeException ex)
            {
                await this.HandleException(context, ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                //Log
                logger.LogError(ex.ToString());

                await this.HandleException(context, 500, ex.Message);
            }
        }

        public async Task HandleException(HttpContext context, int code, string message)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = code,
                Message = message
            });
        }
    }
}
