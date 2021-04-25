using Citel.Core.Model;
using Citel.Core.Repositories;
using Citel.Data.Repositories.Base;
using Citel.Data.Repositories.UoW;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Citel.Data.Repositories
{
    public class CategoriaRepository : MySqlDapperHelper, ICategoriaRepository
    {
        public CategoriaRepository(IConfiguration configuration, IDbConnectionFactory dbConnectionFactory) 
            : base(configuration, dbConnectionFactory) { }

        public bool Atualizar(Categoria entidade)
        {
            throw new System.NotImplementedException();
        }

        public bool Inserir(Categoria entidade)
        {
            throw new System.NotImplementedException();
        }

        public bool Remover(Categoria entidade)
        {
            throw new System.NotImplementedException();
        }

        public IList<Categoria> Selecionar(Categoria filtro) {

            var query = @"
                            select 
	                               c.cod_categoria CodCategoria
	                             , c.nom_categoria NomCategoria
                                 , c.flg_ativo     FlgAtivo
                            from tb_categorias as c
                         ";

            var resultado = this.Query<Categoria>(query, new { });

            return resultado.ToList();
        }

        public Categoria SelecionarRegistro(Categoria filtro)
        {
            throw new System.NotImplementedException();
        }
    }
}
