using Desafio01.Models;

namespace Desafio01.Services
{
    public class ComissaoService
    {
        public Dictionary<string, double> CalcularComissoes(List<Venda> vendas)
        {
            var comissoes = new Dictionary<string, double>();

            foreach (var venda in vendas)
            {
                double comissao = 0;

                if (venda.Valor >= 500)
                    comissao = venda.Valor * 0.05;
                else if (venda.Valor >= 100)
                    comissao = venda.Valor * 0.01;

                if (!comissoes.ContainsKey(venda.Vendedor))
                    comissoes[venda.Vendedor] = 0;

                comissoes[venda.Vendedor] += comissao;
            }

            return comissoes;
        }
    }
}
