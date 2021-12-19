using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
using Entity;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService PedidosService;

        public PedidosController(IPedidosService PedidosService)
        {
            this.PedidosService = PedidosService;
        }

        [HttpGet]
        public async Task<IEnumerable<PedidosEntity>> Get()
        {
            try
            {
                return await PedidosService.Get();
            }
            catch (Exception ex)
            {

                return new List<PedidosEntity>();
            }       
        
        
        }

        [HttpGet("{id}")]
        public async Task<PedidosEntity> Get(int id)
        {
            try
            {
                return await PedidosService.GetById( new PedidosEntity { Codigo= id});
            }
            catch (Exception ex)
            {

                return new PedidosEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }


        [HttpPost]
        public async Task<DBEntity> Create(PedidosEntity entity)
        {
            try
            {
                return await PedidosService.Create(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }


        [HttpPut]
        public async Task<DBEntity> Update(PedidosEntity entity)
        {
            try
            {
                return await PedidosService.Update(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }

        [HttpDelete("{id}")]
        public async Task<DBEntity> Delete(int id)
        {
            try
            {
                return await PedidosService.Delete(new PedidosEntity() { Codigo = id });
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }





    }
}
