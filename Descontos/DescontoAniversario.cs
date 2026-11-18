using MiniLojaSolid.Interfaces;

namespace MiniLojaSolid.Descontos;

public class DescontoAniversario : IPoliticaDesconto
{
    public decimal Aplicar(decimal total)
    {
        return total * 0.85m;
    }
}