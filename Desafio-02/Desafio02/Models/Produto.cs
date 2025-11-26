using System.Text.Json.Serialization;

public class Produto
{
    [JsonPropertyName("codigoProduto")]
    public int Codigo { get; set; }

    [JsonPropertyName("descricaoProduto")]
    public string Descricao { get; set; }

    [JsonPropertyName("estoque")]
    public int Quantidade { get; set; }
}
