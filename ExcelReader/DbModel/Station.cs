using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.DbModel
{
    [Table("Station")]
    public partial class Station
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Station()
        {
            DomesticRouteZoneMap = new HashSet<DomesticRouteZoneMap>();
            DomesticRouteZoneMap1 = new HashSet<DomesticRouteZoneMap>();
            HaulageDistanceMapping = new HashSet<HaulageDistanceMapping>();
            HaulageDistanceMapping1 = new HashSet<HaulageDistanceMapping>();
            ServiceCentre = new HashSet<ServiceCentre>();
        }

        public int StationId { get; set; }

        public string StationName { get; set; }

        public string StationCode { get; set; }

        public int StateId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DomesticRouteZoneMap> DomesticRouteZoneMap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DomesticRouteZoneMap> DomesticRouteZoneMap1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HaulageDistanceMapping> HaulageDistanceMapping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HaulageDistanceMapping> HaulageDistanceMapping1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceCentre> ServiceCentre { get; set; }

        public virtual State State { get; set; }
    }
}
