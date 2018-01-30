namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartnerApplication")]
    public partial class PartnerApplication
    {
        public int PartnerApplicationId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string CompanyRcNumber { get; set; }

        public string IdentificationNumber { get; set; }

        public int PartnerType { get; set; }

        public string TellAboutYou { get; set; }

        public bool IsRegistered { get; set; }

        public int PartnerApplicationStatus { get; set; }

        public int? IdentificationTypeId { get; set; }

        public int? ApproverId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [StringLength(128)]
        public string Approver_Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual IdentificationType IdentificationType { get; set; }
    }
}
