namespace Core.DTOs
{
    public class RecipeIngredientDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductWeight { get; set; }
        public double ProductPrice { get; set; }
        public string PictureUrl { get; set; }
        public string ProductBrand { get; set; }
        public string ProductCategory { get; set; }
        public double Quantity { get; set; }
        public string Measure { get; set; }
    }
}
