namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShipmentItem")]
    public partial class ShipmentItem
    {
        public int ShipmentItemId { get; set; }

        public string Description { get; set; }

        public int ShipmentType { get; set; }

        public double Weight { get; set; }

        public string Nature { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SerialNumber { get; set; }

        public int ShipmentId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Shipment Shipment { get; set; }
    }
}
