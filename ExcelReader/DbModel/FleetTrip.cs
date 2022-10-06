using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.DbModel
{
    [Table("FleetTrip")]
    public partial class FleetTrip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FleetTrip()
        {
        }

        public int FleetTripId { get; set; }

        public string DepartureDestination { get; set; }

        public string ActualDestination { get; set; }

        public string ExpectedDestination { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public decimal DistanceTravelled { get; set; }

        public decimal FuelCosts { get; set; }

        public decimal FuelUsed { get; set; }

        public int FleetId { get; set; }

        public int CaptainId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [StringLength(128)]
        public string Captain_Id { get; set; }

        public virtual Fleet Fleet { get; set; }
               
    }
}
