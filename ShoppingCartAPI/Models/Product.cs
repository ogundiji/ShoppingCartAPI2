namespace ShoppingCartAPI.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int productCode { get; set; }
        public decimal price { get; set; }
        public int? quantity { get; set; }
        public string description { get; set; }
        public ICollection<ProductCategory> Categories{ get; set; }
    }
}
