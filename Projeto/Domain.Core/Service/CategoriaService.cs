using Citel.Core.Model;
using Citel.Core.Model.Base;
using Citel.Core.Repositories;
using Citel.Core.Service.Interfaces;
using System;

namespace Citel.Core.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository iCategoriaRepository;

        public CategoriaService(ICategoriaRepository iCategoriaRepository)
        {
            this.iCategoriaRepository = iCategoriaRepository;
        }

        public ResultadoPadrao Atualizar(Categoria entidade)
        {
            try
            {
                var resultado = new ResultadoPadrao()
                {
                    Dados = iCategoriaRepository.Atualizar(entidade)
                };

                return resultado;
            }
            catch(Exception e)
            {
                return new ResultadoPadrao(e);
            }

        }

        public ResultadoPadrao Inserir(Categoria entidade)
        {
            try
            {
                var resultado = new ResultadoPadrao()
                {
                    Dados = iCategoriaRepository.Inserir(entidade)
                };

                return resultado;
            }
            catch (Exception e)
            {
                return new ResultadoPadrao(e);
            }
        }

        public ResultadoPadrao Remover(Categoria entidade)
        {
            try
            {
                var resultado = new ResultadoPadrao()
                {
                    Dados = iCategoriaRepository.Remover(entidade)
                };

                return resultado;
            }
            catch (Exception e)
            {
                return new ResultadoPadrao(e);
            }
        }

        public ResultadoPadrao Selecionar(Categoria filtro)
        {
            try
            {
                var resultado = new ResultadoPadrao()
                {
                    Dados = iCategoriaRepository.Selecionar(filtro)
                };

                return resultado;
            }
            catch (Exception e)
            {
                return new ResultadoPadrao(e);
            }
        }

        public ResultadoPadrao SelecionarRegistro(Categoria filtro)
        {
            try
            {
                var resultado = new ResultadoPadrao()
                {
                    Dados = iCategoriaRepository.SelecionarRegistro(filtro)
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
