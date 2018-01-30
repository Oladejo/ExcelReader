namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DeliveryOptionPrice")]
    public partial class DeliveryOptionPrice
    {
        public int DeliveryOptionPriceId { get; set; }

        public int ZoneId { get; set; }

        public int DeliveryOptionId { get; set; }

        public decimal Price { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual DeliveryOption DeliveryOption { get; set; }

        public virtual Zone Zone { get; set; }
    }
}
