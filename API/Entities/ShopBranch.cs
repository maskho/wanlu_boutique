using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("ShopBranches")]
    public class ShopBranch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Transaction> Transactions { get; set; } = new();
    }
}