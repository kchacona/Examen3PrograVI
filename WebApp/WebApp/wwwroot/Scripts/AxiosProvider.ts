
namespace App.AxiosProvider   {

    //export const GuardarEmpleado = () => axios.get<Entity.DBEntity>("aplicacion").then(({data})=>data );
    export const ClientesEliminar = (id) => axios.delete<DBEntity>("Clientes/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const ClientesGuardar = (entity) => axios.post<DBEntity>("Clientes/Edit", entity).then(({ data }) => data);

    export const ProductosEliminar = (id) => axios.delete<DBEntity>("Productos/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const ProductosGuardar = (entity) => axios.post<DBEntity>("Productos/Edit", entity).then(({ data }) => data);

    export const PedidosEliminar = (id) => axios.delete<DBEntity>("Pedidos/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const PedidosGuardar = (entity) => axios.post<DBEntity>("Pedidos/Edit", entity).then(({ data }) => data);
}




