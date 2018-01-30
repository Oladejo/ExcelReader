namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubSubNav")]
    public partial class SubSubNav
    {
        public int SubSubNavId { get; set; }

        public string Title { get; set; }

        public string State { get; set; }

        public string Param { get; set; }

        public int SubNavId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual SubNav SubNav { get; set; }
    }
}
