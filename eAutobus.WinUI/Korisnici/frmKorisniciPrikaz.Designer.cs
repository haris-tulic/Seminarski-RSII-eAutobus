
namespace eAutobus.WinUI.Korisnici
{
    partial class frmKorisniciPrikaz
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
            txtIme = new TextBox();
            btnPrikazi = new Button();
            label2 = new Label();
            label3 = new Label();
            txtPrezime = new TextBox();
            dgvPrikaz = new DataGridView();
            KorisnikID = new DataGridViewTextBoxColumn();
            Ime = new DataGridViewTextBoxColumn();
            Prezime = new DataGridViewTextBoxColumn();
            DatumRodjenja = new DataGridViewTextBoxColumn();
            Uloga = new DataGridViewTextBoxColumn();
            Akcija = new DataGridViewButtonColumn();
            cbUloga = new ComboBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPrikaz).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(329, 101);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(373, 97);
            txtIme.Margin = new Padding(5, 5, 5, 5);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(188, 27);
            txtIme.TabIndex = 1;
            // 
            // btnPrikazi
            // 
            btnPrikazi.Location = new Point(405, 275);
            btnPrikazi.Margin = new Padding(5, 5, 5, 5);
            btnPrikazi.Name = "btnPrikazi";
            btnPrikazi.Size = new Size(101, 35);
            btnPrikazi.TabIndex = 2;
            btnPrikazi.Text = "Pretraga";
            btnPrikazi.UseVisualStyleBackColor = true;
            btnPrikazi.Click += btnPrikazi_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(303, 155);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 3;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(315, 211);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 4;
            label3.Text = "Uloga:";
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(373, 151);
            txtPrezime.Margin = new Padding(5, 5, 5, 5);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(188, 27);
            txtPrezime.TabIndex = 6;
            // 
            // dgvPrikaz
            // 
            dgvPrikaz.AllowUserToAddRows = false;
            dgvPrikaz.AllowUserToDeleteRows = false;
            dgvPrikaz.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrikaz.Columns.AddRange(new DataGridViewColumn[] { KorisnikID, Ime, Prezime, DatumRodjenja, Uloga, Akcija });
            dgvPrikaz.Location = new Point(71, 353);
            dgvPrikaz.Margin = new Padding(5, 5, 5, 5);
            dgvPrikaz.Name = "dgvPrikaz";
            dgvPrikaz.ReadOnly = true;
            dgvPrikaz.RowHeadersWidth = 51;
            dgvPrikaz.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrikaz.Size = new Size(776, 341);
            dgvPrikaz.TabIndex = 7;
            dgvPrikaz.CellContentClick += dgvPrikaz_CellContentClick;
            dgvPrikaz.CellMouseDoubleClick += dgvPrikaz_CellMouseDoubleClick;
            // 
            // KorisnikID
            // 
            KorisnikID.DataPropertyName = "KorisnikID";
            KorisnikID.HeaderText = "ID";
            KorisnikID.MinimumWidth = 6;
            KorisnikID.Name = "KorisnikID";
            KorisnikID.ReadOnly = true;
            KorisnikID.Visible = false;
            KorisnikID.Width = 125;
            // 
            // Ime
            // 
            Ime.DataPropertyName = "Ime";
            Ime.HeaderText = "Ime";
            Ime.MinimumWidth = 6;
            Ime.Name = "Ime";
            Ime.ReadOnly = true;
            Ime.Width = 125;
            // 
            // Prezime
            // 
            Prezime.DataPropertyName = "Prezime";
            Prezime.HeaderText = "Prezime";
            Prezime.MinimumWidth = 6;
            Prezime.Name = "Prezime";
            Prezime.ReadOnly = true;
            Prezime.Width = 125;
            // 
            // DatumRodjenja
            // 
            DatumRodjenja.DataPropertyName = "DatumRodjenja";
            DatumRodjenja.HeaderText = "Datum rodjenja";
            DatumRodjenja.MinimumWidth = 6;
            DatumRodjenja.Name = "DatumRodjenja";
            DatumRodjenja.ReadOnly = true;
            DatumRodjenja.Width = 125;
            // 
            // Uloga
            // 
            Uloga.DataPropertyName = "Uloga";
            Uloga.HeaderText = "Uloga";
            Uloga.MinimumWidth = 6;
            Uloga.Name = "Uloga";
            Uloga.ReadOnly = true;
            Uloga.Width = 125;
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
            // cbUloga
            // 
            cbUloga.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUloga.FormattingEnabled = true;
            cbUloga.Location = new Point(373, 199);
            cbUloga.Margin = new Padding(5, 5, 5, 5);
            cbUloga.Name = "cbUloga";
            cbUloga.Size = new Size(188, 28);
            cbUloga.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(405, 748);
            button1.Margin = new Padding(5, 5, 5, 5);
            button1.Name = "button1";
            button1.Size = new Size(101, 35);
            button1.TabIndex = 9;
            button1.Text = "Izvještaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmKorisniciPrikaz
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 848);
            Controls.Add(button1);
            Controls.Add(cbUloga);
            Controls.Add(dgvPrikaz);
            Controls.Add(txtPrezime);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnPrikazi);
            Controls.Add(txtIme);
            Controls.Add(label1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "frmKorisniciPrikaz";
            Text = "Prikaz korisnika";
            Load += frmKorisniciPrikaz_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPrikaz).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIme;
        private Button btnPrikazi;
        private Label label2;
        private Label label3;
        private TextBox txtPrezime;
        private DataGridView dgvPrikaz;
        private ComboBox cbUloga;
        private Button button1;
        private DataGridViewTextBoxColumn KorisnikID;
        private DataGridViewTextBoxColumn Ime;
        private DataGridViewTextBoxColumn Prezime;
        private DataGridViewTextBoxColumn DatumRodjenja;
        private DataGridViewTextBoxColumn Uloga;
        private DataGridViewButtonColumn Akcija;
    }
}