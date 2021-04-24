using System.Collections.Generic;

namespace Citel.Core.Service.Base
{
    public interface IBaseService<T>
    {
        IList<T> Selecionar(T filtro);

        bool Inserir(T entidade);

        bool Atualizar(T entidade);

        bool Remover(T entidade);

        T SelecionarRegistro(T filtro);
    }
}
