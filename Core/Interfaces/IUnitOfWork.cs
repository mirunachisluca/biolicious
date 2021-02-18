using Core.Entities;
using Core.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; set; }
        IGenericRepository<ProductBrand> ProductBrandRepository { get; set; }
        IGenericRepository<ProductCategory> ProductCategoryRepository { get; set; }
        IGenericRepository<ProductSubcategory> ProductSubcategoryRepository { get; set; }
        IGenericRepository<Recipe> RecipeRepository { get; set; }
        IGenericRepository<RecipeIngredient> RecipeIngredientRepository { get; set; }
        IGenericRepository<RecipeStep> RecipeStepRepository { get; set; }
        IGenericRepository<RecipeCategory> RecipeCategoryRepository { get; set; }
        IGenericRepository<Intake> IntakeRepository { get; set; }
        IGenericRepository<Diet> DietRepository { get; set; }
        IGenericRepository<Order> OrderRepository { get; set; }
        IGenericRepository<OrderItem> OrderItemRepository { get; set; }
        IGenericRepository<DeliveryMethod> DeliveryMethodRepository { get; set; }
        Task<int> Save();
        new void Dispose();
    }
}
