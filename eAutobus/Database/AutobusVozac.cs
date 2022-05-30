namespace eAutobus.Database
{
    public class AutobusVozac
    {
        public int AutobusVozacID { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
        public int Smjena { get; set; }
        public int AutobusID { get; set; }
        public Autobus Autobus { get; set; }

        public int VozacID { get; set; }
        public Vozac Vozac { get; set; }
        public bool IsDeleted { get; set; }
    }
}
