namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeightLimitPrice")]
    public partial class WeightLimitPrice
    {
        public int WeightLimitPriceId { get; set; }

        public int ZoneId { get; set; }

        public decimal Price { get; set; }

        public decimal Weight { get; set; }

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
