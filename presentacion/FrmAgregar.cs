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
            if (articulo == null)
            {
                articulo = new Articulo();
            }
            try
            {
                if (archivo != null && !(tbxImagen.Text.ToUpper().Contains("HTTP")))
                {
                    string nombreArchivo = Path.GetFileName(archivo.FileName);
                    string fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string rutaDestino = ConfigurationManager.AppSettings["images-folder"] + fecha + "_" + nombreArchivo;

                    articulo.ImagenUrl = rutaDestino;

                    if (!Directory.Exists(ConfigurationManager.AppSettings["images-folder"]))
                    {
                        Directory.CreateDirectory(ConfigurationManager.AppSettings["images-folder"]);
                    }

                    File.Copy(archivo.FileName, rutaDestino);
                }
                else
                {
                    articulo.ImagenUrl = tbxImagen.Text;
                }

                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxNombre.Text;
                articulo.Descripcion = string.IsNullOrEmpty(tbxDescripcion.Text) ? null : tbxDescripcion.Text;
                articulo.Precio = numPrecio.Value;
                articulo.Marca = (Marca)comboMarca.SelectedItem;
                articulo.Categoria = (Categoria)comboCategoria.SelectedItem;

                string mensaje = "";

                if (articulo.Id != 0)
                {
                    articuloNegocio.Modificar(articulo);
                    mensaje = "Artículo modificado con éxito.";
                }
                else
                {
                    articuloNegocio.Agregar(articulo);
                    mensaje = "Artículo agregado con éxito.";
                }

                Close();
                MessageBox.Show(mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar articulo: " + ex.Message);
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

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            
            FrmAltaOpcional ventana = new FrmAltaOpcional("Marca");

            if (ventana.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca nueva = new Marca();
                    nueva.Descripcion = ventana.TextoIngresado;

                    negocio.Agregar(nueva);

                    comboMarca.DataSource = null;
                    comboMarca.DataSource = negocio.Listar();
                    comboMarca.ValueMember = "Id";
                    comboMarca.DisplayMember = "Descripcion";

                    comboMarca.SelectedIndex = comboMarca.FindString(ventana.TextoIngresado);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar marca: " + ex.Message);
                }
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            FrmAltaOpcional ventana = new FrmAltaOpcional("Categoría");

            if (ventana.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    Categoria nueva = new Categoria();
                    nueva.Descripcion = ventana.TextoIngresado;

                    negocio.Agregar(nueva);

                    comboCategoria.DataSource = null;
                    comboCategoria.DataSource = negocio.Listar();
                    comboCategoria.ValueMember = "Id";
                    comboCategoria.DisplayMember = "Descripcion";

                    comboCategoria.SelectedIndex = comboCategoria.FindString(ventana.TextoIngresado);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar categoría: " + ex.Message);
                }
            }
        }
    }
}
