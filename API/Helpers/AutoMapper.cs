using AutoMapper;
using Core.Entities;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using API.DTOs;

namespace API.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(m => m.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(m => m.ProductCategory, o => o.MapFrom(s => s.ProductCategory.Name))
                .ForMember(m => m.ProductSubcategory, o => o.MapFrom(s => s.ProductSubcategory.Name));
            CreateMap<ProductBrand, ProductBrandDTO>();
            CreateMap<ProductCategory, ProductCategoryDTO>();
            CreateMap<ProductSubcategory, ProductSubcategoryDTO>();
            //CreateMap<Diet, string>().ConvertUsing(d => d.Name);
            CreateMap<RecipeStep, string>().ConvertUsing(s => s.Step);
            CreateMap<Recipe, RecipeDTO>()
                .ForMember(m => m.RecipeCategory, o => o.MapFrom(s => s.RecipeCategory.Name))
                .ForMember(m => m.Diet, o => o.MapFrom(s => s.Diet.Name))
                .ForMember(m => m.RecipeSteps, o => o.MapFrom(s => s.RecipeSteps));
            CreateMap<RecipeIngredient, RecipeIngredientDTO>()
                .ForMember(m => m.ProductName, o => o.MapFrom(s => s.Product.Name));
            //CreateMap<RecipeStep, RecipeStepDTO>();
            CreateMap<RecipeCategory, RecipeCategoryDTO>();
            CreateMap<Diet, DietDTO>();
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
