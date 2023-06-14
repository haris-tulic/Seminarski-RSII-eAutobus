
namespace eAutobus.WinUI.Autobusi
{
    partial class frmAutobusiPrikaz
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
            groupBox1 = new GroupBox();
            dgvAutobusi = new DataGridView();
            AutobusID = new DataGridViewTextBoxColumn();
            MarkaAutobusa = new DataGridViewTextBoxColumn();
            BrojSjedista = new DataGridViewTextBoxColumn();
            DatumProizvodnje = new DataGridViewTextBoxColumn();
            NazivGaraze = new DataGridViewTextBoxColumn();
            Ispravan = new DataGridViewCheckBoxColumn();
            Akcija = new DataGridViewButtonColumn();
            btnPrikazi = new Button();
            txtMarkaVozila = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutobusi).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvAutobusi);
            groupBox1.Location = new Point(121, 220);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(809, 344);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Autobusi";
            // 
            // dgvAutobusi
            // 
            dgvAutobusi.AllowUserToAddRows = false;
            dgvAutobusi.AllowUserToDeleteRows = false;
            dgvAutobusi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutobusi.Columns.AddRange(new DataGridViewColumn[] { AutobusID, MarkaAutobusa, BrojSjedista, DatumProizvodnje, NazivGaraze, Ispravan, Akcija });
            dgvAutobusi.Dock = DockStyle.Fill;
            dgvAutobusi.Location = new Point(3, 18);
            dgvAutobusi.Margin = new Padding(3, 2, 3, 2);
            dgvAutobusi.Name = "dgvAutobusi";
            dgvAutobusi.ReadOnly = true;
            dgvAutobusi.RowHeadersWidth = 51;
            dgvAutobusi.RowTemplate.Height = 24;
            dgvAutobusi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutobusi.Size = new Size(803, 324);
            dgvAutobusi.TabIndex = 0;
            dgvAutobusi.MouseDoubleClick += dgvAutobusi_MouseDoubleClick;
            // 
            // AutobusID
            // 
            AutobusID.DataPropertyName = "AutobusID";
            AutobusID.HeaderText = "AutobusID";
            AutobusID.MinimumWidth = 6;
            AutobusID.Name = "AutobusID";
            AutobusID.ReadOnly = true;
            AutobusID.Visible = false;
            AutobusID.Width = 125;
            // 
            // MarkaAutobusa
            // 
            MarkaAutobusa.DataPropertyName = "MarkaAutobusa";
            MarkaAutobusa.HeaderText = "Marka autobusa";
            MarkaAutobusa.MinimumWidth = 6;
            MarkaAutobusa.Name = "MarkaAutobusa";
            MarkaAutobusa.ReadOnly = true;
            MarkaAutobusa.Width = 125;
            // 
            // BrojSjedista
            // 
            BrojSjedista.DataPropertyName = "BrojSjedista";
            BrojSjedista.HeaderText = "Broj sjedista";
            BrojSjedista.MinimumWidth = 6;
            BrojSjedista.Name = "BrojSjedista";
            BrojSjedista.ReadOnly = true;
            BrojSjedista.Width = 125;
            // 
            // DatumProizvodnje
            // 
            DatumProizvodnje.DataPropertyName = "DatumProizvodnje";
            DatumProizvodnje.HeaderText = "Datum proizvodnje";
            DatumProizvodnje.MinimumWidth = 6;
            DatumProizvodnje.Name = "DatumProizvodnje";
            DatumProizvodnje.ReadOnly = true;
            DatumProizvodnje.Width = 125;
            // 
            // NazivGaraze
            // 
            NazivGaraze.DataPropertyName = "NazivGaraze";
            NazivGaraze.HeaderText = "Garaza";
            NazivGaraze.MinimumWidth = 6;
            NazivGaraze.Name = "NazivGaraze";
            NazivGaraze.ReadOnly = true;
            NazivGaraze.Width = 125;
            // 
            // Ispravan
            // 
            Ispravan.DataPropertyName = "Ispravan";
            Ispravan.HeaderText = "Ispravan";
            Ispravan.MinimumWidth = 6;
            Ispravan.Name = "Ispravan";
            Ispravan.ReadOnly = true;
            Ispravan.Width = 125;
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
            // btnPrikazi
            // 
            btnPrikazi.Location = new Point(437, 146);
            btnPrikazi.Margin = new Padding(3, 2, 3, 2);
            btnPrikazi.Name = "btnPrikazi";
            btnPrikazi.Size = new Size(116, 37);
            btnPrikazi.TabIndex = 1;
            btnPrikazi.Text = "Pretraga";
            btnPrikazi.UseVisualStyleBackColor = true;
            btnPrikazi.Click += btnPrikazi_Click;
            // 
            // txtMarkaVozila
            // 
            txtMarkaVozila.Location = new Point(386, 88);
            txtMarkaVozila.Margin = new Padding(3, 2, 3, 2);
            txtMarkaVozila.Name = "txtMarkaVozila";
            txtMarkaVozila.Size = new Size(220, 23);
            txtMarkaVozila.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(449, 56);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 3;
            label1.Text = "Marka vozila:";
            // 
            // frmAutobusiPrikaz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1054, 626);
            Controls.Add(label1);
            Controls.Add(txtMarkaVozila);
            Controls.Add(btnPrikazi);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmAutobusiPrikaz";
            Text = "frmAutobusi";
            Load += frmAutobusiPrikaz_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAutobusi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvAutobusi;
        private Button btnPrikazi;
        private TextBox txtMarkaVozila;
        private Label label1;
        private DataGridViewTextBoxColumn AutobusID;
        private DataGridViewTextBoxColumn MarkaAutobusa;
        private DataGridViewTextBoxColumn BrojSjedista;
        private DataGridViewTextBoxColumn DatumProizvodnje;
        private DataGridViewTextBoxColumn NazivGaraze;
        private DataGridViewCheckBoxColumn Ispravan;
        private DataGridViewButtonColumn Akcija;
    }
}