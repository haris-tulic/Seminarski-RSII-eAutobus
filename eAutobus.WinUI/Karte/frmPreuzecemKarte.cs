﻿using eAutobusModel;
using eAutobusModel.Requests;

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
            await loadKarte();
        }

        private async Task loadKarte()
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
                PlatiKartuUpsertRequest kartaUpsert = new PlatiKartuUpsertRequest
                {
                    KartaID = karta.KartaID,
                    KupacID = karta.KupacID,
                    DatumVadjenjaKarte = karta.DatumVadjenjaKarte,
                    DatumVazenjaKarte = karta.DatumVazenjaKarte,
                    Cijena = karta.Cijena,
                    JeLiPlacena = true,
                };

                if (dgvPrikazKarata.CurrentCell is DataGridViewCheckBoxCell checkBoxCell)
                {
                    bool isChecked = (bool)checkBoxCell.Value;
                    if (!isChecked)
                    {
                        DialogResult odgovor = MessageBox.Show("Da li zelite kartu oznaciti kao Placena", "Placanje karte", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (odgovor == DialogResult.Yes)
                        {
                            var response = await _karte.UplatiKartu<KartaModel>(IdKarta, kartaUpsert);
                            loadKarte();
                        }
                    }
                }



            }
        }
    }
}
