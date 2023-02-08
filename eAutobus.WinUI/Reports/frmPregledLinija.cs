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
    public partial class frmPregledLinija : Form
    {
        IEnumerable<RasporedVoznjeModel> _linije;
        public frmPregledLinija(List<RasporedVoznjeModel> linije)
        {
            _linije = linije;
            InitializeComponent();
        }

        private void frmPregledLinija_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "eAutobus.WinUI.Reports.rptPregledLinija.rdlc";
            var rpc = new ReportParameterCollection();
            var rds = new ReportDataSource();
            rds.Name = "PrikazLinija";
            rds.Value = _linije;
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);

            reportViewer1.RefreshReport();
        }
    }
}
