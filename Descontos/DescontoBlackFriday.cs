using MiniLojaSolid.Interfaces;

namespace MiniLojaSolid.Descontos;

public class DescontoBlackFriday : IPoliticaDesconto
{
    public decimal Aplicar(decimal total)
    {
        return total * 0.75m;
    }
}