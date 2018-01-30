namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobCardManagementPart")]
    public partial class JobCardManagementPart
    {
        public int JobCardManagementPartId { get; set; }

        public int Quantity { get; set; }

        public int PartId { get; set; }

        public int JobCardManagementId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual FleetPart FleetPart { get; set; }

        public virtual JobCardManagement JobCardManagement { get; set; }
    }
}
