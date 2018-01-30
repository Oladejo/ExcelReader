namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShipmentTracking")]
    public partial class ShipmentTracking
    {
        public int ShipmentTrackingId { get; set; }

        public string Waybill { get; set; }

        public string Location { get; set; }

        public string Status { get; set; }

        public DateTime DateTime { get; set; }

        public int TrackingType { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
