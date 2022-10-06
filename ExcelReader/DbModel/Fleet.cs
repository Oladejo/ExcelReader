using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.DbModel
{
    [Table("Fleet")]
    public partial class Fleet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fleet()
        {
            FleetTrip = new HashSet<FleetTrip>();
        }

        public int FleetId { get; set; }

        public string RegistrationNumber { get; set; }

        public string ChassisNumber { get; set; }

        public string EngineNumber { get; set; }

        public bool Status { get; set; }

        public int FleetType { get; set; }

        public int Capacity { get; set; }

        public string Description { get; set; }

        public int ModelId { get; set; }

        public int PartnerId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int? FleetMake_MakeId { get; set; }

        public virtual FleetMake FleetMake { get; set; }

        public virtual FleetModel FleetModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FleetTrip> FleetTrip { get; set; }

    }
}
