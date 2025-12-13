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
        private Articulo articulo = null;
        public FrmAgregar()
        {
            InitializeComponent();
        }
        public FrmAgregar(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Artículo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxNombre.Text;
                articulo.Descripcion = tbxCodigo.Text;
                articulo.Precio = numPrecio.Value;
                articulo.ImagenUrl = tbxImagen.Text;
                articulo.Categoria = (Categoria)comboCategoria.SelectedItem;
                articulo.Marca = (Marca)comboMarca.SelectedItem;

                if (articulo.Id != 0)
                {
                    articuloNegocio.Modificar(articulo);
                    MessageBox.Show("Artículo modificado con éxito.");
                }
                else
                {
                    articuloNegocio.Agregar(articulo);
                    MessageBox.Show("Artículo agregado con éxito.");
                }
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
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                comboCategoria.DataSource = categoriaNegocio.Listar();
                comboCategoria.ValueMember = "Id";
                comboCategoria.DisplayMember = "Descripcion";
                comboMarca.DataSource = marcaNegocio.Listar();
                comboMarca.ValueMember = "Id";
                comboMarca.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    tbxCodigo.Text = articulo.Codigo;
                    tbxNombre.Text = articulo.Nombre;
                    tbxDescripcion.Text = articulo.Descripcion;
                    tbxImagen.Text = articulo.ImagenUrl;
                    numPrecio.Value = articulo.Precio;
                    HelperImage.CargarImagen(pictureBoxAlta, articulo.ImagenUrl);
                    comboCategoria.SelectedValue = articulo.Categoria.Id;
                    comboMarca.SelectedValue = articulo.Marca.Id;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Ha ocurrido un error.");
            }
        }

        private void tbxImagen_Leave(object sender, EventArgs e)
        {
            HelperImage.CargarImagen(pictureBoxAlta, tbxImagen.Text);
        }
    }
}
