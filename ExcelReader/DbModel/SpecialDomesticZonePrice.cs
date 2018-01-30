namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpecialDomesticZonePrice")]
    public partial class SpecialDomesticZonePrice
    {
        public int SpecialDomesticZonePriceId { get; set; }

        public decimal? Weight { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int ZoneId { get; set; }

        public int SpecialDomesticPackageId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual SpecialDomesticPackage SpecialDomesticPackage { get; set; }

        public virtual Zone Zone { get; set; }
    }
}
