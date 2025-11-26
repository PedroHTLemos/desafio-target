namespace Desafio02.Models
{
    public class Movimento
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Tipo { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}
