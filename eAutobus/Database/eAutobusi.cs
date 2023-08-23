using Microsoft.EntityFrameworkCore;

namespace eAutobus.Database
{
    public partial class eAutobusi : DbContext
    {
        public eAutobusi()
        {
        }
        public eAutobusi(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Autobus> Autobus { get; set; }
        public virtual DbSet<AutobusVozac> AutobusVozac { get; set; }
        public virtual DbSet<Cjenovnik> Cjenovnik { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Karta> Karta { get; set; }
        public virtual DbSet<Kupac> Kupac { get; set; }
        public virtual DbSet<RasporedVoznje> RasporedVoznje { get; set; }
        public virtual DbSet<Recenzija> Recenzija { get; set; }
        public virtual DbSet<Stanica> Stanica { get; set; }
        public virtual DbSet<TipKarte> TipKarte { get; set; }
        public virtual DbSet<Vozac> Vozac { get; set; }
        public virtual DbSet<VrstaKarte> VrstaKarte { get; set; }
        public virtual DbSet<Zona> Zona { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<Garaza> Garaza { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<KartaKupac> KartaKupac { get; set; }
        public virtual DbSet<PlatiKartu> PlatiKartu { get; set; }




        protected override void OnModelCreating(ModelBuilder bilder)
        {
            bilder.Entity<Cjenovnik>()
                  .HasOne(p => p.Polaziste)
                  .WithMany(c => c.Polazistes)
                  .HasForeignKey(p => p.PolazisteID)
                  .OnDelete(DeleteBehavior.NoAction);

            bilder.Entity<Cjenovnik>()
                  .HasOne(o => o.Odrediste)
                  .WithMany(s => s.Odredistes)
                  .HasForeignKey(o => o.OdredisteID)
                  .OnDelete(DeleteBehavior.NoAction);

            bilder.Entity<Karta>()
                    .HasOne(p => p.Polaziste)
                    .WithMany(k => k.KartaP)
                    .HasForeignKey(p => p.PolazisteID)
                    .OnDelete(DeleteBehavior.NoAction);

            bilder.Entity<Karta>()
                  .HasOne(p => p.Odrediste)
                  .WithMany(k => k.KartaO)
                  .HasForeignKey(p => p.OdredisteID)
                  .OnDelete(DeleteBehavior.NoAction);

            bilder.Entity<RasporedVoznje>()
                    .HasOne(p => p.Polaziste)
                    .WithMany(k => k.RasporedVoznjeP)
                    .HasForeignKey(p => p.PolazisteID)
                    .OnDelete(DeleteBehavior.NoAction);

            bilder.Entity<RasporedVoznje>()
               .HasOne(p => p.Odrediste)
               .WithMany(k => k.RasporedVoznjeO)
               .HasForeignKey(p => p.OdredisteID)
               .OnDelete(DeleteBehavior.NoAction);

            bilder.Entity<Vozac>().HasMany(v => v.Autobuss).WithMany(v => v.Vozacs).UsingEntity<AutobusVozac>();
            bilder.Entity<AutobusVozac>().HasOne(a=>a.Vozac).WithMany(v=>v.Autobusi).HasForeignKey(a=>a.VozacID).OnDelete(DeleteBehavior.NoAction);

            bilder.Entity<RasporedVoznje>().HasOne(r => r.Kondukter).WithMany(v => v.RKondukters).HasForeignKey(r => r.KondukterID).OnDelete(DeleteBehavior.NoAction);
            bilder.Entity<RasporedVoznje>().HasOne(r => r.Vozac).WithMany(v => v.RVozacs).HasForeignKey(r => r.VozacID).OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(bilder);
            OnModelCreatingPartial(bilder);
        }
         partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
