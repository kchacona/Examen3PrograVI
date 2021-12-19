using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Pedidos
{
    public class GridModel : PageModel
    {
        private readonly IPedidosService PedidosService;

        public GridModel(IPedidosService PedidosService)
        {
            this.PedidosService = PedidosService;
        }

        public IEnumerable<PedidosEntity> GridList { get; set; } = new List<PedidosEntity>();

        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await PedidosService.Get();
             

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
                var result = await PedidosService.Delete(new() { Codigo = id });

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }









    }
}
