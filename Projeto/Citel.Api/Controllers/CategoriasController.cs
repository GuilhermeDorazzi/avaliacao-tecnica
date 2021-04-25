using Citel.Core.Model;
using Citel.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Api.Controllers
{
    public class CategoriasController : Controller
    {
        private ICategoriaService iCategoriaService;

        public CategoriasController(ICategoriaService iCategoriaService)
        {
            this.iCategoriaService = iCategoriaService;
        }

        [HttpGet("v1/teste/dependencias")]
        public IActionResult Index()
        {
            var resultado = iCategoriaService.Selecionar(new Categoria() {});
            return Ok(resultado);
        }
    }
}
