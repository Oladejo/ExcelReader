namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Wallet")]
    public partial class Wallet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wallet()
        {
            CashOnDeliveryAccount = new HashSet<CashOnDeliveryAccount>();
            CashOnDeliveryBalance = new HashSet<CashOnDeliveryBalance>();
            WalletTransaction = new HashSet<WalletTransaction>();
        }

        public int WalletId { get; set; }

        public string WalletNumber { get; set; }

        public decimal Balance { get; set; }

        public int CustomerId { get; set; }

        public int CustomerType { get; set; }

        public bool IsSystem { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CashOnDeliveryAccount> CashOnDeliveryAccount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CashOnDeliveryBalance> CashOnDeliveryBalance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WalletTransaction> WalletTransaction { get; set; }
    }
}
