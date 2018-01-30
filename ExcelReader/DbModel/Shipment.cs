namespace ExcelReader.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shipment")]
    public partial class Shipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shipment()
        {
            Manifest = new HashSet<Manifest>();
            ShipmentItem = new HashSet<ShipmentItem>();
        }

        public int ShipmentId { get; set; }

        public string SealNumber { get; set; }

        [StringLength(100)]
        public string Waybill { get; set; }

        public decimal Value { get; set; }

        public DateTime? DeliveryTime { get; set; }

        public int PaymentStatus { get; set; }

        public string CustomerType { get; set; }

        public int CustomerId { get; set; }

        public int DepartureServiceCentreId { get; set; }

        public int DestinationServiceCentreId { get; set; }

        public string ReceiverName { get; set; }

        public string ReceiverPhoneNumber { get; set; }

        public string ReceiverEmail { get; set; }

        public string ReceiverAddress { get; set; }

        public string ReceiverCity { get; set; }

        public string ReceiverState { get; set; }

        public string ReceiverCountry { get; set; }

        public int DeliveryOptionId { get; set; }

        public int PickupOptions { get; set; }

        public DateTime? ExpectedDateOfArrival { get; set; }

        public DateTime? ActualDateOfArrival { get; set; }

        public decimal GrandTotal { get; set; }

        public bool IsCashOnDelivery { get; set; }

        public decimal? CashOnDeliveryAmount { get; set; }

        public decimal? ExpectedAmountToCollect { get; set; }

        public decimal? ActualAmountCollected { get; set; }

        public string UserId { get; set; }

        public bool IsdeclaredVal { get; set; }

        public decimal? DeclarationOfValueCheck { get; set; }

        public decimal? AppliedDiscount { get; set; }

        public decimal? DiscountValue { get; set; }

        public decimal? Insurance { get; set; }

        public decimal? Vat { get; set; }

        public decimal? Total { get; set; }

        public decimal? vatvalue_display { get; set; }

        public decimal? InvoiceDiscountValue_display { get; set; }

        public decimal? offInvoiceDiscountvalue_display { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int? DepartureServiceCentre_ServiceCentreId { get; set; }

        public int? DestinationServiceCentre_ServiceCentreId { get; set; }

        public int? IndividualCustomer_IndividualCustomerId { get; set; }

        public virtual DeliveryOption DeliveryOption { get; set; }

        public virtual IndividualCustomer IndividualCustomer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manifest> Manifest { get; set; }

        public virtual ServiceCentre ServiceCentre { get; set; }

        public virtual ServiceCentre ServiceCentre1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShipmentItem> ShipmentItem { get; set; }
    }
}
