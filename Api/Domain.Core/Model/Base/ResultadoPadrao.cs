using Citel.Resources;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Citel.Core.Model.Base
{
    [DataContract]
    public class ResultadoPadrao
    {
        /// <summary>
        /// Dados a serem retornados para quem chamou a API
        /// </summary>
        [JsonPropertyName("dados")]
        public object Dados { get; set; }

        /// <summary>
        /// Mensagem da operação
        /// </summary>
        public string MensagemOperacao { get; set; }

        /// <summary>
        /// Exceção gerada no processo (caso ocorra)
        /// </summary>
        public Exception Excecao { get; set; }

        /// <summary>
        /// Indica se a operação foi encerrada com sucesso
        /// </summary>
        public bool OperacaoEncerradaComSucesso { get; set; }

        /// <summary>
        /// Status http da operação (isso é opcional, para auxiliar no retorno de diferentes erros dentro dos mesmos processo de validação)
        /// </summary>
        public int HttpStatusCode { get; set; }

        /// <summary>
        /// Construtor padrão, por default:
        /// - Marca operação como sucesso;
        /// - Seta uma mensagem padrão de sucesso
        /// </summary>
        public ResultadoPadrao()
        {
            OperacaoEncerradaComSucesso = true;
            MensagemOperacao = AppString.TIT_OperacaoRealizadaSucesso;
        }

        /// <summary>
        /// Construtor para criar objeto com erro
        /// </summary>
        /// <param name="exception">Erro</param>
        public ResultadoPadrao(Exception exception)
        {
            RegistrarExcecao(exception);
        }

        /// <summary>
        /// Construtor para criar objeto com erro
        /// </summary>
        /// <param name="mensagemOperacao">Mensagem de erro</param>
        public ResultadoPadrao(string mensagemOperacao)
        {
            RegistrarExcecao(mensagemOperacao);
        }

        /// <summary>
        /// Registra uma exceção para a entidade
        /// </summary>
        /// <param name="exception">Exceção</param>
        public void RegistrarExcecao(Exception exception)
        {
            RegistrarExcecao(exception, null);
        }

        /// <summary>
        /// Registra uma exceção para a entidade
        /// </summary>
        /// <param name="mensagemOperacao">Exceção</param>
        public void RegistrarExcecao(string mensagemOperacao)
        {
            RegistrarExcecao(null, mensagemOperacao);
        }

        /// <summary>
        /// Registra uma exceção para a entidade
        /// </summary>
        /// <param name="excecao">Exceção</param>
        /// <param name="mensagemOperacao">Mensagem da operação (se nulo assume a mensagem da exceção)</param>
        public void RegistrarExcecao(Exception excecao, string mensagemOperacao)
        {
            this.OperacaoEncerradaComSucesso = false;
            this.Excecao = excecao;
            this.MensagemOperacao =
                (string.IsNullOrEmpty(mensagemOperacao)
                    ? excecao.Message
                    : mensagemOperacao
                    );
        }
    }
}
