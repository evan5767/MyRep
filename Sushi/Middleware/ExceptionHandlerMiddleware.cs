using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;

namespace Sushi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Логирование исключения или другая обработка ошибки
                Console.WriteLine($"Произошла ошибка: {ex.Message}");

                // Например, можно отправить пользователю сообщение об ошибке
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Log in to use the shopping cart");
            }
        }
    }
}
