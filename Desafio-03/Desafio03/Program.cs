using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Cálculo de Juros ===");

        // Solicita valor
        Console.Write("Informe o valor da dívida: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
        {
            Console.WriteLine("Valor inválido!");
            return;
        }

        Console.Write("Informe a data de vencimento (dd/mm/aaaa): ");
        if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime vencimento))
        {
            Console.WriteLine("Data inválida! Use o formato dd/mm/aaaa.");
            return;
        }

        DateTime hoje = DateTime.Today;

        if (vencimento >= hoje)
        {
            Console.WriteLine("Não há juros, o vencimento ainda não passou.");
            Console.WriteLine($"Valor a pagar: R$ {valor:F2}");
            return;
        }

        int diasAtraso = (hoje - vencimento).Days;

        decimal taxaDiaria = 0.025m;
        decimal valorJuros = valor * taxaDiaria * diasAtraso;
        decimal valorTotal = valor + valorJuros;

        Console.WriteLine($"\nDias de atraso: {diasAtraso} dia(s)");
        Console.WriteLine($"Valor dos juros: R$ {valorJuros:F2}");
        Console.WriteLine($"Valor total a pagar: R$ {valorTotal:F2}");
    }
}
