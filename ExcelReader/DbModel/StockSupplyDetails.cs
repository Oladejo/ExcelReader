namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StockSupplyDetails
    {
        public int StockSupplyDetailsId { get; set; }

        public string InvoiceNumber { get; set; }

        public string LPONumber { get; set; }

        public string WaybillNumber { get; set; }

        public string ScannedInvoiceURL { get; set; }

        public int StockRequestId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual StockRequest StockRequest { get; set; }
    }
}
