using System;

class Program
{
    static void Main(string[] args)
    {
        var estoqueService = new EstoqueService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Sistema de Estoque ===");
            Console.WriteLine("1. Movimentar Estoque");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine()?.Trim();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    estoqueService.MovimentarEstoque();
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    estoqueService.ListarProdutos();
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.WriteLine("Saindo do sistema...");
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
