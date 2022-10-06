namespace ExcelReader.DbModel
{
    using System.Data.Entity;

    public partial class TestingDBContext : DbContext
    {
        public TestingDBContext()
            : base("name=TestingDBContext")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyContactPerson> CompanyContactPerson { get; set; }
        public virtual DbSet<DomesticRouteZoneMap> DomesticRouteZoneMap { get; set; }
        public virtual DbSet<DomesticZonePrice> DomesticZonePrice { get; set; }
        public virtual DbSet<Fleet> Fleet { get; set; }
        public virtual DbSet<FleetMake> FleetMake { get; set; }
        public virtual DbSet<FleetModel> FleetModel { get; set; }
        public virtual DbSet<FleetPart> FleetPart { get; set; }
        public virtual DbSet<FleetPartInventory> FleetPartInventory { get; set; }
        public virtual DbSet<FleetPartInventoryHistory> FleetPartInventoryHistory { get; set; }
        public virtual DbSet<FleetTrip> FleetTrip { get; set; }
        public virtual DbSet<Haulage> Haulage { get; set; }
        public virtual DbSet<HaulageDistanceMapping> HaulageDistanceMapping { get; set; }
        public virtual DbSet<HaulageDistanceMappingPrice> HaulageDistanceMappingPrice { get; set; }
        public virtual DbSet<ServiceCentre> ServiceCentre { get; set; }
        public virtual DbSet<SpecialDomesticPackage> SpecialDomesticPackage { get; set; }
        public virtual DbSet<SpecialDomesticZonePrice> SpecialDomesticZonePrice { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<UserServiceCentreMapping> UserServiceCentreMapping { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }
        public virtual DbSet<Wallet> Wallet { get; set; }
        public virtual DbSet<WalletNumber> WalletNumber { get; set; }
        public virtual DbSet<WalletTransaction> WalletTransaction { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<CompanyContactPerson>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<DomesticRouteZoneMap>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<DomesticZonePrice>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Fleet>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<FleetMake>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<FleetMake>()
                .HasMany(e => e.Fleet)
                .WithOptional(e => e.FleetMake)
                .HasForeignKey(e => e.FleetMake_MakeId);

            modelBuilder.Entity<FleetModel>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<FleetPart>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<FleetPartInventory>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<FleetPartInventoryHistory>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<FleetTrip>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Haulage>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<HaulageDistanceMapping>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<HaulageDistanceMappingPrice>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ServiceCentre>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<SpecialDomesticPackage>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<SpecialDomesticZonePrice>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<State>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Station>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Station>()
                .HasMany(e => e.DomesticRouteZoneMap)
                .WithOptional(e => e.Station)
                .HasForeignKey(e => e.DepartureId);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.DomesticRouteZoneMap1)
                .WithOptional(e => e.Station1)
                .HasForeignKey(e => e.DestinationId);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.HaulageDistanceMapping)
                .WithOptional(e => e.Station)
                .HasForeignKey(e => e.DepartureId);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.HaulageDistanceMapping1)
                .WithOptional(e => e.Station1)
                .HasForeignKey(e => e.DestinationId);

            modelBuilder.Entity<UserServiceCentreMapping>()
                .Property(e => e.RowVersion)
                .IsFixedLength();              

            modelBuilder.Entity<Zone>()
                .Property(e => e.RowVersion)
                .IsFixedLength();
        }
    }
}
