using MiniLojaSolid.Interfaces;
using System.Collections.Generic;

namespace MiniLojaSolid.Notificacoes;

public class NotificadorMemoria : INotificador
{
    public List<string> Mensagens { get; } = new();

    public void Enviar(string mensagem)
    {
        Mensagens.Add(mensagem);
    }
}