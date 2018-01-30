namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IndividualCustomer")]
    public partial class IndividualCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IndividualCustomer()
        {
            Shipment = new HashSet<Shipment>();
        }

        public int IndividualCustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Gender { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string PictureUrl { get; set; }

        public string CustomerCode { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shipment> Shipment { get; set; }
    }
}
