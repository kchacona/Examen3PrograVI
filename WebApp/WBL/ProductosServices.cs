using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IProductosService
    {
        Task<DBEntity> Create(ProductosEntity entity);
        Task<DBEntity> Delete(ProductosEntity entity);
        Task<IEnumerable<ProductosEntity>> Get();
        Task<ProductosEntity> GetById(ProductosEntity entity);
        Task<DBEntity> Update(ProductosEntity entity);
    }

    public class ProductosService : IProductosService
    {
        private readonly IDataAccess sql;

        public ProductosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCrud

        //Metodo Get


        public async Task<IEnumerable<ProductosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ProductosEntity>("dbo.ProductosObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Metodo GetById
        public async Task<ProductosEntity> GetById(ProductosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ProductosEntity>("dbo.ProductosObtener", new
                { entity.Id_Productos });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Create

        public async Task<DBEntity> Create(ProductosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProductosInsertar", new
                {
                    entity.Categoria,
                    entity.Nombre,
                    entity.Cantidad_Disponible,
                    entity.Caracteristica,
                    entity.Estado



                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Update
        public async Task<DBEntity> Update(ProductosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProductosActualizar", new
                {
                    entity.Id_Productos,
                    entity.Categoria,
                    entity.Nombre,
                    entity.Cantidad_Disponible,
                    entity.Caracteristica,
                    entity.Estado


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Delete
        public async Task<DBEntity> Delete(ProductosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProductosEliminar", new
                {
                    entity.Id_Productos,

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }






        #endregion



    }
}
