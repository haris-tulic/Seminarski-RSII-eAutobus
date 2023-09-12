
namespace eAutobus.WinUI.Korisnici
{
    partial class frmKorisniciDodajRegistracija
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
            txtKorisnickoIme = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnPotvrdi = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(275, 231);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 0;
            label1.Text = "Korisnicko ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(304, 307);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(255, 377);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 2;
            label3.Text = "Confirm password:";
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.Location = new Point(387, 227);
            txtKorisnickoIme.Margin = new Padding(5, 5, 5, 5);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(223, 27);
            txtKorisnickoIme.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(387, 301);
            txtPassword.Margin = new Padding(5, 5, 5, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(223, 27);
            txtPassword.TabIndex = 4;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Enabled = false;
            txtConfirmPassword.Location = new Point(387, 372);
            txtConfirmPassword.Margin = new Padding(5, 5, 5, 5);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(223, 27);
            txtConfirmPassword.TabIndex = 5;
            // 
            // btnPotvrdi
            // 
            btnPotvrdi.Location = new Point(433, 472);
            btnPotvrdi.Margin = new Padding(5, 5, 5, 5);
            btnPotvrdi.Name = "btnPotvrdi";
            btnPotvrdi.Size = new Size(129, 35);
            btnPotvrdi.TabIndex = 6;
            btnPotvrdi.Text = "Potvrdi";
            btnPotvrdi.UseVisualStyleBackColor = true;
            btnPotvrdi.Click += btnPotvrdi_Click;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(365, 419);
            label4.Name = "label4";
            label4.Size = new Size(287, 45);
            label4.TabIndex = 7;
            label4.Text = "*Prilikom izmjene korisnika, ostavljanjem praznog polja password, password ostaje isti!";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmKorisniciDodajRegistracija
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 692);
            Controls.Add(label4);
            Controls.Add(btnPotvrdi);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtKorisnickoIme);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "frmKorisniciDodajRegistracija";
            Text = "Registracija korisnika";
            Load += frmKorisniciDodajRegistracija_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtKorisnickoIme;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnPotvrdi;
        private Label label4;
    }
}