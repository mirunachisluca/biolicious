namespace Core.Entities
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
    }
}