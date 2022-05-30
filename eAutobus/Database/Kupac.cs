namespace eAutobus.Database
{
    public class Kupac
    {
        public int KupacID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string AdresaStanovanja { get; set; }
        public string BrojTelefona { get; set; }
        public List<KartaKupac> KartaList { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public string Email { get; set; }
        public List<Recenzija> Recenzija { get; set; }
        public List<PlatiKartu> PlaceneKarte { get; set; }
        public bool IsDeleted { get; set; }
    }
}
