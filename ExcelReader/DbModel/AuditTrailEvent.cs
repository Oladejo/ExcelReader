namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AuditTrailEvent")]
    public partial class AuditTrailEvent
    {
        [Key]
        public int EventId { get; set; }

        public DateTime? InsertedDate { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public string Data { get; set; }
    }
}
