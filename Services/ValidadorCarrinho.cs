using MiniLojaSolid.Models;

namespace MiniLojaSolid.Services;

public class ValidadorCarrinho
{
    public void Validar(Carrinho carrinho)
    {
        if (carrinho.Total <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(carrinho),
                "O total do carrinho deve ser maior que zero."
            );
        }
    }
}