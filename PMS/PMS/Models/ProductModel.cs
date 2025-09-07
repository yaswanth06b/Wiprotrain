namespace PMS.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public static class ProductStore
    {
        public static List<ProductModel> Products = new List<ProductModel>();
    }
}