using System.Text.Json;
using Desafio01.Models;
using Desafio01.Services;

class Program
{
    static void Main()
    {
        string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "vendas.json");

        if (!File.Exists(dataPath))
        {
            Console.WriteLine("Arquivo vendas.json não encontrado!");
            Console.WriteLine("Caminho procurado: " + dataPath);
            return;
        }

        string json = File.ReadAllText(dataPath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        VendasWrapper? dados = JsonSerializer.Deserialize<VendasWrapper>(json, options);

        if (dados == null || dados.Vendas.Count == 0)
        {
            Console.WriteLine("Não foi possível carregar as vendas.");
            return;
        }

        var service = new ComissaoService();
        var comissoes = service.CalcularComissoes(dados.Vendas);

        Console.WriteLine("===== Comissões Calculadas =====");
        foreach (var item in comissoes)
        {
            Console.WriteLine($"{item.Key}: R$ {item.Value:F2}");
        }
    }
}
