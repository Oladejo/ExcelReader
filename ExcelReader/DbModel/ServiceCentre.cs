using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.DbModel
{
    [Table("ServiceCentre")]
    public partial class ServiceCentre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceCentre()
        {
            UserServiceCentreMapping = new HashSet<UserServiceCentreMapping>();
        }

        public int ServiceCentreId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public int StationId { get; set; }

        public decimal TargetAmount { get; set; }

        public int TargetOrder { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }
                
        public virtual Station Station { get; set; }
       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserServiceCentreMapping> UserServiceCentreMapping { get; set; }

    }
}
