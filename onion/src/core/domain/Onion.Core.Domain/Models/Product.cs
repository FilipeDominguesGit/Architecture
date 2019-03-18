namespace Onion.Core.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public string Code => $"{Category[0]}-{Brand[0]}-{Name[0]}";
    }
}
