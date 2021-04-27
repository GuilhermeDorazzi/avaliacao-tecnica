using Citel.Core.Model;
using Citel.Core.Repositories;
using Citel.Data.Repositories.Base;
using Citel.Data.Repositories.UoW;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Citel.Data.Repositories
{
    public class ProdutoRepository : MySqlDapperHelper, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration configuration, IDbConnectionFactory dbConnectionFactory)
            : base(configuration, dbConnectionFactory) { }

        public bool Atualizar(Produto entidade)
        {
            var query = @"
                             update tb_produtos
                                set cod_barras      = @CodBarras   
                                    nom_produto     = @NomProduto  
                                    des_produto     = @DesProduto  
                                    vlr_produto     = @VlrProduto  
                                    flg_ativo       = @FlgAtivo    
                                where cod_categoria = @CodCategoria and 
                                      cod_produto   = @CodProduto
                         ";
            return this.Execute(query, entidade) > 0;
        }

        public bool Inserir(Produto entidade)
        {
            if (entidade.CodProduto.GetValueOrDefault(-1) <= 0)
                entidade.CodProduto = this.GetGerarCodigo("tb_produtos", "cod_produto");

            var query = @"
                           insert into tb_produtos(cod_produto,cod_categoria,cod_barras,nom_produto,des_produto,flg_ativo,vlr_produto) 
                           values (@CodProduto,@CodCategoria,@CodBarras,@NomProduto,@DesProduto,@FlgAtivo,@VlrProduto)
                         ";
            return this.Execute(query, entidade) > 0;
        }

        public bool Remover(Produto entidade)
        {
            var query = @"delete from tb_produtos where cod_categoria = @CodCategoria and cod_produto = @CodProduto ";
            return this.Execute(query, entidade) > 0;
        }

        public IList<Produto> Selecionar(Produto filtro)
        {
            return SelecionarFiltro(filtro);
        }

        public Produto SelecionarRegistro(Produto filtro)
        {
            return SelecionarFiltro(filtro).FirstOrDefault();
        }

        private IList<Produto> SelecionarFiltro(Produto filtro) {

            var query = @"
                            select 
	                               c.cod_produto   CodProduto
	                             , c.cod_categoria CodCategoria
                                 , c.cod_barras    CodBarras
                                 , c.nom_produto   NomProduto
                                 , c.des_produto   DesProduto
                                 , c.vlr_produto   VlrProduto  
                                 , c.flg_ativo     FlgAtivo
                            from tb_produtos as c
                            {0}
                         ";

            string where = string.Empty;

            if (filtro.CodProduto.GetValueOrDefault(-1) > 0)
                where += string.Format("{0} c.cod_produto = @CodProduto", string.IsNullOrEmpty(where) ? " where " : " and ");

            if (filtro.CodCategoria > 0)
                where += string.Format("{0} c.cod_categoria = @CodCategoria", string.IsNullOrEmpty(where) ? " where " : " and ");

            if (!string.IsNullOrEmpty(filtro.CodBarras))
                where += string.Format("{0} c.cod_barras = @CodBarras", string.IsNullOrEmpty(where) ? " where " : " and ");

            query = string.Format(query,where);

            var resultado = this.Query<Produto>(query, filtro);

            return resultado.ToList();
        }

    }
}