using MiniLojaSolid.Interfaces;
using MiniLojaSolid.Models;

namespace MiniLojaSolid.Services;

public class Checkout
{
    private readonly IPoliticaDesconto _desconto;
    private readonly INotificador _notificador;
    private readonly ValidadorCarrinho _validador;

    public Checkout(
        IPoliticaDesconto desconto,
        INotificador notificador)
    {
        _desconto = desconto;
        _notificador = notificador;
        _validador = new ValidadorCarrinho();
    }

    public decimal Finalizar(Carrinho carrinho)
    {
        _validador.Validar(carrinho);

        decimal total = _desconto.Aplicar(carrinho.Total);

        _notificador.Enviar("Pedido concluído!");

        return total;
    }
}