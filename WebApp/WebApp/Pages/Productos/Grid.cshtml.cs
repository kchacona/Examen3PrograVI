using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Productos
{
    public class GridModel : PageModel
    {
        private readonly IProductosService ProductosService;

        public GridModel(IProductosService ProductosService)
        {
            this.ProductosService = ProductosService;
        }
        public IEnumerable<ProductosEntity> GridList { get; set; } = new List<ProductosEntity>();

        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await ProductosService.Get();
             

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
                var result = await ProductosService.Delete(new() { Id_Productos = id });

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }









    }
}
