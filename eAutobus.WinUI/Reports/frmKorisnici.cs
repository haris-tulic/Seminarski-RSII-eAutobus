using eAutobusModel;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAutobus.WinUI.Reports
{
    public partial class frmKorisnici : Form
    {
        IEnumerable<KorisnikModel> _korisnici;
        public frmKorisnici(List<KorisnikModel> korisnik)
        {
            _korisnici=korisnik;
            InitializeComponent();
        }

        private void frmKorisnici_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "eAutobus.WinUI.Reports.rptKorisnici.rdlc";
            var rpc = new ReportParameterCollection();
            var rds = new ReportDataSource();
            rds.Name = "PrikazKorisnika";
            rds.Value = _korisnici;
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);

            reportViewer1.RefreshReport();
        }
    }
}
