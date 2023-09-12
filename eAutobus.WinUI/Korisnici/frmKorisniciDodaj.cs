using eAutobusModel;
using eAutobusModel.Requests;
using System.ComponentModel;

namespace eAutobus.WinUI.Korisnici
{
    public partial class frmKorisniciDodaj : Form
    {
        private readonly APIService _uloge = new APIService("Uloge");
        private readonly APIService _korisnik = new APIService("Korisnik");
        private readonly APIService _grad = new APIService("Grad");
        private int? id = null;
        public frmKorisniciDodaj(int? updateID = null)
        {
            id = updateID;
            InitializeComponent();
        }

        private async void frmKorisniciDodaj_Load(object sender, EventArgs e)
        {

            await LoadKorisnika();
            await LoadGrad();
            if (id.HasValue)
            {
                var entity = await _korisnik.GetById<KorisnikModel>(id);
                txtIme.Text = entity.Ime;
                txtPrezime.Text = entity.Prezime;
                txtEmail.Text = entity.Email;
                dtpDatumRodjenja.Value = entity.DatumRodjenja;
                txtBrojTelefona.Text = entity.BrojTelefona;
                txtAdresaStanovanja.Text = entity.AdresaStanovanja;
                cmbGrad.SelectedValue = entity.GradID;
                cmbUloga.SelectedValue = entity.UlogeID;
            }
        }

        private async Task LoadGrad()
        {
            var listG = await _grad.Get<List<GradModel>>(null);
            cmbGrad.DataSource = listG;
            cmbGrad.ValueMember = "GradID";
            cmbGrad.DisplayMember = "NazivGrada";
        }

        private async Task LoadKorisnika()
        {
            var listUloge = await _uloge.Get<List<UlogeModel>>(null);
            cmbUloga.DataSource = listUloge;
            cmbUloga.ValueMember = "UlogeID";
            cmbUloga.DisplayMember = "Naziv";
        }



        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIme.Text))
            {
                errorKorisnik.SetError(txtIme, "Obavezno polje!");
                e.Cancel = true;
            }
            else
            {
                errorKorisnik.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrezime.Text))
            {
                errorKorisnik.SetError(txtPrezime, "Obavezno polje!");
                e.Cancel = true;
            }
            else
            {
                errorKorisnik.SetError(txtPrezime, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorKorisnik.SetError(txtEmail, "Obavezno polje!");
                e.Cancel = true;
            }
            else
            {
                errorKorisnik.SetError(txtEmail, null);
            }
        }

        private void dtpDatumRodjenja_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(dtpDatumRodjenja.Text))
            {
                errorKorisnik.SetError(dtpDatumRodjenja, "Obavezno polje!");
                e.Cancel = true;
            }
            else
            {
                errorKorisnik.SetError(dtpDatumRodjenja, null);
            }
        }

        private void txtBrojTelefona_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBrojTelefona.Text))
            {
                errorKorisnik.SetError(txtBrojTelefona, "Obavezno polje!");
                e.Cancel = true;
            }
            else
            {
                errorKorisnik.SetError(txtBrojTelefona, null);
            }
        }
        private void txtAdresaStanovanja_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdresaStanovanja.Text))
            {
                errorKorisnik.SetError(txtAdresaStanovanja, "Obavezno polje!");
                e.Cancel = true;
            }
            else
            {
                errorKorisnik.SetError(txtAdresaStanovanja, null);
            }
        }

        private void cmbGrad_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbGrad.SelectedItem.ToString()))
            {
                errorKorisnik.SetError(cmbGrad, "Obavezno polje!");
                e.Cancel = true;
            }
            else
            {
                errorKorisnik.SetError(cmbGrad, null);
            }
        }

        private void cmbUloga_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbUloga.SelectedItem.ToString()))
            {
                errorKorisnik.SetError(cmbUloga, "Obavezno polje!");
                e.Cancel = true;
            }
            else
            {
                errorKorisnik.SetError(cmbUloga, null);
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            var entity = new KorisnikUpsertRequest();
            if (this.ValidateChildren())
            {
                entity.Ime = txtIme.Text;
                entity.Prezime = txtPrezime.Text;
                entity.Email = txtEmail.Text;
                entity.DatumRodjenja = dtpDatumRodjenja.Value;
                entity.BrojTelefona = txtBrojTelefona.Text;
                entity.AdresaStanovanja = txtAdresaStanovanja.Text;
                entity.GradID = int.Parse(cmbGrad.SelectedValue.ToString());
                entity.UlogeID = int.Parse(cmbUloga.SelectedValue.ToString());

                if (id.HasValue)
                {
                    entity.KorisnikID = id;
                    frmKorisniciDodajRegistracija frm = new frmKorisniciDodajRegistracija(entity);
                    frm.Show();
                }
                else
                {
                    frmKorisniciDodajRegistracija frm = new frmKorisniciDodajRegistracija(entity);
                    frm.Show();
                }
            }

        }

        private void txtBrojTelefona_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
