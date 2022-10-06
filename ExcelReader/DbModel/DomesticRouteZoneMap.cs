using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.DbModel
{
    [Table("DomesticRouteZoneMap")]
    public partial class DomesticRouteZoneMap
    {
        public int DomesticRouteZoneMapId { get; set; }

        public int ZoneId { get; set; }

        public int? DepartureId { get; set; }

        public int? DestinationId { get; set; }

        public bool Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Station Station { get; set; }

        public virtual Station Station1 { get; set; }

        public virtual Zone Zone { get; set; }
    }
}
