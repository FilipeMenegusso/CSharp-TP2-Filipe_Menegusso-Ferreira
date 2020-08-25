using System;
using System.Collections.Generic;
using System.Linq;
using TP02.ImobiliariaApp;

namespace TP02___ImobiliariaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var imoveis = new Dictionary<Guid, Imovel>();

            ExibirMenu(imoveis);
        }

        static void ExibirMenu(Dictionary<Guid, Imovel> imoveis)
        {
            int opcaoSelecionada;

            do
            {
                Console.WriteLine("GERENCIADOR DE IMÓVEIS");

                Console.WriteLine("Selecione uma das opções abaixo:");
                Console.WriteLine("1 - Pesquisar imóveis");
                Console.WriteLine("2 - Adicionar novo imóvel");
                Console.WriteLine("3 - Sair");

                Console.WriteLine();
                opcaoSelecionada = LerOpcaoMenu();

                if (opcaoSelecionada == 1)
                {
                    PesquisarImoveis(imoveis);
                }
                else if (opcaoSelecionada == 2)
                {
                    AdicionarImovel(imoveis);
                }

            } while (opcaoSelecionada != 3);
        }

        static int LerOpcaoMenu()
        {
            int opcaoMenu = 0;

            string opcaoMenuSelecionado = Console.ReadLine();

            while (!int.TryParse(opcaoMenuSelecionado, out opcaoMenu) || (opcaoMenu < 1 || opcaoMenu > 3))
            {
                Console.WriteLine("Opcao inválida: ");
                opcaoMenuSelecionado = Console.ReadLine();
            }

            return opcaoMenu;
        }

        static void AdicionarImovel(Dictionary<Guid, Imovel> imoveis)
        {
            Console.Clear();

            var imovel = new Imovel();

            var confirmacaoDadosCorretos = 0;

            Console.WriteLine("Digite o endereço do imóvel(por extenso): ");
            imovel.Endereco = Console.ReadLine();

            Console.WriteLine("Os dados abaixo estão corretos?");
            Console.WriteLine($"Endereço: {imovel.Endereco}");
            Console.WriteLine($"Data de Cadastro: {imovel.DataCadastro}");

            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");

            var opcaoSelecionada = Console.ReadLine();

            while (!int.TryParse(opcaoSelecionada, out confirmacaoDadosCorretos) || confirmacaoDadosCorretos != 1)
            {

                Console.WriteLine("Digite o endereço do imóvel(por extenso): ");
                imovel.Endereco = Console.ReadLine();

                Console.WriteLine("Os dados abaixo estão corretos?");
                Console.WriteLine($"Endereço: {imovel.Endereco}");
                Console.WriteLine($"Data de Cadastro: {imovel.DataCadastro}");

                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");

                opcaoSelecionada = Console.ReadLine();
            }

            imoveis.Add(imovel.Id, imovel);

            Console.WriteLine("Imóvel cadastrado com sucesso!");
        }

        static void PesquisarImoveis(Dictionary<Guid, Imovel> imoveis)
        {
            Console.Clear();

            Console.WriteLine("Digite o endereço do imóvel(por extenso): ");
            string endereco = Console.ReadLine();

            var imoveisPesquisados = imoveis.Values.Where(imovel => imovel.Endereco.Contains(endereco, StringComparison.InvariantCultureIgnoreCase));

            if (imoveisPesquisados.Count() == 0)
                Console.WriteLine("Não foram encontrados imóveis com este endereço");
            else
            {
                Console.WriteLine("Imóveis encontrados: ");
                foreach (var imovel in imoveis)
                {
                    Console.WriteLine($"* {imovel.Value.Endereco}");
                }
            }
        }
    }
}
