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
    public partial class frmIzdanaKarta : Form
    {
        IzvjestajIzdanaKartaModel _karta;
        public frmIzdanaKarta(IzvjestajIzdanaKartaModel karta)
        {
            _karta = karta;
            InitializeComponent();
        }

        private void frmIzdanaKarta_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "eAutobus.WinUI.Reports.rptIzdanaKarta.rdlc";
            var rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ImeIPrezime", _karta.ImePrezime));
            rpc.Add(new ReportParameter("AdresaStanovanja", _karta.AdresaStanovanja));
            rpc.Add(new ReportParameter("VrstaKarte", _karta.VrstaKarte));
            rpc.Add(new ReportParameter("TipKarte", _karta.TipKarte));
            rpc.Add(new ReportParameter("Polaziste", _karta.Polaziste));
            rpc.Add(new ReportParameter("Odrediste", _karta.Odrediste));
            rpc.Add(new ReportParameter("DatumVadjenjaKarte", _karta.DatumVadjenja.ToString()));
            rpc.Add(new ReportParameter("DatumVazenjaKarte", _karta.DatumVazenja.ToString()));
            rpc.Add(new ReportParameter("Pravac", _karta.Pravac));
            rpc.Add(new ReportParameter("Cijena", _karta.Cijena));
            reportViewer1.LocalReport.SetParameters(rpc);

            reportViewer1.RefreshReport();
        }
    }
}
