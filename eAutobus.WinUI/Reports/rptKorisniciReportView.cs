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
    public partial class rptKorisniciReportView : Form
    {
        public List<KorisnikModel> _korisnici;
        public rptKorisniciReportView(List<KorisnikModel> korisnici)
        {
            _korisnici = korisnici;
            InitializeComponent();
        }
         
        private void rptKorisniciReportView_Load(object sender, EventArgs e)
        {
            KorisnikModelBindingSource.DataSource = _korisnici;
            this.reportViewer1.RefreshReport();
        }
    }
}
