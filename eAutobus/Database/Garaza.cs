namespace eAutobus.Database
{
    public class Garaza
    {
        public int GarazaID { get; set; }
        public string NazivGaraze { get; set; }
        public int BrojGaraze { get; set; }
        public int BrojMjesta { get; set; }
        public int TrenutnoAutobusa { get; set; }
        public bool IsPopunjeno { get; set; }
        public int GradID { get; set; }
        public Grad Grad { get; set; }
        public List<Autobus> Autobusi { get; set; }
        public bool IsDeleted { get; set; }
    }
}
