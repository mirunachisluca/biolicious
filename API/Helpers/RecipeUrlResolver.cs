using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class RecipeUrlResolver : IValueResolver<Recipe, RecipeDTO, string>
    {
        private readonly IConfiguration _config;

        public RecipeUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Recipe source, RecipeDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
