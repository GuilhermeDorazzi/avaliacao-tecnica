using Citel.Core.Model.Base;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Citel.Api.Controllers.Base.Util
{
    /// <summary>
    /// Utilitário para respostas de api
    /// </summary>
    public static class RespostaApiUtil
    {

        /// <summary>
        /// Configura uma resposta de serviço, de acordo com o resultado da operação (padrão para sucesso statusCode 200 e 400 para falha)
        /// </summary>
        /// <param name="controller">Controlador usando o recurso</param>
        /// <param name="resultadoPadrao">Resultado da operação</param>
        /// <param name="seSucessoRetornarApenasDados">Quando true retorna apenas o conteúdo da propriedade "ResultadoPadrao.Dados"</param>
        /// <returns>Returna um status http formatado de acordo com o resultado da operação</returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public static ActionResult ConfigurarRespostaPadraoApi(ControllerBase controller, ResultadoPadrao resultadoPadrao, bool seSucessoRetornarApenasDados)
        {
            return ConfigurarRespostaApi(controller, resultadoPadrao, (int)HttpStatusCode.OK, (int)HttpStatusCode.BadRequest, seSucessoRetornarApenasDados);
        }

        /// <summary>
        /// Configura uma resposta de serviço, de acordo com o resultado da operação
        /// </summary>
        /// <param name="controller">Controlador usando o recurso</param>
        /// <param name="resultadoPadrao">Resultado da operação</param>
        /// <param name="statusCodeSucesso">Código http para o resultado de sucesso</param>
        /// <param name="statusCodeParaErro">Código http para o resultado de falha</param>
        /// <param name="seSucessoRetornarApenasDados">Quando true retorna apenas o conteúdo da propriedade "ResultadoPadrao.Dados"</param>
        /// <returns>Returna um status http formatado de acordo com o resultado da operação</returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        private static ActionResult ConfigurarRespostaApi(ControllerBase controller, ResultadoPadrao resultadoPadrao, int statusCodeSucesso, int statusCodeParaErro, bool seSucessoRetornarApenasDados)
        {
            //verifica reposta
            if (resultadoPadrao == null)
            {
                var msg = "Não foi possível processar a solicitação";
                return controller.BadRequest(msg);
            }
            else if (!resultadoPadrao.OperacaoEncerradaComSucesso)
            {
                var msg = resultadoPadrao.MensagemOperacao;
                return controller.StatusCode(statusCodeParaErro, msg);
            }

            // se não tiver dados retorna a mensagem da operação
            object resultado = seSucessoRetornarApenasDados ? resultadoPadrao.Dados : resultadoPadrao;
            if (resultadoPadrao.Dados == null)
                resultado = resultadoPadrao.MensagemOperacao;

            return controller.StatusCode(statusCodeSucesso, resultado);
        }

    }
}

