namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dispatch")]
    public partial class Dispatch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dispatch()
        {
            DispatchActivity = new HashSet<DispatchActivity>();
        }

        public int DispatchId { get; set; }

        public string RegistrationNumber { get; set; }

        public string ManifestNumber { get; set; }

        public decimal Amount { get; set; }

        public int RescuedDispatchId { get; set; }

        public string DriverDetail { get; set; }

        public string DispatchedBy { get; set; }

        public string ReceivedBy { get; set; }

        public int DispatchCategory { get; set; }

        public int? ServiceCentreId { get; set; }

        public int? DepartureId { get; set; }

        public int? DestinationId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ServiceCentre ServiceCentre { get; set; }

        public virtual Station Station { get; set; }

        public virtual Station Station1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DispatchActivity> DispatchActivity { get; set; }
    }
}
