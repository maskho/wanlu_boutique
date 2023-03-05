using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Transactions")]
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Product> Products { get; set; } = new();

        public int ShopBranchId { get; set; }
        public ShopBranch ShopBranch { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}