using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.DbModel
{
    [Table("WalletTransaction")]
    public partial class WalletTransaction
    {
        public int WalletTransactionId { get; set; }

        public DateTime DateOfEntry { get; set; }

        public int ServiceCentreId { get; set; }

        public int WalletId { get; set; }

        public string UserId { get; set; }

        public decimal Amount { get; set; }

        public int CreditDebitType { get; set; }

        public string Description { get; set; }

        public bool IsDeferred { get; set; }

        public string Waybill { get; set; }

        public string ClientNodeId { get; set; }

        public int PaymentType { get; set; }

        public string PaymentTypeReference { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ServiceCentre ServiceCentre { get; set; }

        public virtual Wallet Wallet { get; set; }
    }
}
