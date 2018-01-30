namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            CompanyContactPerson = new HashSet<CompanyContactPerson>();
        }

        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string RcNumber { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Industry { get; set; }

        public int CompanyType { get; set; }

        public int CompanyStatus { get; set; }

        public string CustomerCode { get; set; }

        public decimal Discount { get; set; }

        public int SettlementPeriod { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyContactPerson> CompanyContactPerson { get; set; }
    }
}
