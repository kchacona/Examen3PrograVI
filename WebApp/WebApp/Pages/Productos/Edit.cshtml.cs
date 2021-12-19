using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Productos
{
    public class EditModel : PageModel
    {
        private readonly IProductosService ProductosService;

        public EditModel(IProductosService ProductosService)
        {
            this.ProductosService = ProductosService;
        }

        [BindProperty]
        [FromBody]

        public ProductosEntity Entity { get; set; } = new ProductosEntity();


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await ProductosService.GetById(new() { Id_Productos = id });
                }


                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }

        public async Task<IActionResult> OnPost()
        {

            try
            {
                var result = new DBEntity();
                if (Entity.Id_Productos.HasValue)
                {
                     result = await ProductosService.Update(Entity);

               
                }
                else
                {
                     result = await ProductosService.Create(Entity);

                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }


        }

    }
}
