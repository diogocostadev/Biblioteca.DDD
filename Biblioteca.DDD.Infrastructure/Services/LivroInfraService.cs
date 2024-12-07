namespace Biblioteca.DDD.Infrastructure.Services;

public class LivroInfraService
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG]: {message}");
    }
}