namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserServiceCentreMapping")]
    public partial class UserServiceCentreMapping
    {
        public int UserServiceCentreMappingId { get; set; }

        public bool IsActive { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public int ServiceCentreId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual ServiceCentre ServiceCentre { get; set; }
    }
}
