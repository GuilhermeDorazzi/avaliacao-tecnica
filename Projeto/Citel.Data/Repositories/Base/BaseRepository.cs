using System.Collections.Generic;

namespace Citel.Data.Repositories.Base
{
    public class BaseRepository<T>
    {
        public virtual IList<T> Selecionar(T filtro){return null;}

        public virtual bool Inserir(T entidade) { return false; }

        public virtual bool Atualizar(T entidade) { return false; }

        public virtual bool Remover(T entidade) { return false; }

        public virtual T SelecionarRegistro(T filtro) { return filtro; }
    }
}
