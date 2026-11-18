using MiniLojaSolid.Interfaces;

namespace MiniLojaSolid.Descontos;

public class DescontoVip : IPoliticaDesconto
{
    public decimal Aplicar(decimal total)
    {
        return total * 0.90m;
    }
}