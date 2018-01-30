namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupWaybillNumberMapping")]
    public partial class GroupWaybillNumberMapping
    {
        public int GroupWaybillNumberMappingId { get; set; }

        public DateTime DateMapped { get; set; }

        public bool IsActive { get; set; }

        public string GroupWaybillNumber { get; set; }

        public string WaybillNumber { get; set; }

        public int DepartureServiceCentreId { get; set; }

        public int DestinationServiceCentreId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int? DepartureServiceCentre_ServiceCentreId { get; set; }

        public int? DestinationServiceCentre_ServiceCentreId { get; set; }

        public virtual ServiceCentre ServiceCentre { get; set; }

        public virtual ServiceCentre ServiceCentre1 { get; set; }
    }
}
