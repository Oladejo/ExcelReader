using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.DbModel
{
    [Table("CompanyContactPerson")]
    public partial class CompanyContactPerson
    {
        public int CompanyContactPersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Designation { get; set; }

        public string PhoneNumber { get; set; }

        public int CompanyId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Company Company { get; set; }
    }
}
