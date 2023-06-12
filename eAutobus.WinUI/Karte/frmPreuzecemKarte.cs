using eAutobus.WinUI.Korisnici;
using eAutobusModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAutobus.WinUI.Karte
{
    public partial class frmPreuzecemKarte : Form
    {
        private readonly APIService _karte = new APIService("Karta");
        public frmPreuzecemKarte()
        {
            InitializeComponent();
        }

        private async void frmPreuzecemKarte_Load(object sender, EventArgs e)
        {
            var listPrikaz = new List<KartaModel>();
            List<KartaModel> list = await _karte.Get<List<KartaModel>>(null);
            foreach (var item in list)
            {
                item.CijenaString = item.Cijena.ToString() + " KM";
            }
            dgvPrikazKarata.AutoGenerateColumns = false;
            dgvPrikazKarata.DataSource = list;

        }

        private async void dgvPrikazKarata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var IdKarta = dgvPrikazKarata.SelectedRows[0].Cells[0].Value;
            var karta = await _karte.GetById<KartaModel>(IdKarta);
            if (dgvPrikazKarata.CurrentCell is DataGridViewCheckBoxCell && karta != null)
            {
                await _karte.Update<KartaModel>(karta.KartaID, karta);
            }

        }
    }
}
