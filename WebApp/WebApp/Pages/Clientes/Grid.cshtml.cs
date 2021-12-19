using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Clientes
{
    public class GridModel : PageModel
    {
        private readonly IClientesService ClientesService;

        public GridModel(IClientesService ClientesService)
        {
            this.ClientesService = ClientesService;
        }
        public IEnumerable<ClientesEntity> GridList { get; set; } = new List<ClientesEntity>();

        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await ClientesService.Get();
             

                return Page();

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnDeleteEliminar(int id)
        {

            try
            {
                var result = await ClientesService.Delete(new() { Cedula = id });

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }









    }
}
