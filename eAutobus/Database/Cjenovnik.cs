using System.ComponentModel.DataAnnotations.Schema;

namespace eAutobus.Database
{
    public class Cjenovnik
    {
        public int CjenovnikID { get; set; }

        public Zona Zona { get; set; }
        public int ZonaID { get; set; }
        public VrstaKarte VrstaKarte { get; set; }
        public int VrstaKarteID { get; set; }
        public TipKarte Tipkarte { get; set; }
        public int TipkarteID { get; set; }
        
        public int PolazisteID { get; set; }
        public virtual Stanica Polaziste { get; set; }
        
        public int OdredisteID { get; set; }
        public virtual Stanica Odrediste { get; set; }

        public double Cijena { get; set; }
        public bool IsDeleted { get; set; }
    }
}
