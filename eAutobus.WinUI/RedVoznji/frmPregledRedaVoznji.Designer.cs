
namespace eAutobus.WinUI.RedVoznji
{
    partial class frmPregledRedaVoznji
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
            label3 = new Label();
            btnSnimi = new Button();
            dgvLinije = new DataGridView();
            RasporedVoznjeID = new DataGridViewTextBoxColumn();
            BrojLinije = new DataGridViewTextBoxColumn();
            BrojAutobusa = new DataGridViewTextBoxColumn();
            Polazak = new DataGridViewTextBoxColumn();
            VrijemePolaska = new DataGridViewTextBoxColumn();
            VrijemeDolaska = new DataGridViewTextBoxColumn();
            Odlazak = new DataGridViewTextBoxColumn();
            Datum = new DataGridViewTextBoxColumn();
            Akcija = new DataGridViewButtonColumn();
            cbPolaziste = new ComboBox();
            cbOdrediste = new ComboBox();
            dtpDatum = new DateTimePicker();
            btnIzvjestaj = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLinije).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(81, 89);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 0;
            label1.Text = "Polazište:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(699, 88);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Odredište:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(360, 197);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 2;
            label3.Text = "Datum:";
            // 
            // btnSnimi
            // 
            btnSnimi.BackColor = SystemColors.ControlDark;
            btnSnimi.BackgroundImageLayout = ImageLayout.Center;
            btnSnimi.ForeColor = SystemColors.ButtonFace;
            btnSnimi.Location = new Point(493, 268);
            btnSnimi.Margin = new Padding(5, 5, 5, 5);
            btnSnimi.Name = "btnSnimi";
            btnSnimi.Size = new Size(101, 35);
            btnSnimi.TabIndex = 3;
            btnSnimi.Text = "Pretraga";
            btnSnimi.UseVisualStyleBackColor = false;
            btnSnimi.Click += btnSnimi_Click;
            // 
            // dgvLinije
            // 
            dgvLinije.AllowUserToAddRows = false;
            dgvLinije.AllowUserToDeleteRows = false;
            dgvLinije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLinije.Columns.AddRange(new DataGridViewColumn[] { RasporedVoznjeID, BrojLinije, BrojAutobusa, Polazak, VrijemePolaska, VrijemeDolaska, Odlazak, Datum, Akcija });
            dgvLinije.Location = new Point(16, 351);
            dgvLinije.Margin = new Padding(5, 5, 5, 5);
            dgvLinije.Name = "dgvLinije";
            dgvLinije.ReadOnly = true;
            dgvLinije.RowHeadersWidth = 51;
            dgvLinije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLinije.Size = new Size(1210, 323);
            dgvLinije.TabIndex = 4;
            dgvLinije.CellContentClick += dgvLinije_CellContentClick;
            dgvLinije.CellMouseDoubleClick += dgvLinije_CellMouseDoubleClick;
            // 
            // RasporedVoznjeID
            // 
            RasporedVoznjeID.DataPropertyName = "RasporedVoznjeID";
            RasporedVoznjeID.HeaderText = "RasporedVoznjeID";
            RasporedVoznjeID.MinimumWidth = 6;
            RasporedVoznjeID.Name = "RasporedVoznjeID";
            RasporedVoznjeID.ReadOnly = true;
            RasporedVoznjeID.Visible = false;
            RasporedVoznjeID.Width = 125;
            // 
            // BrojLinije
            // 
            BrojLinije.DataPropertyName = "BrojLinije";
            BrojLinije.HeaderText = "Linija";
            BrojLinije.MinimumWidth = 6;
            BrojLinije.Name = "BrojLinije";
            BrojLinije.ReadOnly = true;
            BrojLinije.Width = 125;
            // 
            // BrojAutobusa
            // 
            BrojAutobusa.DataPropertyName = "BrojAutobusa";
            BrojAutobusa.HeaderText = "Autobus";
            BrojAutobusa.MinimumWidth = 6;
            BrojAutobusa.Name = "BrojAutobusa";
            BrojAutobusa.ReadOnly = true;
            BrojAutobusa.Width = 125;
            // 
            // Polazak
            // 
            Polazak.DataPropertyName = "Polazak";
            Polazak.HeaderText = "Polazište";
            Polazak.MinimumWidth = 6;
            Polazak.Name = "Polazak";
            Polazak.ReadOnly = true;
            Polazak.Width = 125;
            // 
            // VrijemePolaska
            // 
            VrijemePolaska.DataPropertyName = "VrijemePolaska";
            VrijemePolaska.HeaderText = "Vrijeme polaska";
            VrijemePolaska.MinimumWidth = 6;
            VrijemePolaska.Name = "VrijemePolaska";
            VrijemePolaska.ReadOnly = true;
            VrijemePolaska.Resizable = DataGridViewTriState.False;
            VrijemePolaska.Width = 125;
            // 
            // VrijemeDolaska
            // 
            VrijemeDolaska.DataPropertyName = "VrijemeDolaska";
            VrijemeDolaska.HeaderText = "Vrijeme dolaska";
            VrijemeDolaska.MinimumWidth = 6;
            VrijemeDolaska.Name = "VrijemeDolaska";
            VrijemeDolaska.ReadOnly = true;
            VrijemeDolaska.Resizable = DataGridViewTriState.False;
            VrijemeDolaska.Width = 125;
            // 
            // Odlazak
            // 
            Odlazak.DataPropertyName = "Odlazak";
            Odlazak.HeaderText = "Odredište";
            Odlazak.MinimumWidth = 6;
            Odlazak.Name = "Odlazak";
            Odlazak.ReadOnly = true;
            Odlazak.Width = 125;
            // 
            // Datum
            // 
            Datum.DataPropertyName = "Datum";
            Datum.HeaderText = "Datum";
            Datum.MinimumWidth = 6;
            Datum.Name = "Datum";
            Datum.ReadOnly = true;
            Datum.Resizable = DataGridViewTriState.False;
            Datum.Width = 125;
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
            // cbPolaziste
            // 
            cbPolaziste.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPolaziste.FormattingEnabled = true;
            cbPolaziste.Location = new Point(159, 83);
            cbPolaziste.Margin = new Padding(5, 5, 5, 5);
            cbPolaziste.Name = "cbPolaziste";
            cbPolaziste.Size = new Size(183, 28);
            cbPolaziste.TabIndex = 5;
            // 
            // cbOdrediste
            // 
            cbOdrediste.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOdrediste.FormattingEnabled = true;
            cbOdrediste.Location = new Point(779, 83);
            cbOdrediste.Margin = new Padding(5, 5, 5, 5);
            cbOdrediste.Name = "cbOdrediste";
            cbOdrediste.Size = new Size(183, 28);
            cbOdrediste.TabIndex = 6;
            // 
            // dtpDatum
            // 
            dtpDatum.Location = new Point(435, 197);
            dtpDatum.Margin = new Padding(5, 5, 5, 5);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(265, 27);
            dtpDatum.TabIndex = 7;
            dtpDatum.ValueChanged += dtpDatum_ValueChanged;
            // 
            // btnIzvjestaj
            // 
            btnIzvjestaj.Location = new Point(493, 739);
            btnIzvjestaj.Margin = new Padding(5, 5, 5, 5);
            btnIzvjestaj.Name = "btnIzvjestaj";
            btnIzvjestaj.Size = new Size(101, 35);
            btnIzvjestaj.TabIndex = 8;
            btnIzvjestaj.Text = "Izvještaj";
            btnIzvjestaj.UseVisualStyleBackColor = true;
            btnIzvjestaj.Click += btnIzvjestaj_Click;
            // 
            // frmPregledRedaVoznji
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 855);
            Controls.Add(btnIzvjestaj);
            Controls.Add(dtpDatum);
            Controls.Add(cbOdrediste);
            Controls.Add(cbPolaziste);
            Controls.Add(dgvLinije);
            Controls.Add(btnSnimi);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "frmPregledRedaVoznji";
            Text = "Pregled reda voznji";
            Load += frmPregledRedaVoznji_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLinije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSnimi;
        private DataGridView dgvLinije;
        private ComboBox cbPolaziste;
        private ComboBox cbOdrediste;
        private DateTimePicker dtpDatum;
        private Button btnIzvjestaj;
        private DataGridViewTextBoxColumn RasporedVoznjeID;
        private DataGridViewTextBoxColumn BrojLinije;
        private DataGridViewTextBoxColumn BrojAutobusa;
        private DataGridViewTextBoxColumn Polazak;
        private DataGridViewTextBoxColumn VrijemePolaska;
        private DataGridViewTextBoxColumn VrijemeDolaska;
        private DataGridViewTextBoxColumn Odlazak;
        private DataGridViewTextBoxColumn Datum;
        private DataGridViewButtonColumn Akcija;
    }
}