using FluentValidation;
using Newtonsoft.Json;
using ProdutosApp.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace ProdutosApp.API.Middlewares
{
    /// <summary>
    /// Middleware para tratamento de exceções do projeto ASP.NET
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Método para interceptar as requisições enviadas para o servidor
        /// e capturar as exceções provocadas pela requisição
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(ValidationException e)
            {
                await HandleValidationException(context, e);
            }
            catch (NaoEncontradoException e)
            {
                await HandleNaoEncontradoException(context, e);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        /// <summary>
        /// Método para fazer o tratamento dos erros do tipo ValidationException
        /// </summary>
        private static Task HandleValidationException(HttpContext context, ValidationException exception)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest; //HTTP 400
            context.Response.ContentType = "application/json";

            var errors = exception.Errors
                .Select(e => new
                {
                    Name = e.PropertyName, //nome do campo
                    Message = e.ErrorMessage, //mensagem de erro
                    Severity = e.Severity.ToString() //severidade
                });

            var response = new
            {
                Message = "Ocorreram erros de validação.",
                Status = context.Response.StatusCode,
                Errors = errors
            };

            var jsonResponse = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(jsonResponse);
        }

        /// <summary>
        /// Método para fazer o tratamento dos erros do tipo NaoEncontradoException
        /// </summary>
        private static Task HandleNaoEncontradoException(HttpContext context, NaoEncontradoException exception)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest; //HTTP 400
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = "Registro não encontrado.",
                Status = context.Response.StatusCode,
                Errors = exception.Message
            };

            var jsonResponse = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(jsonResponse);
        }

        /// <summary>
        /// Método para fazer o tratamento dos erros do tipo Exception
        /// </summary>
        private static Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //HTTP 500
            context.Response.ContentType = "application/json";

            var response = new
            {
                Message = "Falha interna ao executar a operação.",
                Status = context.Response.StatusCode
            };

            var jsonResponse = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
