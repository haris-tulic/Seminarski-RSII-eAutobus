namespace eAutobus.Database
{
    public class TipKarte
    {
        public int TipKarteID { get; set; }
        public string Naziv { get; set; }
        public string Informacije { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
