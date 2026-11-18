using MiniLojaSolid.Interfaces;

namespace MiniLojaSolid.Notificacoes;

public class NotificadorSms : INotificador
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine($"SMS: {mensagem}");
    }
}