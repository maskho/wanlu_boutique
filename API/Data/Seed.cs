using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedCustomers(DataContext context)
        {
            if (await context.Customers.AnyAsync()) return;

            var customerData = await File.ReadAllTextAsync("Data/CustomersSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var customers = JsonSerializer.Deserialize<List<Customer>>(customerData);

            foreach (var customer in customers)
            {
                context.Customers.Add(customer);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedProducts(DataContext context
        )
        {
            if (await context.Products.AnyAsync()) return;

            var productData = await File.ReadAllTextAsync("Data/ProductsSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var products = JsonSerializer.Deserialize<List<Product>>(productData);

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedShopBranches(DataContext context
        )
        {
            if (await context.ShopBranches.AnyAsync()) return;

            var shopData = await File.ReadAllTextAsync("Data/ShopBranchesSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var shops = JsonSerializer.Deserialize<List<ShopBranch>>(shopData);

            foreach (var shop in shops)
            {
                context.ShopBranches.Add(shop);
            }

            await context.SaveChangesAsync();
        }
    }
}