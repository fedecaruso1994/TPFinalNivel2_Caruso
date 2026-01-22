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
using presentacion.Helpers; 

namespace presentacion
{
    public partial class FrmDetalle : Form
    {
        
        private Articulo articuloSeleccionado;

        public FrmDetalle(Articulo articulo)
        {
            InitializeComponent();
            this.articuloSeleccionado = articulo; // Lo asignamos a nuestra variable privada
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            // Cargamos los datos en los Labels
            // Asumo que pusiste labels con estos nombres:
            lblCodigoDetalle.Text = articuloSeleccionado.Codigo;
            lblNombreDetalle.Text = articuloSeleccionado.Nombre;
            lblDescripcionDetalle.Text = articuloSeleccionado.Descripcion;
            lblMarcaDetalle.Text = articuloSeleccionado.Marca.Descripcion;
            lblCategoriaDetalle.Text = articuloSeleccionado.Categoria.Descripcion;
            lblPrecioDetalle.Text = "$ " + articuloSeleccionado.Precio.ToString("0.00"); // Formato moneda

            // Cargamos la imagen usando tu Helper
            HelperImage.CargarImagen(pbxDetalle, articuloSeleccionado.ImagenUrl);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
