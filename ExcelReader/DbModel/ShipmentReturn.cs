namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShipmentReturn")]
    public partial class ShipmentReturn
    {
        [Key]
        [StringLength(100)]
        public string WaybillNew { get; set; }

        [StringLength(100)]
        public string WaybillOld { get; set; }

        public decimal Discount { get; set; }

        public decimal OriginalPayment { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
