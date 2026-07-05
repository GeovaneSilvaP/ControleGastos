using System.Text.Json;
using BackEnd.src.Exceptions;

namespace BackEnd.src.Middlewares;

/// <summary>
/// Middleware responsável por capturar exceções não tratadas
/// e retornar uma resposta padronizada.
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    /// <summary>
    /// Construtor do middleware.
    /// </summary>
    /// <param name="next">Próximo middleware da pipeline.</param>
    /// <param name="logger">Serviço de logs.</param>
    public ExceptionMiddleware(
        RequestDelegate next,
        ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Executa o middleware.
    /// </summary>
    /// <param name="context">Contexto da requisição HTTP.</param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Continua a execução da pipeline
            await _next(context);
        }
        catch (AppException ex)
        {
            _logger.LogWarning(ex, "Erro de negócio: {Mensagem}", ex.Message);

            await HandleExceptionAsync(
                context,
                ex.StatusCode,
                ex.Message
            );
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro interno não tratado.");

            await HandleExceptionAsync(
                context,
                StatusCodes.Status500InternalServerError,
                "Ocorreu um erro interno no servidor."
            );
        }
    }

    /// <summary>
    /// Cria uma resposta JSON padronizada para exceções.
    /// </summary>
    private static async Task HandleExceptionAsync(
        HttpContext context,
        int statusCode,
        string message)
    {
        context.Response.Clear();
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        var response = new
        {
            sucesso = false,
            mensagem = message,
            status = statusCode
        };

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}