using dominio;
using negocio;
using presentacion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;


namespace presentacion
{
    public partial class FrmAgregar : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
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
            if (!validarFiltros()) {
                MessageBox.Show("Faltan cargar campos obligatorios.");
                return;
            }

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxNombre.Text;
                articulo.Descripcion = string.IsNullOrEmpty(tbxDescripcion.Text) ? null : tbxDescripcion.Text;
                articulo.Precio = numPrecio.Value;
                articulo.ImagenUrl = string.IsNullOrEmpty(tbxImagen.Text) ? null : tbxImagen.Text;
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
                if (archivo != null && !(tbxImagen.Text.ToUpper().Contains("HTTP")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);

                Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar articulo, contactese con el administrador.");
                Console.WriteLine(ex.ToString());
            }
        }

        private bool validarFiltros() 
        {
            bool esValido = true;
            if (!validarDatos(tbxCodigo)) 
                esValido = false;
            if (!validarDatos(tbxNombre)) 
                esValido = false;
            if (!validarDatos(comboMarca)) 
                esValido = false;
            if (!validarDatos(comboCategoria)) 
                esValido = false;

            return esValido;
        }
        private bool validarDatos(TextBox tb)
        {
            if (tb.Text == null || tb.Text == "")
            {
                tb.BackColor = Color.MistyRose;
                return false;
            }
            else
            {
                tb.BackColor = SystemColors.Window;
                return true;
            }

        }
        private bool validarDatos(ComboBox cb)
        {
            if (cb.SelectedIndex < 0)
            {
                cb.BackColor = Color.MistyRose;
                return false;
            }
            else
            {
                cb.BackColor = SystemColors.Window;
                return true;
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
                    HelperImage.CargarImagen(pictureBoxAlta, tbxImagen.Text);
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

        private void btnAgregarImg_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg|png|*.png";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                tbxImagen.Text = archivo.FileName;
                HelperImage.CargarImagen(pictureBoxAlta, archivo.FileName);


            }
        }
    }
}
