namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NumberGeneratorMonitor")]
    public partial class NumberGeneratorMonitor
    {
        public int NumberGeneratorMonitorId { get; set; }

        public string ServiceCentreCode { get; set; }

        public int NumberGeneratorType { get; set; }

        public string Number { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
