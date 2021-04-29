using Citel.Api.Controllers.Base.Util;
using Citel.Core.Model;
using Citel.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private ICategoriaService iCategoriaService;

        public CategoriasController(ICategoriaService iCategoriaService)
        {
            this.iCategoriaService = iCategoriaService;
        }

        [HttpGet]
        [Route(@"v1/Get/")]
        public IActionResult Get()
        {
            var resultado = iCategoriaService.Selecionar(new Categoria());
            return RespostaApiUtil.ConfigurarRespostaPadraoApi(this, resultado, true);
        }

        [HttpGet]
        [Route(@"v1/Get/{codigo?}")]
        public IActionResult Get(long codigo)
        {
            var resultado = iCategoriaService.SelecionarRegistro(new Categoria() { CodCategoria = codigo });
            return RespostaApiUtil.ConfigurarRespostaPadraoApi(this, resultado, true);
        }

        [HttpPost]
        [Route(@"v1/Post/")]
        public IActionResult Post(Categoria categoria)
        {
            var resultado = iCategoriaService.Inserir(categoria);
            return RespostaApiUtil.ConfigurarRespostaPadraoApi(this, resultado, true);
        }

        [HttpPut]
        [Route(@"v1/Put/")]
        public IActionResult Put(Categoria categoria)
        {
            var resultado = iCategoriaService.Atualizar(categoria);
            return RespostaApiUtil.ConfigurarRespostaPadraoApi(this, resultado, true);
        }

        [HttpDelete]
        [Route(@"v1/Delete/{codigo?}")]
        public IActionResult Delete(long codigo)
        {
            var resultado = iCategoriaService.Remover(new Categoria() { CodCategoria = codigo });
            return RespostaApiUtil.ConfigurarRespostaPadraoApi(this, resultado, true);
        }

    }
}
