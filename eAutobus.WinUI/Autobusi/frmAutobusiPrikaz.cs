﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using eAutobusModel.Requests;
using eAutobusModel;

namespace eAutobus.WinUI.Autobusi
{
    public partial class frmAutobusiPrikaz : Form
    {
        private APIService _service = new APIService("Autobusi");
        public frmAutobusiPrikaz()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new AutobusGetRequest
            {
                Marka = txtMarkaVozila.Text
            };
            var result = await _service.Get<List<eAutobusModel.AutobusiModel>>(search);
            dgvAutobusi.AutoGenerateColumns = false;
            dgvAutobusi.DataSource = result;
        }

        private async Task LoadAutobuse()
        {
            var list = await _service.Get<List<AutobusiModel>>(null);
            dgvAutobusi.AutoGenerateColumns = false;
            dgvAutobusi.DataSource = list;
        }

        private async void frmAutobusiPrikaz_Load(object sender, EventArgs e)
        {
            await LoadAutobuse();
        }

        private async void dgvAutobusi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var idAutobus = dgvAutobusi.SelectedRows[0].Cells[0].Value;
            var odabraniAutobus = await _service.GetById<AutobusiModel>(idAutobus);
            if (dgvAutobusi.CurrentCell is DataGridViewButtonCell)
            {
                DialogResult odgovor = MessageBox.Show("Da li zelite izbrisati odabrani autobus?", "Izbrisati zapis", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (odgovor == DialogResult.Yes)
                {
                    await _service.Delete<AutobusiModel>(idAutobus);
                    MessageBox.Show("Izbrisali ste odabrani autobus: " + odabraniAutobus.BrojAutobusa + " ---> " + odabraniAutobus.MarkaAutobusa);
                    await LoadAutobuse();
                }
            }

        }

        private void dgvAutobusi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var idAutobus = dgvAutobusi.SelectedRows[0].Cells[0].Value;
            frmDodajAutobus frm = new frmDodajAutobus(int.Parse(idAutobus.ToString()));
            frm.Show();
        }
    }
}
