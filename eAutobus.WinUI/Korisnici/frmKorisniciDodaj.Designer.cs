
namespace eAutobus.WinUI.Korisnici
{
    partial class frmKorisniciDodaj
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtEmail = new TextBox();
            txtBrojTelefona = new TextBox();
            txtAdresaStanovanja = new TextBox();
            label8 = new Label();
            cmbUloga = new ComboBox();
            btnSnimi = new Button();
            dtpDatumRodjenja = new DateTimePicker();
            errorKorisnik = new ErrorProvider(components);
            cmbGrad = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorKorisnik).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(246, 55);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 96);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(237, 138);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 2;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(184, 186);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 3;
            label4.Text = "Datum rođenja:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(197, 227);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 4;
            label5.Text = "Broj telefona:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(163, 265);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 5;
            label6.Text = "Adresa stanovanja:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(237, 313);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(35, 15);
            label7.TabIndex = 6;
            label7.Text = "Grad:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(285, 52);
            txtIme.Margin = new Padding(4, 3, 4, 3);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(199, 23);
            txtIme.TabIndex = 9;
            txtIme.Validating += txtIme_Validating;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(285, 96);
            txtPrezime.Margin = new Padding(4, 3, 4, 3);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(199, 23);
            txtPrezime.TabIndex = 10;
            txtPrezime.Validating += txtPrezime_Validating;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(285, 135);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(199, 23);
            txtEmail.TabIndex = 11;
            txtEmail.Validating += txtEmail_Validating;
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(285, 224);
            txtBrojTelefona.Margin = new Padding(4, 3, 4, 3);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(199, 23);
            txtBrojTelefona.TabIndex = 13;
            txtBrojTelefona.KeyPress += txtBrojTelefona_KeyPress;
            txtBrojTelefona.Validating += txtBrojTelefona_Validating;
            // 
            // txtAdresaStanovanja
            // 
            txtAdresaStanovanja.Location = new Point(285, 262);
            txtAdresaStanovanja.Margin = new Padding(4, 3, 4, 3);
            txtAdresaStanovanja.Name = "txtAdresaStanovanja";
            txtAdresaStanovanja.Size = new Size(199, 23);
            txtAdresaStanovanja.TabIndex = 14;
            txtAdresaStanovanja.Validating += txtAdresaStanovanja_Validating;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(231, 360);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 16;
            label8.Text = "Uloga:";
            // 
            // cmbUloga
            // 
            cmbUloga.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUloga.FormattingEnabled = true;
            cmbUloga.Location = new Point(285, 357);
            cmbUloga.Margin = new Padding(4, 3, 4, 3);
            cmbUloga.Name = "cmbUloga";
            cmbUloga.Size = new Size(199, 23);
            cmbUloga.TabIndex = 17;
            cmbUloga.Validating += cmbUloga_Validating;
            // 
            // btnSnimi
            // 
            btnSnimi.Location = new Point(338, 432);
            btnSnimi.Margin = new Padding(4, 3, 4, 3);
            btnSnimi.Name = "btnSnimi";
            btnSnimi.Size = new Size(88, 27);
            btnSnimi.TabIndex = 18;
            btnSnimi.Text = "Dodaj";
            btnSnimi.UseVisualStyleBackColor = true;
            btnSnimi.Click += btnSnimi_Click;
            // 
            // dtpDatumRodjenja
            // 
            dtpDatumRodjenja.Location = new Point(286, 186);
            dtpDatumRodjenja.Margin = new Padding(4, 3, 4, 3);
            dtpDatumRodjenja.Name = "dtpDatumRodjenja";
            dtpDatumRodjenja.Size = new Size(198, 23);
            dtpDatumRodjenja.TabIndex = 19;
            dtpDatumRodjenja.Validating += dtpDatumRodjenja_Validating;
            // 
            // errorKorisnik
            // 
            errorKorisnik.ContainerControl = this;
            // 
            // cmbGrad
            // 
            cmbGrad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(285, 309);
            cmbGrad.Margin = new Padding(4, 3, 4, 3);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(199, 23);
            cmbGrad.TabIndex = 20;
            cmbGrad.Validating += cmbGrad_Validating;
            // 
            // frmKorisniciDodaj
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 519);
            Controls.Add(cmbGrad);
            Controls.Add(dtpDatumRodjenja);
            Controls.Add(btnSnimi);
            Controls.Add(cmbUloga);
            Controls.Add(label8);
            Controls.Add(txtAdresaStanovanja);
            Controls.Add(txtBrojTelefona);
            Controls.Add(txtEmail);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmKorisniciDodaj";
            Text = "Dodaj korisnika";
            Load += frmKorisniciDodaj_Load;
            ((System.ComponentModel.ISupportInitialize)errorKorisnik).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtEmail;
        private TextBox txtBrojTelefona;
        private TextBox txtAdresaStanovanja;
        private Label label8;
        private ComboBox cmbUloga;
        private Button btnSnimi;
        private DateTimePicker dtpDatumRodjenja;
        private ErrorProvider errorKorisnik;
        private ComboBox cmbGrad;
    }
}