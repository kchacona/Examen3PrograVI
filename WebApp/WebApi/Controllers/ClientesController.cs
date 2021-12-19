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
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService ClientesService;

        public ClientesController(IClientesService ClientesService)
        {
            this.ClientesService = ClientesService;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientesEntity>> Get()
        {
            try
            {
                return await ClientesService.Get();
            }
            catch (Exception ex)
            {

                return new List<ClientesEntity>();
            }       
        
        
        }

        [HttpGet("{id}")]
        public async Task<ClientesEntity> Get(int id)
        {
            try
            {
                return await ClientesService.GetById( new ClientesEntity { Cedula= id});
            }
            catch (Exception ex)
            {

                return new ClientesEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }


        [HttpPost]
        public async Task<DBEntity> Create(ClientesEntity entity)
        {
            try
            {
                return await ClientesService.Create(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }


        [HttpPut]
        public async Task<DBEntity> Update(ClientesEntity entity)
        {
            try
            {
                return await ClientesService.Update(entity);
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
                return await ClientesService.Delete(new ClientesEntity() { Cedula = id });
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }





    }
}
