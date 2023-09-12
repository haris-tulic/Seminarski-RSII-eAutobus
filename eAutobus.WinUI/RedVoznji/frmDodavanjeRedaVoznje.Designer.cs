
namespace eAutobus.WinUI.RedVoznji
{
    partial class frmDodavanjeRedaVoznje
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
            btnSpremi = new Button();
            txtBrLinije = new TextBox();
            cbBrAutobusa = new ComboBox();
            cbVozac = new ComboBox();
            cbKondukter = new ComboBox();
            dtpPolazak = new DateTimePicker();
            dtpDolazak = new DateTimePicker();
            errorDodavanjeLinije = new ErrorProvider(components);
            cbPolaziste = new ComboBox();
            cbOdrediste = new ComboBox();
            dtpDatum = new DateTimePicker();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorDodavanjeLinije).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 46);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Broj linije:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 105);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 1;
            label2.Text = "Polazište:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 171);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Odredište:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 238);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 3;
            label4.Text = "Vrijeme polaska:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(476, 46);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(83, 15);
            label5.TabIndex = 4;
            label5.Text = "Broj autobusa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(517, 112);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(40, 15);
            label6.TabIndex = 5;
            label6.Text = "Vozač:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(495, 171);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(65, 15);
            label7.TabIndex = 6;
            label7.Text = "Kondukter:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(465, 238);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(93, 15);
            label8.TabIndex = 7;
            label8.Text = "Vrijeme dolaska:";
            // 
            // btnSpremi
            // 
            btnSpremi.Location = new Point(386, 377);
            btnSpremi.Margin = new Padding(4, 3, 4, 3);
            btnSpremi.Name = "btnSpremi";
            btnSpremi.Size = new Size(88, 27);
            btnSpremi.TabIndex = 8;
            btnSpremi.Text = "Spremi";
            btnSpremi.UseVisualStyleBackColor = true;
            btnSpremi.Click += btnSpremi_Click;
            // 
            // txtBrLinije
            // 
            txtBrLinije.Location = new Point(139, 43);
            txtBrLinije.Margin = new Padding(4, 3, 4, 3);
            txtBrLinije.Name = "txtBrLinije";
            txtBrLinije.Size = new Size(207, 23);
            txtBrLinije.TabIndex = 9;
            txtBrLinije.KeyPress += txtBrLinije_KeyPress;
            txtBrLinije.Validating += txtBrojLinije_Validating;
            // 
            // cbBrAutobusa
            // 
            cbBrAutobusa.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBrAutobusa.FormattingEnabled = true;
            cbBrAutobusa.Location = new Point(570, 42);
            cbBrAutobusa.Margin = new Padding(4, 3, 4, 3);
            cbBrAutobusa.Name = "cbBrAutobusa";
            cbBrAutobusa.Size = new Size(207, 23);
            cbBrAutobusa.TabIndex = 17;
            cbBrAutobusa.Validating += cbBrAutobusa_Validating;
            // 
            // cbVozac
            // 
            cbVozac.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVozac.FormattingEnabled = true;
            cbVozac.Location = new Point(570, 108);
            cbVozac.Margin = new Padding(4, 3, 4, 3);
            cbVozac.Name = "cbVozac";
            cbVozac.Size = new Size(207, 23);
            cbVozac.TabIndex = 18;
            cbVozac.Validating += cbVozac_Validating;
            // 
            // cbKondukter
            // 
            cbKondukter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbKondukter.FormattingEnabled = true;
            cbKondukter.Location = new Point(570, 166);
            cbKondukter.Margin = new Padding(4, 3, 4, 3);
            cbKondukter.Name = "cbKondukter";
            cbKondukter.Size = new Size(207, 23);
            cbKondukter.TabIndex = 19;
            // 
            // dtpPolazak
            // 
            dtpPolazak.Format = DateTimePickerFormat.Time;
            dtpPolazak.Location = new Point(139, 231);
            dtpPolazak.Margin = new Padding(4, 3, 4, 3);
            dtpPolazak.Name = "dtpPolazak";
            dtpPolazak.Size = new Size(207, 23);
            dtpPolazak.TabIndex = 20;
            dtpPolazak.Value = new DateTime(2022, 1, 6, 16, 1, 0, 0);
            dtpPolazak.Validating += dtpPolazak_Validating;
            // 
            // dtpDolazak
            // 
            dtpDolazak.Format = DateTimePickerFormat.Time;
            dtpDolazak.Location = new Point(570, 231);
            dtpDolazak.Margin = new Padding(4, 3, 4, 3);
            dtpDolazak.Name = "dtpDolazak";
            dtpDolazak.Size = new Size(207, 23);
            dtpDolazak.TabIndex = 21;
            dtpDolazak.Value = new DateTime(2021, 10, 23, 16, 2, 13, 0);
            dtpDolazak.Validating += dtpDolazak_Validating;
            // 
            // errorDodavanjeLinije
            // 
            errorDodavanjeLinije.ContainerControl = this;
            // 
            // cbPolaziste
            // 
            cbPolaziste.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPolaziste.FormattingEnabled = true;
            cbPolaziste.Location = new Point(139, 102);
            cbPolaziste.Margin = new Padding(4, 3, 4, 3);
            cbPolaziste.Name = "cbPolaziste";
            cbPolaziste.Size = new Size(207, 23);
            cbPolaziste.TabIndex = 22;
            cbPolaziste.Validating += cbPolaziste_Validating;
            // 
            // cbOdrediste
            // 
            cbOdrediste.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOdrediste.FormattingEnabled = true;
            cbOdrediste.Location = new Point(139, 160);
            cbOdrediste.Margin = new Padding(4, 3, 4, 3);
            cbOdrediste.Name = "cbOdrediste";
            cbOdrediste.Size = new Size(207, 23);
            cbOdrediste.TabIndex = 23;
            cbOdrediste.Validating += cbOdrediste_Validating;
            // 
            // dtpDatum
            // 
            dtpDatum.Format = DateTimePickerFormat.Short;
            dtpDatum.Location = new Point(139, 298);
            dtpDatum.Margin = new Padding(4, 3, 4, 3);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(207, 23);
            dtpDatum.TabIndex = 24;
            dtpDatum.ValueChanged += dtpDatum_ValueChanged;
            dtpDatum.Validating += dtpDatum_Validating;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(64, 305);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(46, 15);
            label9.TabIndex = 25;
            label9.Text = "Datum:";
            // 
            // frmDodavanjeRedaVoznje
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(label9);
            Controls.Add(dtpDatum);
            Controls.Add(cbOdrediste);
            Controls.Add(cbPolaziste);
            Controls.Add(dtpDolazak);
            Controls.Add(dtpPolazak);
            Controls.Add(cbKondukter);
            Controls.Add(cbVozac);
            Controls.Add(cbBrAutobusa);
            Controls.Add(txtBrLinije);
            Controls.Add(btnSpremi);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmDodavanjeRedaVoznje";
            Text = "Dodavanje novog reda vožnje";
            Load += frmDodavanjeRedaVoznje_Load;
            ((System.ComponentModel.ISupportInitialize)errorDodavanjeLinije).EndInit();
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
        private Button btnSpremi;
        private TextBox txtBrLinije;
        private ComboBox cbBrAutobusa;
        private ComboBox cbVozac;
        private ComboBox cbKondukter;
        private DateTimePicker dtpPolazak;
        private DateTimePicker dtpDolazak;
        private ErrorProvider errorDodavanjeLinije;
        private ComboBox cbOdrediste;
        private ComboBox cbPolaziste;
        private Label label9;
        private DateTimePicker dtpDatum;
    }
}