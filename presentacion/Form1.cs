using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
                formatearGrilla();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("No se pudo cargar la lista de articulos.");
            }
        }
        private void formatearGrilla()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C";
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
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("No hay elementos seleccionados.");
                return;
            }
                
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
                if (dgvArticulos.CurrentRow == null)
                {
                    MessageBox.Show("No hay elementos seleccionados.");
                    return;
                }
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

        private void btnFiltro_Click(object sender, EventArgs e)
        {

        }

        private void tbxFiltro_TextChanged(object sender, EventArgs e)
        {
            if (listadoArticulos == null)
                return;

            List<Articulo> listaFiltrada;
            string filtro = tbxFiltro.Text.ToUpper();
            numDesde.Value = 0;
            numHasta.Value = 0;

            if (filtro.Length > 2)
                listaFiltrada = listadoArticulos.FindAll(art => (art.Nombre ?? string.Empty).ToUpper().Contains(filtro) || (art.Codigo ?? string.Empty).ToUpper().Contains(filtro) || (art.Marca?.Descripcion ?? string.Empty).ToUpper().Contains(filtro) || (art.Categoria?.Descripcion ?? string.Empty).ToUpper().Contains(filtro));
            else
                listaFiltrada = listadoArticulos;

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            formatearGrilla();
        }

        private void btnBuscarPrecio_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaFiltrada;
            tbxFiltro.Text = string.Empty;

            try
            {

                decimal desde = numDesde.Value;
                decimal hasta = numHasta.Value;

                if (desde == 0 && hasta == 0)
                {
                    listaFiltrada = negocio.Listar();

                }
                if (hasta != 0 && desde > hasta)
                {
                    MessageBox.Show("Ingrese un rango válido para buscar.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    listaFiltrada = negocio.FiltrarPrecio(desde, hasta);
                }

                dgvArticulos.DataSource = null;
                dgvArticulos.DataSource = listaFiltrada;
                formatearGrilla();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("No se pudo filtrar los articulos correctamente.");
            }
        }

        private void numDesde_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
