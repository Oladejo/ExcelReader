using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.DbModel
{
    [Table("Zone")]
    public partial class Zone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zone()
        {
            DomesticRouteZoneMap = new HashSet<DomesticRouteZoneMap>();
            DomesticZonePrice = new HashSet<DomesticZonePrice>();
            SpecialDomesticZonePrice = new HashSet<SpecialDomesticZonePrice>();
        }

        public int ZoneId { get; set; }

        public string ZoneName { get; set; }

        public bool Status { get; set; }

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
        public virtual ICollection<DomesticZonePrice> DomesticZonePrice { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpecialDomesticZonePrice> SpecialDomesticZonePrice { get; set; }

    }
}
