
namespace eAutobus.WinUI.Karte
{
    partial class frmOnlineKarte
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
            PlatiKartuID = new DataGridViewTextBoxColumn();
            ImePrezimeKupca = new DataGridViewTextBoxColumn();
            TipKarte = new DataGridViewTextBoxColumn();
            VrstaKarteNaziv = new DataGridViewTextBoxColumn();
            PolazisteOdrediste = new DataGridViewTextBoxColumn();
            DatumVadjenjaKarte = new DataGridViewTextBoxColumn();
            DatumVazenjaKarte = new DataGridViewTextBoxColumn();
            Cijena = new DataGridViewTextBoxColumn();
            JeLiPlacena = new DataGridViewCheckBoxColumn();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPrikazKarata).BeginInit();
            SuspendLayout();
            // 
            // dgvPrikazKarata
            // 
            dgvPrikazKarata.AllowUserToAddRows = false;
            dgvPrikazKarata.AllowUserToDeleteRows = false;
            dgvPrikazKarata.ColumnHeadersHeight = 29;
            dgvPrikazKarata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPrikazKarata.Columns.AddRange(new DataGridViewColumn[] { PlatiKartuID, ImePrezimeKupca, TipKarte, VrstaKarteNaziv, PolazisteOdrediste, DatumVadjenjaKarte, DatumVazenjaKarte, Cijena, JeLiPlacena });
            dgvPrikazKarata.Location = new Point(42, 210);
            dgvPrikazKarata.Margin = new Padding(3, 2, 3, 2);
            dgvPrikazKarata.Name = "dgvPrikazKarata";
            dgvPrikazKarata.ReadOnly = true;
            dgvPrikazKarata.RowHeadersWidth = 51;
            dgvPrikazKarata.RowTemplate.Height = 24;
            dgvPrikazKarata.Size = new Size(1054, 307);
            dgvPrikazKarata.TabIndex = 0;
            // 
            // PlatiKartuID
            // 
            PlatiKartuID.DataPropertyName = "PlatiKartuID";
            PlatiKartuID.HeaderText = "ID";
            PlatiKartuID.MinimumWidth = 6;
            PlatiKartuID.Name = "PlatiKartuID";
            PlatiKartuID.ReadOnly = true;
            PlatiKartuID.Visible = false;
            PlatiKartuID.Width = 125;
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
            // TipKarte
            // 
            TipKarte.DataPropertyName = "TipKarteNaziv";
            TipKarte.HeaderText = "Tip karte";
            TipKarte.MinimumWidth = 6;
            TipKarte.Name = "TipKarte";
            TipKarte.ReadOnly = true;
            TipKarte.Width = 125;
            // 
            // VrstaKarteNaziv
            // 
            VrstaKarteNaziv.DataPropertyName = "VrstaKarteNaziv";
            VrstaKarteNaziv.HeaderText = "Vrsta karte";
            VrstaKarteNaziv.MinimumWidth = 6;
            VrstaKarteNaziv.Name = "VrstaKarteNaziv";
            VrstaKarteNaziv.ReadOnly = true;
            VrstaKarteNaziv.Width = 125;
            // 
            // PolazisteOdrediste
            // 
            PolazisteOdrediste.DataPropertyName = "PolazisteOdrediste";
            PolazisteOdrediste.HeaderText = "Relacija";
            PolazisteOdrediste.MinimumWidth = 6;
            PolazisteOdrediste.Name = "PolazisteOdrediste";
            PolazisteOdrediste.ReadOnly = true;
            PolazisteOdrediste.Width = 125;
            // 
            // DatumVadjenjaKarte
            // 
            DatumVadjenjaKarte.DataPropertyName = "DatumVadjenjaKarte";
            DatumVadjenjaKarte.HeaderText = "Datum izdavanja";
            DatumVadjenjaKarte.MinimumWidth = 6;
            DatumVadjenjaKarte.Name = "DatumVadjenjaKarte";
            DatumVadjenjaKarte.ReadOnly = true;
            DatumVadjenjaKarte.Width = 125;
            // 
            // DatumVazenjaKarte
            // 
            DatumVazenjaKarte.DataPropertyName = "DatumVazenjaKarte";
            DatumVazenjaKarte.HeaderText = "Datum isteka";
            DatumVazenjaKarte.MinimumWidth = 6;
            DatumVazenjaKarte.Name = "DatumVazenjaKarte";
            DatumVazenjaKarte.ReadOnly = true;
            DatumVazenjaKarte.Width = 125;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(398, 62);
            label1.Name = "label1";
            label1.Size = new Size(184, 26);
            label1.TabIndex = 1;
            label1.Text = "Online plaćanje:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmOnlineKarte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1171, 559);
            Controls.Add(label1);
            Controls.Add(dgvPrikazKarata);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmOnlineKarte";
            Text = "frmOnlineKarte";
            Load += frmOnlineKarte_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrikazKarata).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPrikazKarata;
        private Label label1;
        private DataGridViewTextBoxColumn PlatiKartuID;
        private DataGridViewTextBoxColumn ImePrezimeKupca;
        private DataGridViewTextBoxColumn TipKarte;
        private DataGridViewTextBoxColumn VrstaKarteNaziv;
        private DataGridViewTextBoxColumn PolazisteOdrediste;
        private DataGridViewTextBoxColumn DatumVadjenjaKarte;
        private DataGridViewTextBoxColumn DatumVazenjaKarte;
        private DataGridViewTextBoxColumn Cijena;
        private DataGridViewCheckBoxColumn JeLiPlacena;
    }
}