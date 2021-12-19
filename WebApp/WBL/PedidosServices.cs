using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IPedidosService
    {
        Task<DBEntity> Create(PedidosEntity entity);
        Task<DBEntity> Delete(PedidosEntity entity);
        Task<IEnumerable<PedidosEntity>> Get();
        Task<PedidosEntity> GetById(PedidosEntity entity);
        Task<DBEntity> Update(PedidosEntity entity);
    }

    public class PedidosService : IPedidosService
    {
        private readonly IDataAccess sql;

        public PedidosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCrud

        //Metodo Get


        public async Task<IEnumerable<PedidosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<PedidosEntity>("dbo.PedidosObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Metodo GetById
        public async Task<PedidosEntity> GetById(PedidosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<PedidosEntity>("dbo.PedidosObtener", new
                { entity.Codigo });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Create

        public async Task<DBEntity> Create(PedidosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.PedidosInsertar", new
                {
                    entity.Cliente,
                    entity.fechaPedido,
                    entity.Producto,
                    entity.Cantidad,
                    entity.Subtotal,
                    entity.Envio,
                    entity.Impuestos,
                    entity.Total



                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Update
        public async Task<DBEntity> Update(PedidosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.PedidosActualizar", new
                {
                    entity.Codigo,
                    entity.Cliente,
                    entity.fechaPedido,
                    entity.Producto,
                    entity.Cantidad,
                    entity.Subtotal,
                    entity.Envio,
                    entity.Impuestos,
                    entity.Total


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Delete
        public async Task<DBEntity> Delete(PedidosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.PedidosEliminar", new
                {
                    entity.Codigo,

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
