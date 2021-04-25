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
            var query = @"
                           update tb_categorias
                              set nom_categoria = @NomCategoria,
                                  flg_ativo     = @FlgAtivo
                            where cod_categoria = @CodCategoria
                         ";
            return this.Execute(query, entidade) > 0;
        }

        public bool Inserir(Categoria entidade)
        {
            if (entidade.CodCategoria <= 0)
                entidade.CodCategoria = this.GetGerarCodigo("tb_categorias", "cod_categoria");

            var query = @"
                           insert into tb_categorias(cod_categoria,nom_categoria,flg_ativo) 
                           values (@CodCategoria,@NomCategoria,@FlgAtivo)
                         ";
            return this.Execute(query, entidade) > 0;
        }

        public bool Remover(Categoria entidade)
        {
           var query = @"delete from tb_categorias where cod_categoria = @CodCategoria ";
           return this.Execute(query, entidade) > 0;
        }

        public IList<Categoria> Selecionar(Categoria filtro) 
        {
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
            var query = @"
                            select 
	                               c.cod_categoria CodCategoria
	                             , c.nom_categoria NomCategoria
                                 , c.flg_ativo     FlgAtivo
                            from tb_categorias as c
                           where c.cod_categoria = @CodCategoria
                         ";

            var resultado = this.Query<Categoria>(query, filtro);

            return resultado.FirstOrDefault();
        }
    }
}
