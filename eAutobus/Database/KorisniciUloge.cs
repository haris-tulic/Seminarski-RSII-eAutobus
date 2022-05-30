namespace eAutobus.Database
{
    public class KorisniciUloge
    {
        public int KorisniciUlogeID { get; set; }
        public int KorisnikID { get; set; }
        public int UlogaID { get; set; }
        public DateTime? DatumIzmjene { get; set; }
        public Korisnik Korisnik { get; set; }
        public virtual Uloge Uloga { get; set; }
    }
}
