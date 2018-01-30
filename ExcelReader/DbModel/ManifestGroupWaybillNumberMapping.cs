namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ManifestGroupWaybillNumberMapping")]
    public partial class ManifestGroupWaybillNumberMapping
    {
        public int ManifestGroupWaybillNumberMappingId { get; set; }

        public DateTime DateMapped { get; set; }

        public bool IsActive { get; set; }

        public string ManifestCode { get; set; }

        public string GroupWaybillNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
