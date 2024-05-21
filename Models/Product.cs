namespace TestApiDOTNetCore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Initialize with default value
        public string Description { get; set; } = string.Empty; // Initialize with default value
        public int Price { get; set; }
        public string Category { get; set; } = string.Empty; // Initialize with default value
        public string? Subcategory { get; set; } // Nullable property
    }
}
