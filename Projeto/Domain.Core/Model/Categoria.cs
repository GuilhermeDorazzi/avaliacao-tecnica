using System.Text.Json.Serialization;

namespace Citel.Core.Model
{
    public class Categoria
    {
        public Categoria()
        {
            CodCategoria = -1;
        }

        [JsonPropertyName("cod_categoria")]
        public long CodCategoria { get; set; }

        [JsonPropertyName("nom_categoria")]
        public string NomCategoria { get; set; }

        [JsonPropertyName("flg_ativo")]
        public string FlgAtivo { get; set; }
    }
}
