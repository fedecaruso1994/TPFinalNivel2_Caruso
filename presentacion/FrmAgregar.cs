using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace presentacion
{
    public partial class FrmAgregar : Form
    {
        public FrmAgregar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {   
            Articulo articulo = new Articulo();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxCodigo.Text;
                articulo.Descripcion = tbxCodigo.Text;
                articulo.Precio = numPrecio.Value;

                articuloNegocio.Agregar(articulo);
                MessageBox.Show("Artículo agregado con éxito.");
                Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar articulo, contactese con el administrador.");
                Console.WriteLine(ex.ToString());
            }
        }

        private void numPrecio_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
