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
using presentacion.Helpers;

namespace presentacion
{
    public partial class frmArticulos : Form
    {
        private List<Articulo> listadoArticulos;
        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
                cargar();

        }
        private void cargar()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                listadoArticulos = articuloNegocio.Listar();
                dgvArticulos.DataSource = listadoArticulos;
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("No se pudo cargar la lista de articulos.");
            }
        }
        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
        }
        
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                HelperImage.CargarImagen(pictureArticulo, seleccionado.ImagenUrl);    
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregar agregarArticulo = new FrmAgregar();
            agregarArticulo.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            FrmAgregar modiicarArticulo = new FrmAgregar(seleccionado);
            modiicarArticulo.ShowDialog();
            cargar();
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true); 
        }

        private void eliminar(bool logico = false)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Desea confirmar la eliminacion?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    if (logico) 
                        negocio.EliminarLogico(seleccionado.Id);
                     //TO DO: Agregar eliminar fisico
                    cargar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("No es posible eliminar, ha ocurrido un error.");

            }
        }
    }


}
