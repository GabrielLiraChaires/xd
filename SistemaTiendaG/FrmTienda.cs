using System;
using System.Windows.Forms;
using Entidades.SistemaTiendaG;
using LogicaNegocio.SistemaTiendaG;
namespace SistemaTiendaG
{
    public partial class FrmTienda : Form
    {
        private ProductosManejador _productoManejador;
        private string _Bandera;
        public FrmTienda()
        {
            InitializeComponent();
            _productoManejador = new ProductosManejador();  
        }
        //Metodos Normales.
        private void LLenarProductos(string dato)
        {
            dgvProductos.DataSource = _productoManejador.GetProductos(dato);
        }
        private void ControlarBotones(bool nuevo, bool guardar, bool cancelar, bool eliminar, bool salir)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnCancelar.Enabled = cancelar;
            btnEliminar.Enabled = eliminar;
            btnSalir.Enabled = salir;
        }
        private void LimpiarCampos()
        {
            txtIDProducto.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
        private void ControlarCampos(bool control)
        {
            txtIDProducto.Enabled=control;
            txtNombre.Enabled = control;
            txtDescripcion.Enabled = control;
            txtPrecio.Enabled = control;
        }
        private void GuardarProducto()
        {
            Productos producto = new Productos();
            producto.Idproducto= Convert.ToInt32(txtIDProducto.Text);
            producto.Nombre = txtNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Precio = Convert.ToDouble(txtPrecio.Text);

            _productoManejador.GuardarProductos(producto);
        }
        //Metodos del formulario.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlarBotones(true, false, false, true, true);
                if (_Bandera == "guardar")
                {
                    GuardarProducto();
                    LLenarProductos("");
                    MessageBox.Show("Se guardo correctamente");
                }
                else
                {
                    /*ModificarProducto();
                    LLenarProductos("");
                    MessageBox.Show("Se actualizó correctamente");*/
                }
                LimpiarCampos();
                ControlarCampos(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _Bandera = "actualizar";
            try
            {
                txtIDProducto.Text = dgvProductos.CurrentRow.Cells["idproducto"].Value.ToString();
                txtNombre.Text=dgvProductos.CurrentRow.Cells["nombre"].Value.ToString();
                txtDescripcion.Text=dgvProductos.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrecio.Text=dgvProductos.CurrentRow.Cells["precio"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar actualizar");
            }
        }

        private void FrmTienda_Load(object sender, EventArgs e)
        {
            LLenarProductos("");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ControlarBotones(false, true, true, false, false);
            ControlarCampos(true);
            _Bandera = "guardar";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ControlarBotones(true, false, false, true, true);
            LimpiarCampos();
            ControlarCampos(false);
        }
    }
}
