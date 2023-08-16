namespace eAutobus.Database
{
    public class Stanica
    {
        public int StanicaID { get; set; }
        public string NazivLokacijeStanice { get; set; }
        public int GradID { get; set; }
        public Grad Grad { get; set; }
        public bool IsDeleted { get; set; }
        
        public virtual ICollection<Cjenovnik> Polazistes { get; set; }
        public virtual ICollection<Cjenovnik> Odredistes { get; set; }

        public virtual ICollection<Karta> KartaP { get; set; }
        public virtual ICollection<Karta> KartaO { get; set; }
        public virtual ICollection<RasporedVoznje> RasporedVoznjeP { get; set; }
        public virtual ICollection<RasporedVoznje> RasporedVoznjeO { get; set; }

    }
}
