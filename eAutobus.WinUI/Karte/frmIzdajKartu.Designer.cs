
namespace eAutobus.WinUI.Karte
{
    partial class frmIzdajKartu
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
            label8 = new Label();
            cbVrstaKarte = new ComboBox();
            cbTipKarte = new ComboBox();
            cbPolaziste = new ComboBox();
            cbOdrediste = new ComboBox();
            txtIme = new TextBox();
            txtAdresa = new TextBox();
            dtpDatumVadjenja = new DateTimePicker();
            rbJedan = new RadioButton();
            rbDva = new RadioButton();
            btnIzdajKartu = new Button();
            errorProvider = new ErrorProvider(components);
            label9 = new Label();
            dtpDatumVazenja = new DateTimePicker();
            labelPrezime = new Label();
            txtCijena = new TextBox();
            label10 = new Label();
            txtBrojTelefona = new TextBox();
            label11 = new Label();
            txtPrezime = new TextBox();
            btnPreuzmiPDF = new Button();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(350, 54);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(271, 155);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 1;
            label2.Text = "Adresa stanovanja:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(309, 253);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 2;
            label3.Text = "Vrsta karte:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(352, 301);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(26, 15);
            label4.TabIndex = 3;
            label4.Text = "Tip:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(317, 403);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 4;
            label5.Text = "Odredište:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(321, 352);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 5;
            label6.Text = "Polazište:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(253, 451);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(119, 15);
            label7.TabIndex = 6;
            label7.Text = "Datum vađenja karte:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(330, 624);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 7;
            label8.Text = "Pravac:";
            // 
            // cbVrstaKarte
            // 
            cbVrstaKarte.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVrstaKarte.FormattingEnabled = true;
            cbVrstaKarte.Location = new Point(387, 249);
            cbVrstaKarte.Margin = new Padding(4, 3, 4, 3);
            cbVrstaKarte.Name = "cbVrstaKarte";
            cbVrstaKarte.Size = new Size(182, 23);
            cbVrstaKarte.TabIndex = 8;
            cbVrstaKarte.SelectedIndexChanged += cbVrstaKarte_SelectedIndexChanged;
            cbVrstaKarte.Validating += cbVrstaKarte_Validating;
            // 
            // cbTipKarte
            // 
            cbTipKarte.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipKarte.FormattingEnabled = true;
            cbTipKarte.Location = new Point(387, 298);
            cbTipKarte.Margin = new Padding(4, 3, 4, 3);
            cbTipKarte.Name = "cbTipKarte";
            cbTipKarte.Size = new Size(182, 23);
            cbTipKarte.TabIndex = 9;
            cbTipKarte.SelectedIndexChanged += cbTipKarte_SelectedIndexChanged;
            cbTipKarte.Validating += cbTipKarte_Validating;
            // 
            // cbPolaziste
            // 
            cbPolaziste.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPolaziste.FormattingEnabled = true;
            cbPolaziste.Location = new Point(388, 348);
            cbPolaziste.Margin = new Padding(4, 3, 4, 3);
            cbPolaziste.Name = "cbPolaziste";
            cbPolaziste.Size = new Size(182, 23);
            cbPolaziste.TabIndex = 10;
            cbPolaziste.SelectedIndexChanged += cbPolaziste_SelectedIndexChanged;
            cbPolaziste.Validating += cbPolaziste_Validating;
            // 
            // cbOdrediste
            // 
            cbOdrediste.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOdrediste.FormattingEnabled = true;
            cbOdrediste.Location = new Point(388, 399);
            cbOdrediste.Margin = new Padding(4, 3, 4, 3);
            cbOdrediste.Name = "cbOdrediste";
            cbOdrediste.Size = new Size(182, 23);
            cbOdrediste.TabIndex = 11;
            cbOdrediste.SelectedIndexChanged += cbOdrediste_SelectedIndexChanged;
            cbOdrediste.Validating += cbOdrediste_Validating;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(388, 51);
            txtIme.Margin = new Padding(4, 3, 4, 3);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(182, 23);
            txtIme.TabIndex = 12;
            txtIme.Validating += txtImePrezime_Validating;
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(388, 151);
            txtAdresa.Margin = new Padding(4, 3, 4, 3);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(182, 23);
            txtAdresa.TabIndex = 13;
            txtAdresa.Validating += txtAdresa_Validating;
            // 
            // dtpDatumVadjenja
            // 
            dtpDatumVadjenja.Location = new Point(388, 448);
            dtpDatumVadjenja.Margin = new Padding(4, 3, 4, 3);
            dtpDatumVadjenja.Name = "dtpDatumVadjenja";
            dtpDatumVadjenja.Size = new Size(182, 23);
            dtpDatumVadjenja.TabIndex = 14;
            dtpDatumVadjenja.Validating += dtpDatum_Validating;
            // 
            // rbJedan
            // 
            rbJedan.AutoSize = true;
            rbJedan.Checked = true;
            rbJedan.Location = new Point(388, 622);
            rbJedan.Margin = new Padding(4, 3, 4, 3);
            rbJedan.Name = "rbJedan";
            rbJedan.Size = new Size(116, 19);
            rbJedan.TabIndex = 15;
            rbJedan.TabStop = true;
            rbJedan.Text = "U jednom pravcu";
            rbJedan.UseVisualStyleBackColor = true;
            rbJedan.MouseClick += rbJedan_MouseClick;
            // 
            // rbDva
            // 
            rbDva.AutoSize = true;
            rbDva.Location = new Point(534, 622);
            rbDva.Margin = new Padding(4, 3, 4, 3);
            rbDva.Name = "rbDva";
            rbDva.Size = new Size(94, 19);
            rbDva.TabIndex = 16;
            rbDva.Text = "U oba pravca";
            rbDva.UseVisualStyleBackColor = true;
            rbDva.MouseClick += rbDva_MouseClick;
            // 
            // btnIzdajKartu
            // 
            btnIzdajKartu.Location = new Point(432, 668);
            btnIzdajKartu.Margin = new Padding(4, 3, 4, 3);
            btnIzdajKartu.Name = "btnIzdajKartu";
            btnIzdajKartu.Size = new Size(96, 32);
            btnIzdajKartu.TabIndex = 17;
            btnIzdajKartu.Text = "Izdaj kartu";
            btnIzdajKartu.UseVisualStyleBackColor = true;
            btnIzdajKartu.Click += btnIzdajKartu_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(259, 501);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(117, 15);
            label9.TabIndex = 18;
            label9.Text = "Datum važenja karte:";
            // 
            // dtpDatumVazenja
            // 
            dtpDatumVazenja.Location = new Point(388, 497);
            dtpDatumVazenja.Margin = new Padding(4, 3, 4, 3);
            dtpDatumVazenja.Name = "dtpDatumVazenja";
            dtpDatumVazenja.Size = new Size(182, 23);
            dtpDatumVazenja.TabIndex = 19;
            // 
            // labelPrezime
            // 
            labelPrezime.AutoSize = true;
            labelPrezime.Location = new Point(327, 105);
            labelPrezime.Margin = new Padding(4, 0, 4, 0);
            labelPrezime.Name = "labelPrezime";
            labelPrezime.Size = new Size(52, 15);
            labelPrezime.TabIndex = 20;
            labelPrezime.Text = "Prezime:";
            // 
            // txtCijena
            // 
            txtCijena.Location = new Point(388, 548);
            txtCijena.Margin = new Padding(4, 3, 4, 3);
            txtCijena.Name = "txtCijena";
            txtCijena.Size = new Size(182, 23);
            txtCijena.TabIndex = 22;
            txtCijena.Click += txtCijena_Click;
            txtCijena.Validating += txtCijena_Validating;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(330, 550);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(43, 15);
            label10.TabIndex = 23;
            label10.Text = "Cijena:";
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(388, 201);
            txtBrojTelefona.Margin = new Padding(4, 3, 4, 3);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(182, 23);
            txtBrojTelefona.TabIndex = 24;
            txtBrojTelefona.KeyPress += txtBrojTelefona_KeyPress;
            txtBrojTelefona.Validating += txtBrojTelefona_Validating;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(301, 204);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(77, 15);
            label11.TabIndex = 25;
            label11.Text = "Broj telefona:";
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(388, 102);
            txtPrezime.Margin = new Padding(4, 3, 4, 3);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(182, 23);
            txtPrezime.TabIndex = 26;
            txtPrezime.Validating += txtPrezime_Validating;
            // 
            // btnPreuzmiPDF
            // 
            btnPreuzmiPDF.Location = new Point(423, 734);
            btnPreuzmiPDF.Margin = new Padding(4, 3, 4, 3);
            btnPreuzmiPDF.Name = "btnPreuzmiPDF";
            btnPreuzmiPDF.Size = new Size(113, 32);
            btnPreuzmiPDF.TabIndex = 29;
            btnPreuzmiPDF.Text = "Preuzmi PDF";
            btnPreuzmiPDF.UseVisualStyleBackColor = true;
            btnPreuzmiPDF.Click += btnPreuzmiPDF_Click;
            // 
            // label12
            // 
            label12.Font = new Font("Sitka Display", 9F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            label12.ForeColor = Color.OrangeRed;
            label12.Location = new Point(387, 572);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(204, 55);
            label12.TabIndex = 30;
            label12.Text = "*Klikom na polje Cijena, prikazuje se cijena za odabranu kartu";
            // 
            // frmIzdajKartu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 791);
            Controls.Add(label12);
            Controls.Add(btnPreuzmiPDF);
            Controls.Add(txtPrezime);
            Controls.Add(label11);
            Controls.Add(txtBrojTelefona);
            Controls.Add(label10);
            Controls.Add(txtCijena);
            Controls.Add(labelPrezime);
            Controls.Add(dtpDatumVazenja);
            Controls.Add(label9);
            Controls.Add(btnIzdajKartu);
            Controls.Add(rbDva);
            Controls.Add(rbJedan);
            Controls.Add(dtpDatumVadjenja);
            Controls.Add(txtAdresa);
            Controls.Add(txtIme);
            Controls.Add(cbOdrediste);
            Controls.Add(cbPolaziste);
            Controls.Add(cbTipKarte);
            Controls.Add(cbVrstaKarte);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmIzdajKartu";
            Text = "Izdaj kartu";
            Load += frmIzdajKartu_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
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
        private Label label8;
        private ComboBox cbVrstaKarte;
        private ComboBox cbTipKarte;
        private ComboBox cbPolaziste;
        private ComboBox cbOdrediste;
        private TextBox txtIme;
        private TextBox txtAdresa;
        private DateTimePicker dtpDatumVadjenja;
        private RadioButton rbJedan;
        private RadioButton rbDva;
        private Button btnIzdajKartu;
        private ErrorProvider errorProvider;
        private Label label9;
        private DateTimePicker dtpDatumVazenja;
        private Label labelPrezime;
        private Label label10;
        private TextBox txtCijena;
        private TextBox txtBrojTelefona;
        private Label label11;
        private TextBox txtPrezime;
        private Button btnPreuzmiPDF;
        private Label label12;
    }
}