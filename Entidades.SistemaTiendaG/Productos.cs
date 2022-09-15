namespace Entidades.SistemaTiendaG
{
    public class Productos
    {
        private int _idproducto;
        private string _nombre;
        private string _descripcion;
        private double _precio;

        public int Idproducto { get => _idproducto; set => _idproducto = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double Precio { get => _precio; set => _precio = value; }
    }
}
