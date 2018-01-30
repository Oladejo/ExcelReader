namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupWaybillNumber")]
    public partial class GroupWaybillNumber
    {
        public int GroupWaybillNumberId { get; set; }

        [StringLength(100)]
        public string GroupWaybillCode { get; set; }

        public bool IsActive { get; set; }

        public string UserId { get; set; }

        public int ServiceCentreId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ServiceCentre ServiceCentre { get; set; }
    }
}
