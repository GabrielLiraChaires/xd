using System.Collections.Generic;
using AccesoDatos.SistemaTiendaG;
using Entidades.SistemaTiendaG;
namespace LogicaNegocio.SistemaTiendaG
{
    public class ProductosManejador
    {
        private ProductosAccesoDatos _productosAccesoDatos = new ProductosAccesoDatos();
        public List<Productos> GetProductos(string dato)
        {
            var listProductos = _productosAccesoDatos.GetProductos(dato);
            return listProductos;
        }
        public void GuardarProductos(Productos producto)
        {
            _productosAccesoDatos.GuardarProductos(producto);
        }
    }
}
