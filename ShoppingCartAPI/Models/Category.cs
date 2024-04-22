namespace ShoppingCartAPI.Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }

        public ICollection<ProductCategory> Products { get; set; }
    }
}
