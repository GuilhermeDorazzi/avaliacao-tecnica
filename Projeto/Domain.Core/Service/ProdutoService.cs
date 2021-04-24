using Citel.Core.Model;
using Citel.Core.Repositories;
using Citel.Core.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Citel.Core.Service
{
    public class ProdutoService : IProdutoService
    {
        private IProdutoRepository iProdutoRepository;

        public ProdutoService(IProdutoRepository iProdutoRepository)
        {
            this.iProdutoRepository = iProdutoRepository;
        }

        public bool Atualizar(Produto entidade)
        {
            return iProdutoRepository.Atualizar(entidade);
        }

        public bool Inserir(Produto entidade)
        {
            return iProdutoRepository.Inserir(entidade);
        }

        public bool Remover(Produto entidade)
        {
            return iProdutoRepository.Remover(entidade);
        }

        public IList<Produto> Selecionar(Produto filtro)
        {
            return iProdutoRepository.Selecionar(filtro);
        }

        public Produto SelecionarRegistro(Produto filtro)
        {
            return iProdutoRepository.SelecionarRegistro(filtro);
        }
    }
}
