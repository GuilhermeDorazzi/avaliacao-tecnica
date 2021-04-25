using Citel.Core.Model;
using Citel.Core.Model.Base;
using Citel.Core.Repositories;
using Citel.Core.Service.Interfaces;
using System;

namespace Citel.Core.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository iProdutoRepository;

        public ProdutoService(IProdutoRepository iProdutoRepository)
        {
            this.iProdutoRepository = iProdutoRepository;
        }

        public ResultadoPadrao Atualizar(Produto entidade)
        {
            try
            {
                var resultado = new ResultadoPadrao()
                {
                    Dados = iProdutoRepository.Atualizar(entidade)
                };

                return resultado;
            }
            catch (Exception e)
            {
                return new ResultadoPadrao(e);
            }
        }

        public ResultadoPadrao Inserir(Produto entidade)
        {
            try
            {
                var resultado = new ResultadoPadrao()
                {
                    Dados = iProdutoRepository.Inserir(entidade)
                };

                return resultado;
            }
            catch (Exception e)
            {
                return new ResultadoPadrao(e);
            }
        }

        public ResultadoPadrao Remover(Produto entidade)
        {
            try
            {
                var resultado = new ResultadoPadrao()
                {
                    Dados = iProdutoRepository.Remover(entidade)
                };

                return resultado;
            }
            catch (Exception e)
            {
                return new ResultadoPadrao(e);
            }
        }

        public ResultadoPadrao Selecionar(Produto filtro)
        {
            try
            {
                var resultado = new ResultadoPadrao()
                {
                    Dados = iProdutoRepository.Selecionar(filtro)
                };

                return resultado;
            }
            catch (Exception e)
            {
                return new ResultadoPadrao(e);
            }
        }

        public ResultadoPadrao SelecionarRegistro(Produto filtro)
        {
            try
            {
                var resultado = new ResultadoPadrao()
                {
                    Dados = iProdutoRepository.SelecionarRegistro(filtro)
                };

                return resultado;
            }
            catch (Exception e)
            {
                return new ResultadoPadrao(e);
            }
        }
    }
}
