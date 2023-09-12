using eAutobusModel;
using eAutobusModel.Requests;

namespace eAutobus.WinUI.Korisnici
{
    public partial class frmKorisniciDodajRegistracija : Form
    {
        private readonly APIService _korisnikService = new APIService("Korisnik");
        private KorisnikUpsertRequest _korisnik = new KorisnikUpsertRequest();
        public frmKorisniciDodajRegistracija(KorisnikUpsertRequest korisnik)
        {
            InitializeComponent();
            _korisnik = korisnik;
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (_korisnik != null)
            {
                _korisnik.KorisnickoIme = txtKorisnickoIme.Text;
                _korisnik.Password = txtPassword.Text;
                _korisnik.PasswordPotrvda = txtConfirmPassword.Text;


                if (_korisnik.KorisnikID.HasValue)
                {
                    if (ProvjeraPostojecegKorisnika())
                    {
                        await _korisnikService.Update<KorisnikModel>(_korisnik.KorisnikID, _korisnik);
                        MessageBox.Show("Korisnik je izmjenjen!", "Izmjena", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
                else
                {
                    if (ProvjeraNovogKorisnika())
                    {
                        await _korisnikService.Insert<KorisnikModel>(_korisnik);
                        MessageBox.Show("Novi korisnik uspjesno dodan!", "Obavijest", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
        }

        private bool ProvjeraPostojecegKorisnika()
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                MessageBox.Show("Nisu uneseni validni kredencijali!", "Upozorenje", MessageBoxButtons.OK);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwordi se ne slazu!", "Upozorenje", MessageBoxButtons.OK);
                    return false;
                }
            }

            return true;
        }

        private bool ProvjeraNovogKorisnika()
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Nisu uneseni kredencijali za korisnika!", "Upozorenje", MessageBoxButtons.OK);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwordi se ne slazu!", "Upozorenje", MessageBoxButtons.OK);
                    return false;
                }

            }

            return true;
        }

        private async void frmKorisniciDodajRegistracija_Load(object sender, EventArgs e)
        {
            if (_korisnik.KorisnikID.HasValue)
            {
                var entity = await _korisnikService.GetById<KorisnikModel>(_korisnik.KorisnikID);
                if (entity != null)
                {
                    txtKorisnickoIme.Text = entity.KorisnickoIme;
                }
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtConfirmPassword.Enabled = true;
            }
            else
            {
                txtConfirmPassword.Enabled = false;
                txtConfirmPassword.Text = string.Empty;
            }
        }
    }
}
