using System;

namespace EstacionamentoLogicaProgramacao
{
    class Program
    {
        static void Main()
        {
            IConsoleWrapper console = new ConsoleWrapper();
            Estacionamento estacionamento = new Estacionamento(5, 2, console);

            int opcao;

            do
            {
                console.WriteLine("\nMenu:");
                console.WriteLine("1. Cadastrar veículo");
                console.WriteLine("2. Remover veículo");
                console.WriteLine("3. Listar veículos");
                console.WriteLine("4. Encerrar");
                console.Write("Escolha uma opção (1-4): ");

                opcao = Convert.ToInt32(console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        console.Write("Digite a placa do veículo: ");
                        string placa = console.ReadLine();
                        estacionamento.AdicionarVeiculo(placa);
                        break;

                    case 2:
                        console.Write("Digite a placa do veículo a ser removido: ");
                        string placaRemover = console.ReadLine();
                        estacionamento.RemoverVeiculo(placaRemover);
                        break;

                    case 3:
                        estacionamento.ListarVeiculos();
                        break;

                    case 4:
                        console.WriteLine("Encerrando o programa. Obrigado!");
                        break;

                    default:
                        console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (opcao != 4);
        }
    }
}
