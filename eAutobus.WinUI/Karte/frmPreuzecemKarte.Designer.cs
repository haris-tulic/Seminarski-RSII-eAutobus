
namespace eAutobus.WinUI.Karte
{
    partial class frmPreuzecemKarte
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
            dgvPrikazKarata = new DataGridView();
            label1 = new Label();
            KartaID = new DataGridViewTextBoxColumn();
            ImePrezimeKupca = new DataGridViewTextBoxColumn();
            VrstaKarte = new DataGridViewTextBoxColumn();
            TipKarte = new DataGridViewTextBoxColumn();
            Relacija = new DataGridViewTextBoxColumn();
            DatumVadjenja = new DataGridViewTextBoxColumn();
            DatumVazenja = new DataGridViewTextBoxColumn();
            Cijena = new DataGridViewTextBoxColumn();
            JeLiPlacena = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvPrikazKarata).BeginInit();
            SuspendLayout();
            // 
            // dgvPrikazKarata
            // 
            dgvPrikazKarata.AllowUserToAddRows = false;
            dgvPrikazKarata.AllowUserToDeleteRows = false;
            dgvPrikazKarata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrikazKarata.Columns.AddRange(new DataGridViewColumn[] { KartaID, ImePrezimeKupca, VrstaKarte, TipKarte, Relacija, DatumVadjenja, DatumVazenja, Cijena, JeLiPlacena });
            dgvPrikazKarata.Location = new Point(56, 200);
            dgvPrikazKarata.Margin = new Padding(3, 2, 3, 2);
            dgvPrikazKarata.Name = "dgvPrikazKarata";
            dgvPrikazKarata.ReadOnly = true;
            dgvPrikazKarata.RowHeadersWidth = 51;
            dgvPrikazKarata.RowTemplate.Height = 24;
            dgvPrikazKarata.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrikazKarata.Size = new Size(1054, 446);
            dgvPrikazKarata.TabIndex = 0;
            dgvPrikazKarata.CellContentClick += dgvPrikazKarata_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(363, 74);
            label1.Name = "label1";
            label1.Size = new Size(235, 26);
            label1.TabIndex = 1;
            label1.Text = "Plaćanje preuzećem:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // KartaID
            // 
            KartaID.DataPropertyName = "KartaID";
            KartaID.HeaderText = "KartaID";
            KartaID.MinimumWidth = 6;
            KartaID.Name = "KartaID";
            KartaID.ReadOnly = true;
            KartaID.Visible = false;
            KartaID.Width = 125;
            // 
            // ImePrezimeKupca
            // 
            ImePrezimeKupca.DataPropertyName = "ImePrezimeKupca";
            ImePrezimeKupca.HeaderText = "Ime i prezime";
            ImePrezimeKupca.MinimumWidth = 6;
            ImePrezimeKupca.Name = "ImePrezimeKupca";
            ImePrezimeKupca.ReadOnly = true;
            ImePrezimeKupca.Width = 125;
            // 
            // VrstaKarte
            // 
            VrstaKarte.DataPropertyName = "VrstaKarte";
            VrstaKarte.HeaderText = "Vrsta karte";
            VrstaKarte.MinimumWidth = 6;
            VrstaKarte.Name = "VrstaKarte";
            VrstaKarte.ReadOnly = true;
            VrstaKarte.Width = 125;
            // 
            // TipKarte
            // 
            TipKarte.DataPropertyName = "TipKarte";
            TipKarte.HeaderText = "Tip karte";
            TipKarte.MinimumWidth = 6;
            TipKarte.Name = "TipKarte";
            TipKarte.ReadOnly = true;
            TipKarte.Width = 125;
            // 
            // Relacija
            // 
            Relacija.DataPropertyName = "Relacija";
            Relacija.HeaderText = "Relacija";
            Relacija.MinimumWidth = 6;
            Relacija.Name = "Relacija";
            Relacija.ReadOnly = true;
            Relacija.Width = 125;
            // 
            // DatumVadjenja
            // 
            DatumVadjenja.DataPropertyName = "DatumVadjenjaKarte";
            DatumVadjenja.HeaderText = "Datum izdavanja";
            DatumVadjenja.MinimumWidth = 6;
            DatumVadjenja.Name = "DatumVadjenja";
            DatumVadjenja.ReadOnly = true;
            DatumVadjenja.Width = 125;
            // 
            // DatumVazenja
            // 
            DatumVazenja.DataPropertyName = "DatumVazenjaKarte";
            DatumVazenja.HeaderText = "Datum isteka";
            DatumVazenja.MinimumWidth = 6;
            DatumVazenja.Name = "DatumVazenja";
            DatumVazenja.ReadOnly = true;
            DatumVazenja.Width = 125;
            // 
            // Cijena
            // 
            Cijena.DataPropertyName = "CijenaString";
            Cijena.HeaderText = "Cijena";
            Cijena.MinimumWidth = 6;
            Cijena.Name = "Cijena";
            Cijena.ReadOnly = true;
            Cijena.Width = 125;
            // 
            // JeLiPlacena
            // 
            JeLiPlacena.DataPropertyName = "JeLiPlacena";
            JeLiPlacena.HeaderText = "Placena";
            JeLiPlacena.MinimumWidth = 6;
            JeLiPlacena.Name = "JeLiPlacena";
            JeLiPlacena.ReadOnly = true;
            JeLiPlacena.Width = 125;
            // 
            // frmPreuzecemKarte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 736);
            Controls.Add(label1);
            Controls.Add(dgvPrikazKarata);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmPreuzecemKarte";
            Text = "frmPreuzecemKarte";
            Load += frmPreuzecemKarte_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrikazKarata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPrikazKarata;
        private Label label1;
        private DataGridViewTextBoxColumn KartaID;
        private DataGridViewTextBoxColumn ImePrezimeKupca;
        private DataGridViewTextBoxColumn VrstaKarte;
        private DataGridViewTextBoxColumn TipKarte;
        private DataGridViewTextBoxColumn Relacija;
        private DataGridViewTextBoxColumn DatumVadjenja;
        private DataGridViewTextBoxColumn DatumVazenja;
        private DataGridViewTextBoxColumn Cijena;
        private DataGridViewCheckBoxColumn JeLiPlacena;
    }
}