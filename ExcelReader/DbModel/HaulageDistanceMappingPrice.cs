using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.DbModel
{
    [Table("HaulageDistanceMappingPrice")]
    public partial class HaulageDistanceMappingPrice
    {
        public int HaulageDistanceMappingPriceId { get; set; }

        public int StartRange { get; set; }

        public int EndRange { get; set; }

        public int HaulageId { get; set; }

        public decimal Price { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Haulage Haulage { get; set; }
    }
}
