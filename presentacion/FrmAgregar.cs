using dominio;
using negocio;
using presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
                articulo.ImagenUrl = txtImagen.Text;
                articulo.Categoria = (Categoria)comboCategoria.SelectedItem;
                articulo.Marca = (Marca)comboMarca.SelectedItem;

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

        private void FrmAgregar_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegopcio = new MarcaNegocio();
            try
            {
                comboCategoria.DataSource = categoriaNegocio.Listar();
                comboMarca.DataSource = marcaNegopcio.Listar();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Ha ocurrido un error.");
            }
        }

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            HelperImage.CargarImagen(pictureBoxAlta,txtImagen.Text);
        }
    }
}
