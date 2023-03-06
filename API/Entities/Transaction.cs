using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Transactions")]
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Product> Products { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ShopBranchId { get; set; }
        public ShopBranch ShopBranch { get; set; }
    }
}