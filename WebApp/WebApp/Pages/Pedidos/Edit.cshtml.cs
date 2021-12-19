using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Pedidos
{
    public class EditModel : PageModel
    {
        private readonly IPedidosService PedidosService;
        private readonly IClientesService ClientesService;
        private readonly IProductosService ProductosService;

        public EditModel(IPedidosService PedidosService, IClientesService ClientesService, IProductosService ProductosService)
        {
            this.PedidosService = PedidosService;
            this.ClientesService = ClientesService;
            this.ProductosService = ProductosService;
        }

        [BindProperty]
        [FromBody]

        public PedidosEntity Entity { get; set; } = new PedidosEntity();

        public IEnumerable<ClientesEntity> ClientesLista { get; set; } = new List<ClientesEntity>();
        public IEnumerable<ProductosEntity> ProductosLista { get; set; } = new List<ProductosEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await PedidosService.GetById(new() { Codigo = id });
                }

                ClientesLista = await ClientesService.Get();
                ProductosLista = await ProductosService.Get();

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
                Entity.Subtotal = Entity.Cantidad * 2000;
                Entity.Envio = (float)(Entity.Subtotal * 0.15);
                Entity.Impuestos = (float)(Entity.Subtotal * 0.13);
                Entity.Total = Entity.Subtotal + Entity.Envio + Entity.Impuestos;
                if (Entity.Codigo.HasValue)
                {
                     result = await PedidosService.Update(Entity);

               
                }
                else
                {
                     result = await PedidosService.Create(Entity);

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
