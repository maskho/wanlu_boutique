using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StockQty { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}