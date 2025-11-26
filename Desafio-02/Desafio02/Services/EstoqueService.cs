using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class EstoqueService
{
    private List<Produto> produtos;
    private readonly string caminhoArquivo;

    public EstoqueService()
    {
        // Caminho relativo à raiz do projeto, funciona mesmo rodando do bin
        caminhoArquivo = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", "estoque.json");
        CarregarEstoque();
    }

    private void CarregarEstoque()
    {
        string caminhoResolvido = Path.GetFullPath(caminhoArquivo); // Caminho absoluto para debug
        Console.WriteLine($"Procurando arquivo em: {caminhoResolvido}");

        if (!File.Exists(caminhoResolvido))
        {
            Console.WriteLine("Arquivo estoque.json não encontrado!");
            produtos = new List<Produto>();
            return;
        }

        string json = File.ReadAllText(caminhoResolvido);
        var wrapper = JsonSerializer.Deserialize<EstoqueWrapper>(json);
        produtos = wrapper?.estoque ?? new List<Produto>();
    }

    public void MovimentarEstoque()
    {
        Console.WriteLine("=== Movimentação de Estoque ===");

        Console.Write("Informe o código do produto: ");
        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Código inválido!");
            return;
        }

        var produto = produtos.FirstOrDefault(p => p.Codigo == codigo);
        if (produto == null)
        {
            Console.WriteLine("Erro: Produto não encontrado.");
            return;
        }

        Console.Write("Tipo de movimentação (entrada/saida): ");
        string tipo = Console.ReadLine()?.Trim().ToLower();

        Console.Write("Quantidade: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida!");
            return;
        }

        if (tipo == "entrada")
        {
            produto.Quantidade += quantidade;
            Console.WriteLine($"Entrada realizada. Novo estoque: {produto.Quantidade}");
        }
        else if (tipo == "saida")
        {
            if (produto.Quantidade < quantidade)
            {
                Console.WriteLine("Estoque insuficiente!");
                return;
            }
            produto.Quantidade -= quantidade;
            Console.WriteLine($"Saída realizada. Novo estoque: {produto.Quantidade}");
        }
        else
        {
            Console.WriteLine("Tipo de movimentação inválido!");
        }

        SalvarEstoque();
    }

    public void ListarProdutos()
    {
        Console.WriteLine("\n=== Lista de Produtos ===");
        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        foreach (var p in produtos)
        {
            Console.WriteLine($"Código: {p.Codigo} | Descrição: {p.Descricao} | Estoque: {p.Quantidade}");
        }
    }

    private void SalvarEstoque()
    {
        var wrapper = new EstoqueWrapper { estoque = produtos };
        string caminhoResolvido = Path.GetFullPath(caminhoArquivo);
        string json = JsonSerializer.Serialize(wrapper, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(caminhoResolvido, json);
    }
}
