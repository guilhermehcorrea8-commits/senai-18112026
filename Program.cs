
using System.Globalization;
using MiniLojaSolid.Models;
using MiniLojaSolid.Descontos;
using MiniLojaSolid.Notificacoes;
using MiniLojaSolid.Services;
using MiniLojaSolid.Interfaces;

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");

Console.WriteLine("==================================");
Console.WriteLine("          MINI LOJA SOLID");
Console.WriteLine("==================================");

// Entrada do valor
Console.Write("\nDigite o valor da compra: R$ ");

if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
{
    Console.WriteLine("Valor inválido! Digite um valor maior que zero.");
    return;
}

// Escolha do desconto
Console.WriteLine("\nEscolha o desconto:");
Console.WriteLine("1 - VIP (10%)");
Console.WriteLine("2 - Black Friday (25%)");
Console.WriteLine("3 - Aniversário (15%)");

Console.Write("\nDigite a opção: ");
string? opcao = Console.ReadLine();

IPoliticaDesconto desconto = opcao switch
{
    "1" => new DescontoVip(),
    "2" => new DescontoBlackFriday(),
    "3" => new DescontoAniversario(),
    _ => null!
};

if (desconto == null)
{
    Console.WriteLine("Opção de desconto inválida!");
    return;
}

// Escolha do notificador
INotificador notificador = new NotificadorSms();

var checkout = new Checkout(desconto, notificador);
var carrinho = new Carrinho(valor);

try
{
    decimal total = checkout.Finalizar(carrinho);

    Console.WriteLine("\n==================================");
    Console.WriteLine("         PEDIDO FINALIZADO");
    Console.WriteLine("==================================");
    Console.WriteLine($"Valor original: {carrinho.Total:C}");
    Console.WriteLine($"Valor com desconto: {total:C}");
    Console.WriteLine($"Economia: {carrinho.Total - total:C}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}
