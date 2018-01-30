namespace ExcelReader.DbModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GIGLSDbContext : DbContext
    {
        public GIGLSDbContext()
            : base("name=GIGLSDbContext")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AccountSummary> AccountSummary { get; set; }
        public virtual DbSet<AccountTransaction> AccountTransaction { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AuditTrailEvent> AuditTrailEvent { get; set; }
        public virtual DbSet<CashOnDeliveryAccount> CashOnDeliveryAccount { get; set; }
        public virtual DbSet<CashOnDeliveryBalance> CashOnDeliveryBalance { get; set; }
        public virtual DbSet<ClientNode> ClientNode { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyContactPerson> CompanyContactPerson { get; set; }
        public virtual DbSet<DeliveryOption> DeliveryOption { get; set; }
        public virtual DbSet<DeliveryOptionPrice> DeliveryOptionPrice { get; set; }
        public virtual DbSet<Dispatch> Dispatch { get; set; }
        public virtual DbSet<DispatchActivity> DispatchActivity { get; set; }
        public virtual DbSet<DomesticRouteZoneMap> DomesticRouteZoneMap { get; set; }
        public virtual DbSet<DomesticZonePrice> DomesticZonePrice { get; set; }
        public virtual DbSet<EmailSendLog> EmailSendLog { get; set; }
        public virtual DbSet<Fleet> Fleet { get; set; }
        public virtual DbSet<FleetMake> FleetMake { get; set; }
        public virtual DbSet<FleetModel> FleetModel { get; set; }
        public virtual DbSet<FleetPart> FleetPart { get; set; }
        public virtual DbSet<FleetPartInventory> FleetPartInventory { get; set; }
        public virtual DbSet<FleetPartInventoryHistory> FleetPartInventoryHistory { get; set; }
        public virtual DbSet<FleetTrip> FleetTrip { get; set; }
        public virtual DbSet<GeneralLedger> GeneralLedger { get; set; }
        public virtual DbSet<GroupWaybillNumber> GroupWaybillNumber { get; set; }
        public virtual DbSet<GroupWaybillNumberMapping> GroupWaybillNumberMapping { get; set; }
        public virtual DbSet<Haulage> Haulage { get; set; }
        public virtual DbSet<HaulageDistanceMapping> HaulageDistanceMapping { get; set; }
        public virtual DbSet<HaulageDistanceMappingPrice> HaulageDistanceMappingPrice { get; set; }
        public virtual DbSet<IdentificationType> IdentificationType { get; set; }
        public virtual DbSet<IndividualCustomer> IndividualCustomer { get; set; }
        public virtual DbSet<Insurance> Insurance { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceShipment> InvoiceShipment { get; set; }
        public virtual DbSet<JobCard> JobCard { get; set; }
        public virtual DbSet<JobCardManagement> JobCardManagement { get; set; }
        public virtual DbSet<JobCardManagementPart> JobCardManagementPart { get; set; }
        public virtual DbSet<LogEntry> LogEntry { get; set; }
        public virtual DbSet<MainNav> MainNav { get; set; }
        public virtual DbSet<Manifest> Manifest { get; set; }
        public virtual DbSet<ManifestGroupWaybillNumberMapping> ManifestGroupWaybillNumberMapping { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<NumberGeneratorMonitor> NumberGeneratorMonitor { get; set; }
        public virtual DbSet<PackingList> PackingList { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<PartnerApplication> PartnerApplication { get; set; }
        public virtual DbSet<PaymentTransaction> PaymentTransaction { get; set; }
        public virtual DbSet<ServiceCentre> ServiceCentre { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<ShipmentCollection> ShipmentCollection { get; set; }
        public virtual DbSet<ShipmentItem> ShipmentItem { get; set; }
        public virtual DbSet<ShipmentReturn> ShipmentReturn { get; set; }
        public virtual DbSet<ShipmentTracking> ShipmentTracking { get; set; }
        public virtual DbSet<SmsSendLog> SmsSendLog { get; set; }
        public virtual DbSet<SpecialDomesticPackage> SpecialDomesticPackage { get; set; }
        public virtual DbSet<SpecialDomesticZonePrice> SpecialDomesticZonePrice { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<StockRequest> StockRequest { get; set; }
        public virtual DbSet<StockRequestPart> StockRequestPart { get; set; }
        public virtual DbSet<StockSupplyDetails> StockSupplyDetails { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<SubNav> SubNav { get; set; }
        public virtual DbSet<SubSubNav> SubSubNav { get; set; }
        public virtual DbSet<UserServiceCentreMapping> UserServiceCentreMapping { get; set; }
        public virtual DbSet<VAT> VAT { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Wallet> Wallet { get; set; }
        public virtual DbSet<WalletNumber> WalletNumber { get; set; }
        public virtual DbSet<WalletTransaction> WalletTransaction { get; set; }
        public virtual DbSet<WaybillNumber> WaybillNumber { get; set; }
        public virtual DbSet<WeightLimit> WeightLimit { get; set; }
        public virtual DbSet<WeightLimitPrice> WeightLimitPrice { get; set; }
        public virtual DbSet<Workshop> Workshop { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountSummary>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<AccountTransaction>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.FleetPartInventoryHistory)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.MovedBy_Id);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.FleetTrip)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.Captain_Id);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.JobCard)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.Approver_Id);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.JobCard1)
                .WithOptional(e => e.AspNetUsers1)
                .HasForeignKey(e => e.Requester_Id);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.JobCardManagement)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.MechanicSupervisor_Id);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.JobCardManagement1)
                .WithOptional(e => e.AspNetUsers1)
                .HasForeignKey(e => e.MechanicUser_Id);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.PartnerApplication)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.Approver_Id);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.ShipmentTracking)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.UserServiceCentreMapping)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Workshop)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.WorkshopSupervisor_Id);

            modelBuilder.Entity<CashOnDeliveryAccount>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<CashOnDeliveryBalance>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ClientNode>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Company>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<CompanyContactPerson>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<DeliveryOption>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<DeliveryOptionPrice>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Dispatch>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<DispatchActivity>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<DomesticRouteZoneMap>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<DomesticZonePrice>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<EmailSendLog>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Fleet>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Fleet>()
                .HasMany(e => e.JobCard)
                .WithOptional(e => e.Fleet)
                .HasForeignKey(e => e.Fleet_FleetId);

            modelBuilder.Entity<Fleet>()
                .HasMany(e => e.StockRequest)
                .WithOptional(e => e.Fleet)
                .HasForeignKey(e => e.ConveyingFleet_FleetId);

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

            modelBuilder.Entity<GeneralLedger>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<GroupWaybillNumber>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<GroupWaybillNumberMapping>()
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

            modelBuilder.Entity<IndividualCustomer>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<IndividualCustomer>()
                .HasMany(e => e.Shipment)
                .WithOptional(e => e.IndividualCustomer)
                .HasForeignKey(e => e.IndividualCustomer_IndividualCustomerId);

            modelBuilder.Entity<Insurance>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Invoice>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<InvoiceShipment>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<JobCard>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<JobCardManagement>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<JobCardManagementPart>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<MainNav>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Manifest>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ManifestGroupWaybillNumberMapping>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Message>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<NumberGeneratorMonitor>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<PackingList>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Partner>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<PartnerApplication>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<PaymentTransaction>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ServiceCentre>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ServiceCentre>()
                .HasMany(e => e.GroupWaybillNumberMapping)
                .WithOptional(e => e.ServiceCentre)
                .HasForeignKey(e => e.DepartureServiceCentre_ServiceCentreId);

            modelBuilder.Entity<ServiceCentre>()
                .HasMany(e => e.GroupWaybillNumberMapping1)
                .WithOptional(e => e.ServiceCentre1)
                .HasForeignKey(e => e.DestinationServiceCentre_ServiceCentreId);

            modelBuilder.Entity<ServiceCentre>()
                .HasMany(e => e.Shipment)
                .WithOptional(e => e.ServiceCentre)
                .HasForeignKey(e => e.DepartureServiceCentre_ServiceCentreId);

            modelBuilder.Entity<ServiceCentre>()
                .HasMany(e => e.Shipment1)
                .WithOptional(e => e.ServiceCentre1)
                .HasForeignKey(e => e.DestinationServiceCentre_ServiceCentreId);

            modelBuilder.Entity<ServiceCentre>()
                .HasMany(e => e.StockRequest)
                .WithOptional(e => e.ServiceCentre)
                .HasForeignKey(e => e.Destination_ServiceCentreId);

            modelBuilder.Entity<Shipment>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ShipmentCollection>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ShipmentItem>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ShipmentReturn>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<ShipmentTracking>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<SmsSendLog>()
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
                .HasMany(e => e.Dispatch)
                .WithOptional(e => e.Station)
                .HasForeignKey(e => e.DepartureId);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Dispatch1)
                .WithOptional(e => e.Station1)
                .HasForeignKey(e => e.DestinationId);

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

            modelBuilder.Entity<StockRequest>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<StockRequestPart>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<StockSupplyDetails>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Store>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<SubNav>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<SubSubNav>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<UserServiceCentreMapping>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<VAT>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Vendor>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Wallet>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<WalletNumber>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<WalletTransaction>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<WaybillNumber>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<WeightLimit>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<WeightLimitPrice>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Workshop>()
                .Property(e => e.RowVersion)
                .IsFixedLength();

            modelBuilder.Entity<Zone>()
                .Property(e => e.RowVersion)
                .IsFixedLength();
        }
    }
}
