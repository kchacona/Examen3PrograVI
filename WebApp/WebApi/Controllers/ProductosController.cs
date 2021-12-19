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
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService ProductosService;

        public ProductosController(IProductosService ProductosService)
        {
            this.ProductosService = ProductosService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductosEntity>> Get()
        {
            try
            {
                return await ProductosService.Get();
            }
            catch (Exception ex)
            {

                return new List<ProductosEntity>();
            }       
        
        
        }

        [HttpGet("{id}")]
        public async Task<ProductosEntity> Get(int id)
        {
            try
            {
                return await ProductosService.GetById( new ProductosEntity { Id_Productos= id});
            }
            catch (Exception ex)
            {

                return new ProductosEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }


        [HttpPost]
        public async Task<DBEntity> Create(ProductosEntity entity)
        {
            try
            {
                return await ProductosService.Create(entity);
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }


        [HttpPut]
        public async Task<DBEntity> Update(ProductosEntity entity)
        {
            try
            {
                return await ProductosService.Update(entity);
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
                return await ProductosService.Delete(new ProductosEntity() { Id_Productos = id });
            }
            catch (Exception ex)
            {

                return new DBEntity { CodeError = ex.HResult, MsgError = ex.Message };
            }


        }





    }
}
