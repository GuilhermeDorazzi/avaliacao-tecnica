using System.Collections.Generic;

namespace Citel.Data.Repositories.Base
{
    public class BaseRepository<T>
    {
        public IList<T> Selecionar(T filtro){return null;}

        public bool Inserir(T entidade) { return false; }

        public bool Atualizar(T entidade) { return false; }

        public bool Remover(T entidade) { return false; }

        public T SelecionarRegistro(T filtro) { return filtro; }
    }
}
