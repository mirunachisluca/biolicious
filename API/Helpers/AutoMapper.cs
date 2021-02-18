using API.DTOs;
using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Entities.Order;

namespace API.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductCategory, o => o.MapFrom(s => s.ProductCategory.Name))
                .ForMember(d => d.ProductSubcategory, o => o.MapFrom(s => s.ProductSubcategory.Name));
            CreateMap<ProductBrand, ProductBrandDTO>();
            CreateMap<ProductCategory, ProductCategoryDTO>();
            CreateMap<ProductSubcategory, ProductSubcategoryDTO>();
            //CreateMap<Diet, string>().ConvertUsing(d => d.Name);
            CreateMap<RecipeStep, string>().ConvertUsing(s => s.Step);
            CreateMap<Recipe, RecipeDTO>()
                .ForMember(d => d.RecipeCategory, o => o.MapFrom(s => s.RecipeCategory.Name))
                .ForMember(d => d.Diet, o => o.MapFrom(s => s.Diet.Name))
                .ForMember(d => d.RecipeSteps, o => o.MapFrom(s => s.RecipeSteps));
            CreateMap<RecipeIngredient, RecipeIngredientDTO>()
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name));
            //CreateMap<RecipeStep, RecipeStepDTO>();
            CreateMap<RecipeCategory, RecipeCategoryDTO>();
            CreateMap<Diet, DietDTO>();
            CreateMap<Core.Entities.Identity.Address, AddressDTO>().ReverseMap();
            CreateMap<AddressDTO, Core.Entities.Order.Address>();
            CreateMap<Order, OrderToReturnDTO>()
                .ForMember(d => d.DeliveryMethod, o=>o.MapFrom(s=>s.DeliveryMethod.Name))
                .ForMember(d => d.DeliveryPrice,o=>o.MapFrom(s=>s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(d => d.ProductItemId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.ItemOrdered.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl));
        }
    }
}
