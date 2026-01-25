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
    public partial class FrmPapelera : Form
    {
        public FrmPapelera()
        {
            InitializeComponent();
            
        }

        private void FrmPapelera_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                dgvPapelera.DataSource = negocio.ListarEliminados();
                formatearGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la papelera: " + ex.Message);
            }
        }

        private void formatearGrilla()
        {
            if (dgvPapelera.Rows.Count > 0)
            {
                dgvPapelera.Columns["Id"].Visible = false;
                dgvPapelera.Columns["ImagenUrl"].Visible = false;
                dgvPapelera.Columns["Precio"].DefaultCellStyle.Format = "C";
                dgvPapelera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // Botón REACTIVAR (Volver a la vida)
        private void btnReactivar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                
                if (dgvPapelera.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione al menos un artículo para reactivar.");
                    return;
                }

                
                foreach (DataGridViewRow fila in dgvPapelera.SelectedRows)
                {
                    Articulo seleccionado = (Articulo)fila.DataBoundItem;
                    negocio.Reactivar(seleccionado.Id);
                }

                cargar();
                MessageBox.Show("Artículos restaurados exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reactivar: " + ex.Message);
            }
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (dgvPapelera.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione al menos un artículo para eliminar.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de eliminar estos artículos permanentemente?\n\nEsta acción NO se puede deshacer y borrará los registros de la base de datos.",
                    "Eliminación Permanente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    foreach (DataGridViewRow fila in dgvPapelera.SelectedRows)
                    {
                        Articulo seleccionado = (Articulo)fila.DataBoundItem;
                        negocio.EliminarFisico(seleccionado.Id);
                    }

                    cargar();
                    MessageBox.Show("Artículos eliminados definitivamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

    }
}
