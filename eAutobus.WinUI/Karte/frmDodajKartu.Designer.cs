
namespace eAutobus.WinUI.Karte
{
    partial class frmDodajKartu
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
            cbTipKarte = new ComboBox();
            cbVrstaKarte = new ComboBox();
            cbZona = new ComboBox();
            txtCijena = new TextBox();
            btnSnimi = new Button();
            errorProvider = new ErrorProvider(components);
            label5 = new Label();
            label6 = new Label();
            cmbPolaziste = new ComboBox();
            cmbOdrediste = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(290, 133);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Tip karte:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(280, 173);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 1;
            label2.Text = "Vrsta karte:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(310, 213);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 2;
            label3.Text = "Zona:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(306, 256);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 3;
            label4.Text = "Cijena:";
            // 
            // cbTipKarte
            // 
            cbTipKarte.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipKarte.FormattingEnabled = true;
            cbTipKarte.Location = new Point(358, 129);
            cbTipKarte.Margin = new Padding(4, 3, 4, 3);
            cbTipKarte.Name = "cbTipKarte";
            cbTipKarte.Size = new Size(163, 23);
            cbTipKarte.TabIndex = 4;
            cbTipKarte.Validating += cbTipKarte_Validating;
            // 
            // cbVrstaKarte
            // 
            cbVrstaKarte.DropDownStyle = ComboBoxStyle.DropDownList;
            cbVrstaKarte.FormattingEnabled = true;
            cbVrstaKarte.Location = new Point(358, 170);
            cbVrstaKarte.Margin = new Padding(4, 3, 4, 3);
            cbVrstaKarte.Name = "cbVrstaKarte";
            cbVrstaKarte.Size = new Size(163, 23);
            cbVrstaKarte.TabIndex = 5;
            cbVrstaKarte.Validating += cbVrstaKarte_Validating;
            // 
            // cbZona
            // 
            cbZona.DropDownStyle = ComboBoxStyle.DropDownList;
            cbZona.FormattingEnabled = true;
            cbZona.Location = new Point(358, 210);
            cbZona.Margin = new Padding(4, 3, 4, 3);
            cbZona.Name = "cbZona";
            cbZona.Size = new Size(163, 23);
            cbZona.TabIndex = 6;
            cbZona.Validating += cbZona_Validating;
            // 
            // txtCijena
            // 
            txtCijena.Location = new Point(358, 253);
            txtCijena.Margin = new Padding(4, 3, 4, 3);
            txtCijena.Name = "txtCijena";
            txtCijena.Size = new Size(163, 23);
            txtCijena.TabIndex = 7;
            txtCijena.KeyPress += txtCijena_KeyPress;
            txtCijena.Validating += txtCijena_Validating;
            // 
            // btnSnimi
            // 
            btnSnimi.Location = new Point(393, 406);
            btnSnimi.Margin = new Padding(4, 3, 4, 3);
            btnSnimi.Name = "btnSnimi";
            btnSnimi.Size = new Size(88, 27);
            btnSnimi.TabIndex = 8;
            btnSnimi.Text = "Snimi";
            btnSnimi.UseVisualStyleBackColor = true;
            btnSnimi.Click += btnSnimi_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(290, 298);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 9;
            label5.Text = "Polazište:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(287, 339);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 10;
            label6.Text = "Odredište:";
            // 
            // cmbPolaziste
            // 
            cmbPolaziste.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPolaziste.FormattingEnabled = true;
            cmbPolaziste.Location = new Point(358, 294);
            cmbPolaziste.Margin = new Padding(4, 3, 4, 3);
            cmbPolaziste.Name = "cmbPolaziste";
            cmbPolaziste.Size = new Size(163, 23);
            cmbPolaziste.TabIndex = 11;
            cmbPolaziste.Validating += cmbPolaziste_Validating;
            // 
            // cmbOdrediste
            // 
            cmbOdrediste.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOdrediste.FormattingEnabled = true;
            cmbOdrediste.Location = new Point(358, 336);
            cmbOdrediste.Margin = new Padding(4, 3, 4, 3);
            cmbOdrediste.Name = "cmbOdrediste";
            cmbOdrediste.Size = new Size(163, 23);
            cmbOdrediste.TabIndex = 12;
            cmbOdrediste.Validating += cmbOdrediste_Validating;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(359, 367);
            label7.Name = "label7";
            label7.Size = new Size(162, 31);
            label7.TabIndex = 13;
            label7.Text = "*Pri unosu cijene, unose se samo brojevi.";
            // 
            // frmDodajKartu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(label7);
            Controls.Add(cmbOdrediste);
            Controls.Add(cmbPolaziste);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnSnimi);
            Controls.Add(txtCijena);
            Controls.Add(cbZona);
            Controls.Add(cbVrstaKarte);
            Controls.Add(cbTipKarte);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "frmDodajKartu";
            Text = "DodajKartu";
            Load += frmDodajKartu_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbTipKarte;
        private ComboBox cbVrstaKarte;
        private ComboBox cbZona;
        private TextBox txtCijena;
        private Button btnSnimi;
        private ErrorProvider errorProvider;
        private ComboBox cmbOdrediste;
        private ComboBox cmbPolaziste;
        private Label label6;
        private Label label5;
        private Label label7;
    }
}