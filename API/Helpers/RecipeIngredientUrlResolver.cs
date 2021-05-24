using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class RecipeIngredientUrlResolver : IValueResolver<RecipeIngredient, RecipeIngredientDTO, string>
    {
        private readonly IConfiguration _config;

        public RecipeIngredientUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(RecipeIngredient source, RecipeIngredientDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Product.PictureUrl))
            {
                return _config["ApiUrl"] + source.Product.PictureUrl;
            }

            return null;
        }
    }
}
