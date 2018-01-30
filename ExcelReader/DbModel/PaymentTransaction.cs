namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaymentTransaction")]
    public partial class PaymentTransaction
    {
        public int PaymentTransactionId { get; set; }

        public string Waybill { get; set; }

        public string TransactionCode { get; set; }

        public int PaymentStatus { get; set; }

        public int PaymentTypes { get; set; }

        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
