namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Pede pro usuário digitar uma placa e adiciona na lista "veiculos"
            string placa = string.Empty;
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine();
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pede pro usuário digitar a placa e armazena na variável placa
            string placa = string.Empty;
            placa = Console.ReadLine();


            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                // Pede pro usuário digitar a quantidade de horas que o veículo permaneceu estacionado
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");              
                string horas = Console.ReadLine();

                decimal valorTotal = 0;

                // Loop que verifica se o que o usuário digitou é um número válido
                bool sucesso = false;
                while (!sucesso) // Alterado pra negação da variável sucesso
                {
                    if (Int32.TryParse(horas, out int horas1))
                    {
                        valorTotal = precoInicial + precoPorHora * horas1;
                        veiculos.Remove(placa);
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                        sucesso = true; // Alterado para true quando a conversão for bem sucedida
                    }

                    else
                    {
                        Console.WriteLine("Digite um número válido para a quantidade de horas que o veículo permaneceu estacionado: ");
                        sucesso = false;
                        horas = Console.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                // Exibe todos os veículos estacionados
                for (int iCount = 0; iCount < veiculos.Count; iCount++)
                {
                    Console.WriteLine($"{veiculos[iCount]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
