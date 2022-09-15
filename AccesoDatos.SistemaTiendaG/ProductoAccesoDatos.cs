using System;
using System.Collections.Generic;
using Entidades.SistemaTiendaG;
using System.Data;
namespace AccesoDatos.SistemaTiendaG
{
    public class ProductosAccesoDatos
    {
        Conexion con;
        public ProductosAccesoDatos()
        {
            con = new Conexion("localhost", "root", "", "Tienda", 3306);
        }
        public void GuardarProductos(Productos producto)
        {
            string consulta = string.Format("Insert into producto values({0},'{1}','{2}',{3})", producto.Idproducto, producto.Nombre, producto.Descripcion, producto.Precio);
            con.EjecutarConsulta(consulta);
        }
        public List<Productos> GetProductos(string dato)
        {
            var listProductos = new List<Productos>();
            var ds = new DataSet();

            string consulta = string.Format("select * from producto where nombre like '%{0}%'", dato);
            ds = con.ObtenerDatos(consulta, "producto");

            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var producto = new Productos
                {
                    Idproducto = Convert.ToInt32(row["idproducto"]),
                    Nombre = row["nombre"].ToString(),
                    Descripcion = row["descripcion"].ToString(),
                    Precio = Convert.ToDouble(row["precio"])

                };
                listProductos.Add(producto);
            }
            return listProductos;
        }
    }
}
