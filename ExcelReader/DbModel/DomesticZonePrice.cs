namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DomesticZonePrice")]
    public partial class DomesticZonePrice
    {
        public int DomesticZonePriceId { get; set; }

        public decimal Weight { get; set; }

        public int ZoneId { get; set; }

        public decimal Price { get; set; }

        public int RegularEcommerceType { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Zone Zone { get; set; }
    }
}
