namespace eAutobus.Database
{
    public class Grad
    {
        public int GradID { get; set; }
        public string NazivGrada { get; set; }
        public int? PostanskiBroj { get; set; }
        public List<Garaza> Garaze { get; set; }
        public List<Korisnik> Korisnici { get; set; }
        public List<Stanica> Stanice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
