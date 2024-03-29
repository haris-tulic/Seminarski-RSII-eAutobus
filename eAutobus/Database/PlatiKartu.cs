﻿namespace eAutobus.Database
{
    public class PlatiKartu
    {
        public int PlatiKartuID { get; set; }
        public int KartaID { get; set; }
        public int KupacID { get; set; }
        public double Cijena { get; set; }
        public Karta Karta { get; set; }
        public Kupac Kupac { get; set; }
        public bool JeLiPlacena { get; set; }
        public DateTime DatumVadjenjaKarte { get; set; }
        public DateTime DatumVazenjaKarte { get; set; }
    }
}
