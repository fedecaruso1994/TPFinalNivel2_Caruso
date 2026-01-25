namespace presentacion
{
    partial class FrmPapelera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPapelera = new System.Windows.Forms.DataGridView();
            this.btnVaciar = new System.Windows.Forms.Button();
            this.btnReactivar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPapelera)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPapelera
            // 
            this.dgvPapelera.AllowUserToAddRows = false;
            this.dgvPapelera.AllowUserToResizeColumns = false;
            this.dgvPapelera.AllowUserToResizeRows = false;
            this.dgvPapelera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPapelera.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPapelera.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPapelera.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPapelera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPapelera.ColumnHeadersHeight = 30;
            this.dgvPapelera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPapelera.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPapelera.EnableHeadersVisualStyles = false;
            this.dgvPapelera.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvPapelera.Location = new System.Drawing.Point(34, 40);
            this.dgvPapelera.MultiSelect = true;
            this.dgvPapelera.Name = "dgvPapelera";
            this.dgvPapelera.RowHeadersVisible = false;
            this.dgvPapelera.RowHeadersWidth = 62;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvPapelera.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPapelera.RowTemplate.Height = 28;
            this.dgvPapelera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPapelera.Size = new System.Drawing.Size(900, 361);
            this.dgvPapelera.TabIndex = 0;
            // 
            // btnVaciar
            // 
            this.btnVaciar.BackColor = System.Drawing.Color.IndianRed;
            this.btnVaciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVaciar.FlatAppearance.BorderSize = 0;
            this.btnVaciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVaciar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVaciar.ForeColor = System.Drawing.Color.White;
            this.btnVaciar.Location = new System.Drawing.Point(190, 430); 
            this.btnVaciar.Name = "btnVaciar";
            this.btnVaciar.Size = new System.Drawing.Size(140, 45); 
            this.btnVaciar.TabIndex = 1;
            this.btnVaciar.Text = "Vaciar"; 
            this.btnVaciar.UseVisualStyleBackColor = false;
            this.btnVaciar.Click += new System.EventHandler(this.btnEliminarFisico_Click);
            // 
            // btnReactivar
            // 
            this.btnReactivar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReactivar.FlatAppearance.BorderSize = 0;
            this.btnReactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReactivar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReactivar.ForeColor = System.Drawing.Color.White;
            this.btnReactivar.Location = new System.Drawing.Point(34, 430);
            this.btnReactivar.Name = "btnReactivar";
            this.btnReactivar.Size = new System.Drawing.Size(140, 45);
            this.btnReactivar.TabIndex = 2;
            this.btnReactivar.Text = "Reactivar";
            this.btnReactivar.UseVisualStyleBackColor = false;
            this.btnReactivar.Click += new System.EventHandler(this.btnReactivar_Click);
            // 
            // FrmPapelera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(973, 508);
            this.Controls.Add(this.btnReactivar);
            this.Controls.Add(this.btnVaciar);
            this.Controls.Add(this.dgvPapelera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPapelera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Papelera de Reciclaje";
            this.Load += new System.EventHandler(this.FrmPapelera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPapelera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPapelera;
        private System.Windows.Forms.Button btnVaciar;
        private System.Windows.Forms.Button btnReactivar;
    }
}