namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manifest")]
    public partial class Manifest
    {
        public int ManifestId { get; set; }

        [StringLength(100)]
        public string ManifestCode { get; set; }

        public DateTime DateTime { get; set; }

        public int? ShipmentId { get; set; }

        public string DispatchedById { get; set; }

        public string ReceiverById { get; set; }

        public int? FleetTripId { get; set; }

        public bool IsDispatched { get; set; }

        public bool IsReceived { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual FleetTrip FleetTrip { get; set; }

        public virtual Shipment Shipment { get; set; }
    }
}
