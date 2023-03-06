
namespace API.DTOs
{
    public class TransactionDto
    {
        public DateTime CreatedAt { get; set; }
        public List<int> ProductIds { get; set; }
        public int CustomerId { get; set; }
        public int ShopBranchId { get; set; }
    }
}