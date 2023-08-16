namespace eAutobus.Database
{
    public class Vozac
    {
        public int VozacID { get; set; }
        public string VozackaKategorija { get; set; }
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public List<Autobus> Autobuss { get; set; }
        public List<AutobusVozac> Autobusi { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
