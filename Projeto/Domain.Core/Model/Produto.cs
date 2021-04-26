using System.Text.Json.Serialization;

namespace Citel.Core.Model
{
    public class Produto
    {
        public Produto()
        {
            CodCategoria = -1;
            CodProduto = -1;
        }

        [JsonPropertyName("cod_produto")]
        public long CodProduto { get; set; }

        [JsonPropertyName("cod_categoria")]
        public long CodCategoria { get; set; }

        [JsonPropertyName("cod_barras")]
        public string CodBarras { get; set; }

        [JsonPropertyName("nom_produto")]
        public string NomProduto { get; set; }

        [JsonPropertyName("des_produto")]
        public string DesProduto { get; set; }

        [JsonPropertyName("flg_ativo")]
        public string FlgAtivo { get; set; }

    }
}
