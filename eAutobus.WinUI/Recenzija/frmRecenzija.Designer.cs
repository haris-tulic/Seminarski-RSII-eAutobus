
namespace eAutobus.WinUI.Recenzija
{
    partial class frmRecenzija
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
            label1 = new Label();
            nmOcjena = new NumericUpDown();
            btnFiltriraj = new Button();
            dgvRecenzije = new DataGridView();
            RecenzijaID = new DataGridViewTextBoxColumn();
            Vrsta = new DataGridViewTextBoxColumn();
            Relacija = new DataGridViewTextBoxColumn();
            DatumRecenzije = new DataGridViewTextBoxColumn();
            Ocjena = new DataGridViewTextBoxColumn();
            Komentar = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)nmOcjena).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRecenzije).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(360, 101);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Ocjena:";
            // 
            // nmOcjena
            // 
            nmOcjena.Location = new Point(430, 99);
            nmOcjena.Margin = new Padding(4);
            nmOcjena.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nmOcjena.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nmOcjena.Name = "nmOcjena";
            nmOcjena.Size = new Size(81, 23);
            nmOcjena.TabIndex = 1;
            nmOcjena.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnFiltriraj
            // 
            btnFiltriraj.Location = new Point(424, 170);
            btnFiltriraj.Margin = new Padding(4);
            btnFiltriraj.Name = "btnFiltriraj";
            btnFiltriraj.Size = new Size(88, 26);
            btnFiltriraj.TabIndex = 2;
            btnFiltriraj.Text = "Filtriraj";
            btnFiltriraj.UseVisualStyleBackColor = true;
            btnFiltriraj.Click += btnFiltriraj_Click;
            // 
            // dgvRecenzije
            // 
            dgvRecenzije.AllowUserToAddRows = false;
            dgvRecenzije.AllowUserToDeleteRows = false;
            dgvRecenzije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecenzije.Columns.AddRange(new DataGridViewColumn[] { RecenzijaID, Vrsta, Relacija, DatumRecenzije, Ocjena, Komentar });
            dgvRecenzije.Location = new Point(156, 231);
            dgvRecenzije.Margin = new Padding(4);
            dgvRecenzije.Name = "dgvRecenzije";
            dgvRecenzije.ReadOnly = true;
            dgvRecenzije.RowHeadersWidth = 51;
            dgvRecenzije.Size = new Size(685, 264);
            dgvRecenzije.TabIndex = 3;
            // 
            // RecenzijaID
            // 
            RecenzijaID.DataPropertyName = "RecenzijaID";
            RecenzijaID.HeaderText = "ID";
            RecenzijaID.MinimumWidth = 6;
            RecenzijaID.Name = "RecenzijaID";
            RecenzijaID.ReadOnly = true;
            RecenzijaID.Visible = false;
            RecenzijaID.Width = 125;
            // 
            // Vrsta
            // 
            Vrsta.DataPropertyName = "VrstaUsluga";
            Vrsta.HeaderText = "Vrsta";
            Vrsta.MinimumWidth = 6;
            Vrsta.Name = "Vrsta";
            Vrsta.ReadOnly = true;
            Vrsta.Width = 125;
            // 
            // Relacija
            // 
            Relacija.DataPropertyName = "RasporedVoznje";
            Relacija.HeaderText = "Relacija";
            Relacija.MinimumWidth = 6;
            Relacija.Name = "Relacija";
            Relacija.ReadOnly = true;
            Relacija.Width = 125;
            // 
            // DatumRecenzije
            // 
            DatumRecenzije.DataPropertyName = "DatumRecenzije";
            DatumRecenzije.HeaderText = "Datum  recenzije";
            DatumRecenzije.MinimumWidth = 6;
            DatumRecenzije.Name = "DatumRecenzije";
            DatumRecenzije.ReadOnly = true;
            DatumRecenzije.Width = 125;
            // 
            // Ocjena
            // 
            Ocjena.DataPropertyName = "Ocjena";
            Ocjena.HeaderText = "Ocjena";
            Ocjena.MinimumWidth = 6;
            Ocjena.Name = "Ocjena";
            Ocjena.ReadOnly = true;
            Ocjena.Width = 125;
            // 
            // Komentar
            // 
            Komentar.DataPropertyName = "Komentar";
            Komentar.HeaderText = "Komentar";
            Komentar.MinimumWidth = 6;
            Komentar.Name = "Komentar";
            Komentar.ReadOnly = true;
            Komentar.Width = 125;
            // 
            // frmRecenzija
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 580);
            Controls.Add(dgvRecenzije);
            Controls.Add(btnFiltriraj);
            Controls.Add(nmOcjena);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "frmRecenzija";
            Text = "frmRecenzija";
            Load += frmRecenzija_Load;
            ((System.ComponentModel.ISupportInitialize)nmOcjena).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRecenzije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown nmOcjena;
        private Button btnFiltriraj;
        private DataGridView dgvRecenzije;
        private DataGridViewTextBoxColumn RecenzijaID;
        private DataGridViewTextBoxColumn Vrsta;
        private DataGridViewTextBoxColumn Relacija;
        private DataGridViewTextBoxColumn DatumRecenzije;
        private DataGridViewTextBoxColumn Ocjena;
        private DataGridViewTextBoxColumn Komentar;
    }
}