using Core.Entities;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.ProductCategories.Any())
                {
                    var categoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");
                    var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);

                    foreach (var item in categories)
                    {
                        context.ProductCategories.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                //if (!context.Products.Any())
                //{
                //    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                //    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                //    foreach (var item in products)
                //    {
                //        context.Products.Add(item);
                //    }

                //    await context.SaveChangesAsync();
                //}


                if (!context.RecipeCategories.Any())
                {
                    var categoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/recipe_categories.json");
                    var categories = JsonSerializer.Deserialize<List<RecipeCategory>>(categoriesData);

                    foreach (var item in categories)
                    {
                        context.RecipeCategories.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Diets.Any())
                {
                    var dietsData = File.ReadAllText("../Infrastructure/Data/SeedData/diets.json");
                    var diets = JsonSerializer.Deserialize<List<Diet>>(dietsData);

                    foreach (var item in diets)
                    {
                        context.Diets.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
