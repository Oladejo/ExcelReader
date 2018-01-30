namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobCardManagement")]
    public partial class JobCardManagement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobCardManagement()
        {
            JobCardManagementPart = new HashSet<JobCardManagementPart>();
        }

        public int JobCardManagementId { get; set; }

        public string SupervisorComment { get; set; }

        public string MechanicComment { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime EstimatedCompletionDate { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime DateCompleted { get; set; }

        public int JobCardMaintenanceStatus { get; set; }

        public int WorkshopId { get; set; }

        public int JobCardId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [StringLength(128)]
        public string MechanicSupervisor_Id { get; set; }

        [StringLength(128)]
        public string MechanicUser_Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual AspNetUsers AspNetUsers1 { get; set; }

        public virtual JobCard JobCard { get; set; }

        public virtual Workshop Workshop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobCardManagementPart> JobCardManagementPart { get; set; }
    }
}
