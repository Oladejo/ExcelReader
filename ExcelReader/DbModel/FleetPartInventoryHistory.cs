namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FleetPartInventoryHistory")]
    public partial class FleetPartInventoryHistory
    {
        public int FleetPartInventoryHistoryId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string Remark { get; set; }

        public int InventoryType { get; set; }

        public decimal InitialBalance { get; set; }

        public decimal CurrentBalance { get; set; }

        public int PartId { get; set; }

        public int StoreId { get; set; }

        public int VendorId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [StringLength(128)]
        public string MovedBy_Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual FleetPart FleetPart { get; set; }

        public virtual Store Store { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
