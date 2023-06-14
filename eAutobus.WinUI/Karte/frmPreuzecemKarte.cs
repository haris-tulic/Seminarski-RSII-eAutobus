using eAutobus.WinUI.Korisnici;
using eAutobusModel;
using eAutobusModel.Requests;
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
            loadKarte();
            

        }

        private async void loadKarte()
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
            if (dgvPrikazKarata.SelectedRows.Count > 0)
            {

                var IdKarta = int.Parse(dgvPrikazKarata.SelectedRows[0].Cells[0].Value.ToString());
                var karta = await _karte.GetById<KartaModel>(IdKarta);
                KartaUpsertRequest kartaUpsert = new KartaUpsertRequest();
                kartaUpsert = null;

                DialogResult odgovor = MessageBox.Show("Da li zelite kartu oznaciti kao Placena", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (odgovor == DialogResult.Yes)
                    {
                        var response =  await _karte.PlatiKartu<KartaModel>(IdKarta, kartaUpsert);
                    }

                loadKarte();
            }
        }
    }
}
