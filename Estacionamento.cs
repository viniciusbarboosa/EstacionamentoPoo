using System;
using System.Collections.Generic;

namespace EstacionamentoLogicaProgramacao
{
    public interface IConsoleWrapper
    {
        void WriteLine(string value);
        void Write(string value);
        string ReadLine();
    }

    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine(string value) => Console.WriteLine(value);
        public void Write(string value) => Console.Write(value);
        public string ReadLine() => Console.ReadLine();
    }

    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos;
        private IConsoleWrapper console;

        public Estacionamento(decimal precoInicial, decimal precoPorHora, IConsoleWrapper console)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
            this.console = console;
        }

        public void AdicionarVeiculo(string placa)
        {
            veiculos.Add(placa);
            console.WriteLine("Veículo cadastrado com sucesso!");
            ListarVeiculos();
        }

        public void RemoverVeiculo(string placa)
        {
            if (veiculos.Contains(placa))
            {
                console.Write("Digite a quantidade de horas que o veículo permaneceu no estacionamento: ");
                int horasEstacionado = Convert.ToInt32(console.ReadLine());

                decimal valorCobrado = CalcularValorCobrado(horasEstacionado);
                console.WriteLine($"Valor cobrado pelo estacionamento: R${valorCobrado}");

                veiculos.Remove(placa);
            }
            else
            {
                console.WriteLine("Veículo não encontrado no estacionamento.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos != null && veiculos.Count > 0)
            {
                console.WriteLine("Veículos estacionados:");
                foreach (var veiculo in veiculos)
                {
                    console.WriteLine(veiculo);
                }
            }
            else
            {
                console.WriteLine("Não há veículos estacionados.");
            }
        }

        private decimal CalcularValorCobrado(int horasEstacionado)
        {
            return precoInicial + (precoPorHora * horasEstacionado);
        }
    }
}
