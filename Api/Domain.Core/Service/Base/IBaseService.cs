using Citel.Core.Model.Base;

namespace Citel.Core.Service.Base
{
    public interface IBaseService<T>
    {
        ResultadoPadrao Selecionar(T filtro);

        ResultadoPadrao Inserir(T entidade);

        ResultadoPadrao Atualizar(T entidade);

        ResultadoPadrao Remover(T entidade);

        ResultadoPadrao SelecionarRegistro(T filtro);
    }
}
