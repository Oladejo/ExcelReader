namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobCard")]
    public partial class JobCard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobCard()
        {
            JobCardManagement = new HashSet<JobCardManagement>();
        }

        public int JobCardId { get; set; }

        public string JobDescription { get; set; }

        public int JobCardType { get; set; }

        public int JobCardStatus { get; set; }

        public int MaintenanceType { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [StringLength(128)]
        public string Approver_Id { get; set; }

        public int? Fleet_FleetId { get; set; }

        [StringLength(128)]
        public string Requester_Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual AspNetUsers AspNetUsers1 { get; set; }

        public virtual Fleet Fleet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobCardManagement> JobCardManagement { get; set; }
    }
}
