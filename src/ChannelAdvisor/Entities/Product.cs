using System;

namespace Aarvani.ChannelAdvisor.Entities
{
    public sealed class Product
    {
        public int ChannelProductID { get; set; }
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public DateTime UpdateDateUtc { get; set; }
        public DateTime QuantityUpdateDateUtc { get; set; }
        public bool IsAvailableInStore { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsExternalQuantityBlocked { get; set;}
        public string BlockComment { get; set; }
        public string ReceivedDateUtc { get; set; }
        public string LastSaleDateUtc { get; set; }
        public string ASIN { get; set; }
        public string Brand { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string EAN { get; set; }
        public string FlagDescription { get; set; }
        public string Flag { get; set; }
        public string HarmonizedCode { get; set; }
        public string ISBN { get; set; }
        public string Manufacturer { get; set; }
        public string MPN { get; set; }
        public string ShortDescription { get; set; }
        public string Sku { get; set; }
        public string Subtitle { get; set; }
        public string TaxProductCode { get; set; }
        public string Title { get; set; }
        public string UPC { get; set; }
        public string WarehouseLocation { get; set; }
        public string Warranty { get; set; }
        public string Height { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Margin { get; set; }
        public decimal? RetailPrice { get; set; }
        public decimal? StartingPrice { get; set; }
        public decimal? ReservePrice { get; set; }
        public decimal? BuyItNowPrice { get; set; }
        public decimal? StorePrice { get; set; }
        public decimal? SecondChancePrice { get; set; }
        public string SupplierName { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierPO { get; set; }
        public string Classification { get; set; }
        public string IsDisplayInStore { get; set; }
        public string StoreTitle { get; set; }
        public string StoreDescription { get; set; }
        public string BundleType { get; set; }
        public int TotalAvailableQuantity { get; set; }
        public int OpenAllocatedQuantity { get; set; }
        public int OpenAllocatedQuantityPooled { get; set; }
        public int PendingCheckoutQuantity { get; set; }
        public int PendingCheckoutQuantityPooled { get; set; }
        public int PendingPaymentQuantity { get; set; }
        public int PendingPaymentQuantityPooled { get; set; }
        public int PendingShipmentQuantity { get; set; }
        public int PendingShipmentQuantityPooled { get; set; }
        public int TotalQuantity { get; set; }
        public int TotalQuantityPooled { get; set; }
        public bool? IsParent { get; set; }
        public bool? IsInRelationship { get; set; }
        public int? ParentProductID { get; set; }
        public string RelationshipName { get; set; }
        
    }
}
