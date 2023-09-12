using eAutobusModel.Requests;
using System.ComponentModel;

namespace eAutobus.WinUI.Autobusi
{
    public partial class frmDodajAutobus : Form
    {
        private readonly APIService _service = new APIService("Autobusi");
        private readonly APIService _garaze = new APIService("Garaza");
        private int? id = null;
        public frmDodajAutobus(int? autobusID = null)
        {
            InitializeComponent();
            id = autobusID;
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            var request = new AutobusInsertRequest();
            if (this.ValidateChildren())
            {
                request.BrojAutobusa = int.Parse(txtBrojAutobusa.Text);
                request.BrojSjedista = int.Parse(txtBrojSjedista.Text);
                request.DatumProizvodnje = dtpDatumProizvodnje.Value;
                request.MarkaAutobusa = txtMarkaAutobusa.Text;
                request.Ispravan = cbIspravan.Checked;
                request.GarazaID = int.Parse(cbGaraza.SelectedValue.ToString());


                if (id.HasValue)
                {
                    await _service.Update<eAutobusModel.AutobusiModel>(id, request);
                    MessageBox.Show("Novo vozilo uspjesno izmjenjeno!", "Izmjena", MessageBoxButtons.OK);
                }
                else
                {
                    await _service.Insert<eAutobusModel.AutobusiModel>(request);
                    MessageBox.Show("Novo vozilo uspjesno dodano!", "Obavijest", MessageBoxButtons.OK);
                }
            }

            await LoadAutobuse();
        }

        private async void frmDodajAutobus_Load(object sender, EventArgs e)
        {
            await LoadAutobuse();
            await LoadGaraze();
            if (id.HasValue)
            {
                var autobus = await _service.GetById<eAutobusModel.AutobusiModel>(id);
                txtBrojAutobusa.Text = autobus.BrojAutobusa.ToString();
                txtBrojSjedista.Text = autobus.BrojSjedista.ToString();
                txtMarkaAutobusa.Text = autobus.MarkaAutobusa;
                cbIspravan.Checked = autobus.Ispravan;
                cbGaraza.SelectedValue = autobus.GarazaID;
                dtpDatumProizvodnje.Value = autobus.DatumProizvodnje;

            }
        }

        private void txtBrojAutobusa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojAutobusa.Text))
            {
                errorProvider.SetError(txtBrojAutobusa, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtBrojAutobusa, null);
            }
        }

        private void txtMarkaAutobusa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarkaAutobusa.Text))
            {
                errorProvider.SetError(txtMarkaAutobusa, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtMarkaAutobusa, null);
            }
        }

        private void txtBrojSjedista_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojSjedista.Text))
            {
                errorProvider.SetError(txtBrojSjedista, "Obavezno polje");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtBrojSjedista, null);
            }
        }

        private async Task LoadGaraze()
        {
            try
            {
                var result = await _garaze.Get<List<eAutobusModel.GarazaModel>>(null);
                result.Insert(0, new eAutobusModel.GarazaModel { });
                cbGaraza.DataSource = result;
                cbGaraza.DisplayMember = "NazivGaraze";
                cbGaraza.ValueMember = "GarazaID";

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        private async Task LoadAutobuse()
        {
            try
            {
                var result = await _service.Get<List<eAutobusModel.AutobusiModel>>(null);
                dgvPrikazAutobusa.AutoGenerateColumns = false;
                dgvPrikazAutobusa.DataSource = result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private void cbGaraza_Validating(object sender, CancelEventArgs e)
        {

            if (cbGaraza.SelectedValue != null)
            {
                if (string.IsNullOrWhiteSpace(cbGaraza.SelectedValue.ToString()) || cbGaraza.SelectedValue.ToString() == "0")
                {
                    errorProvider.SetError(cbGaraza, "Obavezno polje!");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(cbGaraza, null);
                }
            }
            else
            {
                errorProvider.SetError(cbGaraza, "Obavezno polje!");
                e.Cancel = true;
            }

        }

        private void txtBrojAutobusa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBrojSjedista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
