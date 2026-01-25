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
    public partial class FrmAltaOpcional : Form
    {
        public string TextoIngresado { get; private set; }

        public FrmAltaOpcional(string titulo)
        {
            InitializeComponent();
            this.Text = "Nueva " + titulo;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxNuevaMarcaCat.Text))
            {
                MessageBox.Show("Debe escribir un nombre.");
                return;
            }

            TextoIngresado = tbxNuevaMarcaCat.Text; 
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
