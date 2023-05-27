using System;
using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;
bool precoInicialValido = false;
bool precoPorHoraValido = false;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                 "Digite o preço inicial:");
while (!precoInicialValido) // Loop pra verificar se o que o usuário digitou pode ser convertido em um número decimal válido
{
    if (decimal.TryParse(Console.ReadLine(), out precoInicial)) // Se for bem sucedido, a váriavel é precoInicialValido é colocado como true e o loop é interrompido
    {
        precoInicialValido = true;
    }
    else // Caso contrário, uma mensagem é exibida pra solicitar que o usuário digite um número válido
    {
        Console.WriteLine("Digite um número válido para o preço inicial: ");
    }
}

Console.WriteLine("Agora digite o preço por hora:");
while (!precoPorHoraValido) // Funciona da mesma maneira que o loop anterior
{
    if (decimal.TryParse(Console.ReadLine(), out precoPorHora))
    {
        precoPorHoraValido = true;
    }
    else
    {
        Console.WriteLine("Digite um número válido para o preço por hora: ");
    }
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");