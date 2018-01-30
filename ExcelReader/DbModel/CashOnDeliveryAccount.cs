namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CashOnDeliveryAccount")]
    public partial class CashOnDeliveryAccount
    {
        public int CashOnDeliveryAccountId { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int CreditDebitType { get; set; }

        public int WalletId { get; set; }

        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Wallet Wallet { get; set; }
    }
}
