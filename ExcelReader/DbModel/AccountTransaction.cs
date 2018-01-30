namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountTransaction")]
    public partial class AccountTransaction
    {
        public int AccountTransactionId { get; set; }

        public double Amount { get; set; }

        public DateTime DateOfTransaction { get; set; }

        public string Narration { get; set; }

        public string TransactionReference { get; set; }

        public int AccountType { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
