using System.Runtime.Serialization;

namespace Citel.Core.Model
{
    [DataContract]
    public class Categoria
    {
        public Categoria()
        {
            CodCategoria = -1;
        }

        [DataMember(Name = "cod_categoria")]
        public long CodCategoria { get; set; }

        [DataMember(Name = "nom_categoria")]
        public string NomCategoria { get; set; }

        [DataMember(Name = "flg_ativo")]
        public string FlgAtivo { get; set; }
    }
}
