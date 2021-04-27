using Citel.Api.Controllers.Base.Util;
using Citel.Core.Model;
using Citel.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private IProdutoService iProdutoService;

        public ProdutosController(IProdutoService iProdutoService)
        {
            this.iProdutoService = iProdutoService;
        }

        [HttpGet]
        [Route(@"v1/Get/Produtos/Categoria/{codigoCategoria?}")]
        public IActionResult Get(long codigoCategoria)
        {
            var resultado = iProdutoService.Selecionar(new Produto() { CodCategoria = codigoCategoria });
            return RespostaApiUtil.ConfigurarRespostaPadraoApi(this, resultado, true);
        }

        [HttpGet]
        [Route(@"v1/Get/{codigoProduto?}/{codigoCategoria?}")]
        public IActionResult Get(long codigoProduto, long codigoCategoria)
        {
            var resultado = iProdutoService.SelecionarRegistro(new Produto() { CodCategoria = codigoCategoria, CodProduto = codigoProduto});
            return RespostaApiUtil.ConfigurarRespostaPadraoApi(this, resultado, true);
        }

        [HttpPost]
        [Route(@"v1/Post/")]
        public IActionResult Post(Produto categoria)
        {
            var resultado = iProdutoService.Inserir(categoria);
            return RespostaApiUtil.ConfigurarRespostaPadraoApi(this, resultado, true);
        }

        [HttpPut]
        [Route(@"v1/Put/")]
        public IActionResult Put(Produto categoria)
        {
            var resultado = iProdutoService.Atualizar(categoria);
            return RespostaApiUtil.ConfigurarRespostaPadraoApi(this, resultado, true);
        }

        [HttpDelete]
        [Route(@"v1/Delete/{codigoProduto?}/{codigoCategoria?}")]
        public IActionResult Delete(long codigoProduto, long codigoCategoria)
        {
            var resultado = iProdutoService.Remover(new Produto() { CodProduto = codigoProduto, CodCategoria = codigoCategoria });
            return RespostaApiUtil.ConfigurarRespostaPadraoApi(this, resultado, true);
        }

    }
}
