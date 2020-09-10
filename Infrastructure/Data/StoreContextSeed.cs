using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;

namespace Infrastructure.Data
{
   public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    /// await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ProductBrands ON");
                   // using var transaction = context.Database.BeginTransaction();
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT ProductBrands ON");

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item); 
                    }
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands ON");
                    await context.SaveChangesAsync();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductBrands OFF");
                    //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT ProductBrands OFF");
                    //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ProductBrands OFF");
                    //transaction.Commit();

                }

                if (!context.ProductTypes.Any())
                {
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ProductTypes ON");
                    var typesdata = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);
                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes ON");

                    foreach (var type in types)
                    {
                        context.ProductTypes.Add(type);
                    }

                    await context.SaveChangesAsync();
                    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT ProductTypes OFF");
                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT ProductTypes OFF");
                }

                if (!context.Products.Any())
                {
                    var productdata = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productdata);

                    foreach (var pro in products)
                    {
                        context.Products.Add(pro);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
