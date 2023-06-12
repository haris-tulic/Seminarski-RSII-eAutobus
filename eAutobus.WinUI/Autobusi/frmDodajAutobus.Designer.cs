
namespace eAutobus.WinUI.Autobusi
{
    partial class frmDodajAutobus
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
            txtBrojAutobusa = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtBrojSjedista = new TextBox();
            label3 = new Label();
            txtMarkaAutobusa = new TextBox();
            label5 = new Label();
            dtpDatumProizvodnje = new DateTimePicker();
            label4 = new Label();
            label6 = new Label();
            cbIspravan = new CheckBox();
            btnSpremi = new Button();
            cbGaraza = new ComboBox();
            errorProvider = new ErrorProvider(components);
            dgvPrikazAutobusa = new DataGridView();
            AutobusID = new DataGridViewTextBoxColumn();
            BrojAutobusa = new DataGridViewTextBoxColumn();
            MarkaAutobusa = new DataGridViewTextBoxColumn();
            DatumProizvodnje = new DataGridViewTextBoxColumn();
            BrojSjedista = new DataGridViewTextBoxColumn();
            NazivGaraze = new DataGridViewTextBoxColumn();
            Ispravan = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrikazAutobusa).BeginInit();
            SuspendLayout();
            // 
            // txtBrojAutobusa
            // 
            txtBrojAutobusa.Location = new Point(53, 100);
            txtBrojAutobusa.Margin = new Padding(4, 5, 4, 5);
            txtBrojAutobusa.Name = "txtBrojAutobusa";
            txtBrojAutobusa.Size = new Size(295, 27);
            txtBrojAutobusa.TabIndex = 0;
            txtBrojAutobusa.Validating += txtBrojAutobusa_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 75);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 1;
            label1.Text = "Broj autobusa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(592, 75);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 3;
            label2.Text = "Broj sjedista:";
            // 
            // txtBrojSjedista
            // 
            txtBrojSjedista.Location = new Point(596, 100);
            txtBrojSjedista.Margin = new Padding(4, 5, 4, 5);
            txtBrojSjedista.Name = "txtBrojSjedista";
            txtBrojSjedista.Size = new Size(295, 27);
            txtBrojSjedista.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 185);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 5;
            label3.Text = "Marka autobusa:";
            // 
            // txtMarkaAutobusa
            // 
            txtMarkaAutobusa.Location = new Point(53, 209);
            txtMarkaAutobusa.Margin = new Padding(4, 5, 4, 5);
            txtMarkaAutobusa.Name = "txtMarkaAutobusa";
            txtMarkaAutobusa.Size = new Size(295, 27);
            txtMarkaAutobusa.TabIndex = 4;
            txtMarkaAutobusa.Validating += txtMarkaAutobusa_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(53, 311);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 9;
            label5.Text = "Garaza:";
            // 
            // dtpDatumProizvodnje
            // 
            dtpDatumProizvodnje.Location = new Point(596, 234);
            dtpDatumProizvodnje.Margin = new Padding(4, 5, 4, 5);
            dtpDatumProizvodnje.Name = "dtpDatumProizvodnje";
            dtpDatumProizvodnje.Size = new Size(265, 27);
            dtpDatumProizvodnje.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(592, 209);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(140, 20);
            label4.TabIndex = 13;
            label4.Text = "Datum proizvodnje:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(600, 335);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(64, 20);
            label6.TabIndex = 14;
            label6.Text = "Ispravan";
            // 
            // cbIspravan
            // 
            cbIspravan.AutoSize = true;
            cbIspravan.Location = new Point(617, 360);
            cbIspravan.Margin = new Padding(4, 5, 4, 5);
            cbIspravan.Name = "cbIspravan";
            cbIspravan.Size = new Size(18, 17);
            cbIspravan.TabIndex = 15;
            cbIspravan.UseVisualStyleBackColor = true;
            // 
            // btnSpremi
            // 
            btnSpremi.Location = new Point(441, 434);
            btnSpremi.Margin = new Padding(4, 5, 4, 5);
            btnSpremi.Name = "btnSpremi";
            btnSpremi.Size = new Size(100, 35);
            btnSpremi.TabIndex = 16;
            btnSpremi.Text = "Spremi";
            btnSpremi.UseVisualStyleBackColor = true;
            btnSpremi.Click += btnSpremi_Click;
            // 
            // cbGaraza
            // 
            cbGaraza.FormattingEnabled = true;
            cbGaraza.Location = new Point(53, 335);
            cbGaraza.Margin = new Padding(4, 5, 4, 5);
            cbGaraza.Name = "cbGaraza";
            cbGaraza.Size = new Size(295, 28);
            cbGaraza.TabIndex = 17;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // dgvPrikazAutobusa
            // 
            dgvPrikazAutobusa.AllowUserToAddRows = false;
            dgvPrikazAutobusa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrikazAutobusa.Columns.AddRange(new DataGridViewColumn[] { AutobusID, BrojAutobusa, MarkaAutobusa, DatumProizvodnje, BrojSjedista, NazivGaraze, Ispravan });
            dgvPrikazAutobusa.Location = new Point(75, 503);
            dgvPrikazAutobusa.Margin = new Padding(4, 5, 4, 5);
            dgvPrikazAutobusa.Name = "dgvPrikazAutobusa";
            dgvPrikazAutobusa.ReadOnly = true;
            dgvPrikazAutobusa.RowHeadersWidth = 51;
            dgvPrikazAutobusa.Size = new Size(806, 398);
            dgvPrikazAutobusa.TabIndex = 18;
            // 
            // AutobusID
            // 
            AutobusID.DataPropertyName = "AutobusID";
            AutobusID.HeaderText = "ID";
            AutobusID.MinimumWidth = 6;
            AutobusID.Name = "AutobusID";
            AutobusID.ReadOnly = true;
            AutobusID.Visible = false;
            AutobusID.Width = 125;
            // 
            // BrojAutobusa
            // 
            BrojAutobusa.DataPropertyName = "BrojAutobusa";
            BrojAutobusa.HeaderText = "Broj autobusa";
            BrojAutobusa.MinimumWidth = 6;
            BrojAutobusa.Name = "BrojAutobusa";
            BrojAutobusa.ReadOnly = true;
            BrojAutobusa.Width = 125;
            // 
            // MarkaAutobusa
            // 
            MarkaAutobusa.DataPropertyName = "MarkaAutobusa";
            MarkaAutobusa.HeaderText = "Marka";
            MarkaAutobusa.MinimumWidth = 6;
            MarkaAutobusa.Name = "MarkaAutobusa";
            MarkaAutobusa.ReadOnly = true;
            MarkaAutobusa.Width = 125;
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
            // BrojSjedista
            // 
            BrojSjedista.DataPropertyName = "BrojSjedista";
            BrojSjedista.HeaderText = "Broj sjedista";
            BrojSjedista.MinimumWidth = 6;
            BrojSjedista.Name = "BrojSjedista";
            BrojSjedista.ReadOnly = true;
            BrojSjedista.Width = 125;
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
            Ispravan.Resizable = DataGridViewTriState.True;
            Ispravan.SortMode = DataGridViewColumnSortMode.Automatic;
            Ispravan.Width = 125;
            // 
            // frmDodajAutobus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 926);
            Controls.Add(dgvPrikazAutobusa);
            Controls.Add(cbGaraza);
            Controls.Add(btnSpremi);
            Controls.Add(cbIspravan);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(dtpDatumProizvodnje);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(txtMarkaAutobusa);
            Controls.Add(label2);
            Controls.Add(txtBrojSjedista);
            Controls.Add(label1);
            Controls.Add(txtBrojAutobusa);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmDodajAutobus";
            Text = "frmDodajAutobus";
            Load += frmDodajAutobus_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrikazAutobusa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBrojAutobusa;
        private Label label1;
        private Label label2;
        private TextBox txtBrojSjedista;
        private Label label3;
        private TextBox txtMarkaAutobusa;
        private Label label5;
        private DateTimePicker dtpDatumProizvodnje;
        private Label label4;
        private Label label6;
        private CheckBox cbIspravan;
        private Button btnSpremi;
        private ComboBox cbGaraza;
        private ErrorProvider errorProvider;
        private DataGridView dgvPrikazAutobusa;
        private DataGridViewTextBoxColumn AutobusID;
        private DataGridViewTextBoxColumn BrojAutobusa;
        private DataGridViewTextBoxColumn MarkaAutobusa;
        private DataGridViewTextBoxColumn DatumProizvodnje;
        private DataGridViewTextBoxColumn BrojSjedista;
        private DataGridViewTextBoxColumn NazivGaraze;
        private DataGridViewCheckBoxColumn Ispravan;
    }
}