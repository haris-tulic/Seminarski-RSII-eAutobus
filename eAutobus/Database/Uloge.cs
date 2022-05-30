namespace eAutobus.Database
{
    public class Uloge
    {
        public int UlogeID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public List<Korisnik> Korisnik { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
