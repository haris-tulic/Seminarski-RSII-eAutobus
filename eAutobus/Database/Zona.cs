namespace eAutobus.Database
{
    public class Zona
    {
        public int ZonaID { get; set; }
        public string OznakaZone { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
