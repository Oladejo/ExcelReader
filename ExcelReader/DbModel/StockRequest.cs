namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockRequest")]
    public partial class StockRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockRequest()
        {
            StockRequestPart = new HashSet<StockRequestPart>();
            StockSupplyDetails = new HashSet<StockSupplyDetails>();
        }

        public int StockRequestId { get; set; }

        public bool IsSupplied { get; set; }

        public int SourceId { get; set; }

        public int StockRequestSourceType { get; set; }

        public int StockRequestStatus { get; set; }

        public string Remark { get; set; }

        public string VendorAddress { get; set; }

        public int StockRequestDestinationType { get; set; }

        public DateTime DateIssued { get; set; }

        public DateTime DateReceived { get; set; }

        public int ConveyingFleetId { get; set; }

        public string Receiver { get; set; }

        public string Requester { get; set; }

        public string Issuer { get; set; }

        public string StockInApprover { get; set; }

        public string StockOutApprover { get; set; }

        public int DestinationId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int? ConveyingFleet_FleetId { get; set; }

        public int? Destination_ServiceCentreId { get; set; }

        public virtual Fleet Fleet { get; set; }

        public virtual ServiceCentre ServiceCentre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockRequestPart> StockRequestPart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockSupplyDetails> StockSupplyDetails { get; set; }
    }
}
