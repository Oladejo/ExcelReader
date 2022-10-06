using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.DbModel
{
    [Table("FleetPartInventory")]
    public partial class FleetPartInventory
    {
        public int FleetPartInventoryId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public int PartId { get; set; }

        public int StoreId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual FleetPart FleetPart { get; set; }

    }
}
