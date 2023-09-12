using eAutobusModel;
using eAutobusModel.Requests;
using System.ComponentModel;

namespace eAutobus.WinUI.RedVoznji
{
    public partial class frmDodavanjeRedaVoznje : Form
    {
        private readonly APIService _autobusi = new APIService("Autobusi");
        private readonly APIService _vozaciKondukteri = new APIService("Vozac");
        private readonly APIService _stanice = new APIService("Stanica");
        private readonly APIService _redVoznje = new APIService("RasporedVoznje");
        private int? id = null;

        public frmDodavanjeRedaVoznje(int? red = null)
        {
            InitializeComponent();
            id = red;
        }

        private async void frmDodavanjeRedaVoznje_Load(object sender, EventArgs e)
        {
            await LoadAutobuse();
            await LoadVozaceIKonduktere();
            await LoadPolazisteIOdrediste();

            if (id.HasValue)
            {
                var redVoznje = await _redVoznje.GetById<RasporedVoznjeModel>(id);
                txtBrLinije.Text = redVoznje.BrojLinije.ToString();
                cbPolaziste.SelectedValue = redVoznje.PolazisteID;
                cbOdrediste.SelectedValue = redVoznje.OdredisteID;
                dtpDatum.Value = redVoznje.Datum;
                cbBrAutobusa.SelectedValue = redVoznje.AutobusID;
                cbKondukter.SelectedValue = redVoznje.KondukterID;
                cbVozac.SelectedValue = redVoznje.VozacID;
                dtpDolazak.Value = redVoznje.VrijemeDolaska;
                dtpPolazak.Value = redVoznje.VrijemePolaska;
            }

        }

        private async Task LoadPolazisteIOdrediste()
        {
            var result = await _stanice.Get<List<StanicaModel>>(null);
            cbPolaziste.DataSource = result;
            cbPolaziste.ValueMember = "StanicaID";
            cbPolaziste.DisplayMember = "NazivLokacijeStanice";

            var entity = await _stanice.Get<List<StanicaModel>>(null);
            cbOdrediste.DataSource = entity;
            cbOdrediste.ValueMember = "StanicaID";
            cbOdrediste.DisplayMember = "NazivLokacijeStanice";
        }

        private async Task LoadVozaceIKonduktere()
        {
            try
            {
                var result = await _vozaciKondukteri.Get<List<eAutobusModel.VozacModel>>(null);
                cbVozac.DataSource = result;
                cbVozac.ValueMember = "VozacID";
                cbVozac.DisplayMember = "Ime";

                var entity = await _vozaciKondukteri.Get<List<eAutobusModel.VozacModel>>(null);
                cbKondukter.DataSource = entity;
                cbKondukter.ValueMember = "VozacID";
                cbKondukter.DisplayMember = "Ime";
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private async Task LoadAutobuse()
        {
            var listIspravnih = new List<AutobusiModel>();
            var list = await _autobusi.Get<List<eAutobusModel.AutobusiModel>>(null);
            foreach (var ispravan in list)
            {
                ispravan.PrikazAutobusa = ispravan.BrojAutobusa.ToString() + "-" + ispravan.MarkaAutobusa;
                if (ispravan.Ispravan)
                {
                    listIspravnih.Add(ispravan);
                }
            }
            cbBrAutobusa.DataSource = listIspravnih;
            cbBrAutobusa.DisplayMember = "PrikazAutobusa";
            cbBrAutobusa.ValueMember = "AutobusID";


        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            var newLine = new RasporedVoznjeUpsertRequest();
            if (this.ValidateChildren())
            {
                newLine.BrojLinije = int.Parse(txtBrLinije.Text);
                newLine.VrijemeDolaska = dtpDolazak.Value;
                newLine.VrijemePolaska = dtpPolazak.Value;
                newLine.AutobusID = int.Parse(cbBrAutobusa.SelectedValue.ToString());
                newLine.KondukterID = int.Parse(cbKondukter.SelectedValue.ToString());
                newLine.OdredisteID = int.Parse(cbOdrediste.SelectedValue.ToString());
                newLine.PolazisteID = int.Parse(cbPolaziste.SelectedValue.ToString());
                newLine.VozacID = int.Parse(cbVozac.SelectedValue.ToString());
                newLine.Datum = DateTime.Parse(dtpDatum.Value.ToShortDateString());

                if (id.HasValue)
                {
                    await _redVoznje.Update<RasporedVoznjeModel>(id, newLine);
                    MessageBox.Show("Uspjesno izmjenjena linija!", "Izmjena", MessageBoxButtons.OK);

                }
                else
                {
                    await _redVoznje.Insert<RasporedVoznjeModel>(newLine);
                    MessageBox.Show("Uspjesno kreirana linija!", "Obavijest", MessageBoxButtons.OK);
                }
            }

        }

        private void txtBrojLinije_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrLinije.Text))
            {
                errorDodavanjeLinije.SetError(txtBrLinije, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorDodavanjeLinije.SetError(txtBrLinije, null);
            }
        }

        private void cbPolaziste_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbPolaziste.SelectedValue.ToString()))
            {
                errorDodavanjeLinije.SetError(cbPolaziste, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorDodavanjeLinije.SetError(cbPolaziste, null);
            }
        }

        private void cbOdrediste_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbOdrediste.SelectedValue.ToString()))
            {
                errorDodavanjeLinije.SetError(cbOdrediste, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorDodavanjeLinije.SetError(cbOdrediste, null);
            }
        }

        private void cbBrAutobusa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbBrAutobusa.SelectedValue.ToString()))
            {
                errorDodavanjeLinije.SetError(cbBrAutobusa, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorDodavanjeLinije.SetError(cbBrAutobusa, null);
            }
        }

        private void cbVozac_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cbVozac.SelectedValue.ToString()))
            {
                errorDodavanjeLinije.SetError(cbVozac, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorDodavanjeLinije.SetError(cbVozac, null);
            }
        }

        private void dtpDatum_ValueChanged(object sender, EventArgs e)
        {
            dtpDatum.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpDatum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(dtpDatum.Text.ToString()))
            {
                errorDodavanjeLinije.SetError(dtpDatum, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorDodavanjeLinije.SetError(dtpDatum, null);
            }
        }

        private void dtpDolazak_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(dtpDolazak.Text.ToString()))
            {
                errorDodavanjeLinije.SetError(dtpDolazak, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorDodavanjeLinije.SetError(dtpDolazak, null);
            }
        }

        private void dtpPolazak_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(dtpPolazak.Text.ToString()))
            {
                errorDodavanjeLinije.SetError(dtpPolazak, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorDodavanjeLinije.SetError(dtpPolazak, null);
            }
        }

        private void txtBrLinije_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
