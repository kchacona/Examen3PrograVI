"use strict";
var PedidosGrid;
(function (PedidosGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando");
                App.AxiosProvider.PedidosEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "Se elimino correctamente", icon: "success" }).then(function () { return window.location.reload(); });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    PedidosGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(PedidosGrid || (PedidosGrid = {}));
//# sourceMappingURL=Grid.js.map