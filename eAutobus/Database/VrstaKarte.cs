namespace eAutobus.Database
{
    public class VrstaKarte
    {
        public int VrstaKarteID { get; set; }
        public string Naziv { get; set; }
        public string Informacije { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
