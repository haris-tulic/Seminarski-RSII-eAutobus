
namespace eAutobus.WinUI.Karte
{
    partial class frmPrikazKarata
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
            label2 = new Label();
            cbTip = new ComboBox();
            cbZona = new ComboBox();
            btnPretraga = new Button();
            dataGridView1 = new DataGridView();
            CjenovnikID = new DataGridViewTextBoxColumn();
            TipKarte = new DataGridViewTextBoxColumn();
            Zona = new DataGridViewTextBoxColumn();
            VrstaKarte = new DataGridViewTextBoxColumn();
            Polaziste = new DataGridViewTextBoxColumn();
            Odrediste = new DataGridViewTextBoxColumn();
            CijenaPrikaz = new DataGridViewTextBoxColumn();
            Akcija = new DataGridViewButtonColumn();
            btnPrintajKarte = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(119, 88);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 0;
            label1.Text = "Tip:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(528, 88);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Zona:";
            // 
            // cbTip
            // 
            cbTip.FormattingEnabled = true;
            cbTip.Location = new Point(155, 84);
            cbTip.Margin = new Padding(4);
            cbTip.Name = "cbTip";
            cbTip.Size = new Size(200, 23);
            cbTip.TabIndex = 2;
            // 
            // cbZona
            // 
            cbZona.FormattingEnabled = true;
            cbZona.Location = new Point(575, 84);
            cbZona.Margin = new Padding(4);
            cbZona.Name = "cbZona";
            cbZona.Size = new Size(200, 23);
            cbZona.TabIndex = 3;
            // 
            // btnPretraga
            // 
            btnPretraga.Location = new Point(395, 159);
            btnPretraga.Margin = new Padding(4);
            btnPretraga.Name = "btnPretraga";
            btnPretraga.Size = new Size(88, 26);
            btnPretraga.TabIndex = 4;
            btnPretraga.Text = "Pretraga";
            btnPretraga.UseVisualStyleBackColor = true;
            btnPretraga.Click += btnPretraga_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { CjenovnikID, TipKarte, Zona, VrstaKarte, Polaziste, Odrediste, CijenaPrikaz, Akcija });
            dataGridView1.Location = new Point(62, 278);
            dataGridView1.Margin = new Padding(4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(929, 227);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellMouseDoubleClick += dataGridView1_CellMouseDoubleClick;
            // 
            // CjenovnikID
            // 
            CjenovnikID.DataPropertyName = "CjenovnikID";
            CjenovnikID.HeaderText = "CjenovnikID";
            CjenovnikID.MinimumWidth = 6;
            CjenovnikID.Name = "CjenovnikID";
            CjenovnikID.ReadOnly = true;
            CjenovnikID.Visible = false;
            CjenovnikID.Width = 125;
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
            // Zona
            // 
            Zona.DataPropertyName = "Zona";
            Zona.HeaderText = "Zona";
            Zona.MinimumWidth = 6;
            Zona.Name = "Zona";
            Zona.ReadOnly = true;
            Zona.Width = 125;
            // 
            // VrstaKarte
            // 
            VrstaKarte.DataPropertyName = "VrstaKarte";
            VrstaKarte.HeaderText = "Vrsta";
            VrstaKarte.MinimumWidth = 6;
            VrstaKarte.Name = "VrstaKarte";
            VrstaKarte.ReadOnly = true;
            VrstaKarte.Width = 125;
            // 
            // Polaziste
            // 
            Polaziste.DataPropertyName = "Polaziste";
            Polaziste.HeaderText = "Polazište";
            Polaziste.MinimumWidth = 6;
            Polaziste.Name = "Polaziste";
            Polaziste.ReadOnly = true;
            Polaziste.Width = 125;
            // 
            // Odrediste
            // 
            Odrediste.DataPropertyName = "Odrediste";
            Odrediste.HeaderText = "Odredište";
            Odrediste.MinimumWidth = 6;
            Odrediste.Name = "Odrediste";
            Odrediste.ReadOnly = true;
            Odrediste.Width = 125;
            // 
            // CijenaPrikaz
            // 
            CijenaPrikaz.DataPropertyName = "CijenaPrikaz";
            CijenaPrikaz.HeaderText = "Cijena";
            CijenaPrikaz.MinimumWidth = 6;
            CijenaPrikaz.Name = "CijenaPrikaz";
            CijenaPrikaz.ReadOnly = true;
            CijenaPrikaz.Width = 125;
            // 
            // Akcija
            // 
            Akcija.HeaderText = "Akcija";
            Akcija.MinimumWidth = 6;
            Akcija.Name = "Akcija";
            Akcija.ReadOnly = true;
            Akcija.Text = "Obriši";
            Akcija.UseColumnTextForButtonValue = true;
            Akcija.Width = 125;
            // 
            // btnPrintajKarte
            // 
            btnPrintajKarte.Location = new Point(395, 571);
            btnPrintajKarte.Margin = new Padding(4);
            btnPrintajKarte.Name = "btnPrintajKarte";
            btnPrintajKarte.Size = new Size(88, 26);
            btnPrintajKarte.TabIndex = 6;
            btnPrintajKarte.Text = "Printaj karte";
            btnPrintajKarte.UseVisualStyleBackColor = true;
            btnPrintajKarte.Click += btnPrintajKarte_Click;
            // 
            // frmPrikazKarata
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 699);
            Controls.Add(btnPrintajKarte);
            Controls.Add(dataGridView1);
            Controls.Add(btnPretraga);
            Controls.Add(cbZona);
            Controls.Add(cbTip);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "frmPrikazKarata";
            Text = "frmPrikazKarata";
            Load += frmPrikazKarata_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbTip;
        private ComboBox cbZona;
        private Button btnPretraga;
        private DataGridView dataGridView1;
        private Button btnPrintajKarte;
        private DataGridViewTextBoxColumn CjenovnikID;
        private DataGridViewTextBoxColumn TipKarte;
        private DataGridViewTextBoxColumn Zona;
        private DataGridViewTextBoxColumn VrstaKarte;
        private DataGridViewTextBoxColumn Polaziste;
        private DataGridViewTextBoxColumn Odrediste;
        private DataGridViewTextBoxColumn CijenaPrikaz;
        private DataGridViewButtonColumn Akcija;
    }
}