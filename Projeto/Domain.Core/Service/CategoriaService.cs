using Citel.Core.Model;
using Citel.Core.Repositories;
using Citel.Core.Service.Interfaces;
using System.Collections.Generic;

namespace Citel.Core.Service
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository iCategoriaRepository;

        public CategoriaService(ICategoriaRepository iCategoriaRepository)
        {
            this.iCategoriaRepository = iCategoriaRepository;
        }

        public bool Atualizar(Categoria entidade)
        {
            return iCategoriaRepository.Atualizar(entidade);
        }

        public bool Inserir(Categoria entidade)
        {
            return iCategoriaRepository.Inserir(entidade);
        }

        public bool Remover(Categoria entidade)
        {
            return iCategoriaRepository.Remover(entidade);
        }

        public IList<Categoria> Selecionar(Categoria filtro)
        {
            return iCategoriaRepository.Selecionar(filtro);
        }

        public Categoria SelecionarRegistro(Categoria filtro)
        {
            return iCategoriaRepository.SelecionarRegistro(filtro);
        }
    }
}
