namespace BackEnd.src.Exceptions;

/// <summary>
/// Representa uma exceção de negócio da aplicação.
/// Permite informar uma mensagem amigável e o código HTTP
/// que deverá ser retornado ao cliente.
/// </summary>
public class AppException : Exception
{
    /// <summary>
    /// Código HTTP da resposta.
    /// </summary>
    public int StatusCode { get; }

    /// <summary>
    /// Cria uma nova exceção da aplicação.
    /// </summary>
    /// <param name="message">Mensagem do erro.</param>
    /// <param name="statusCode">Código HTTP (padrão 400).</param>
    public AppException(string message, int statusCode = 400)
        : base(message)
    {
        StatusCode = statusCode;
    }
}