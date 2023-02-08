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
    public partial class PregledKarata : Form
    {
        IEnumerable<CjenovnikModel> _cjenovnik;
        public PregledKarata(IEnumerable<CjenovnikModel> cjenovnik)
        {
            _cjenovnik = cjenovnik;
            InitializeComponent();
        }

        private void PregledKarata_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "eAutobus.WinUI.Reports.PregledKarataView.rdlc";
            var rpc = new ReportParameterCollection();
            var rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = _cjenovnik;
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);

            reportViewer1.RefreshReport();

            
        }
    }
}
