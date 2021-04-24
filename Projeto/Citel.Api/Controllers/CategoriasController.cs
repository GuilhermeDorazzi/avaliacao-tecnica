using Citel.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            iCategoriaService.Inserir(new Core.Model.Categoria() {});
            return Ok("teste de inejção de dependencia OK");
        }
    }
}
