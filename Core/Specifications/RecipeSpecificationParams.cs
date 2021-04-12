using System;

namespace Core.Specifications
{
    public class RecipeSpecificationParams
    {
        public int? CategoryId {get;set;}
        public int? DietId { get; set; }
        public string Sort { get; set; }

        private string _search;
        public string Search
        {
            get => _search;
            set => _search = String.IsNullOrEmpty(value) ? "" : value.ToLower();
        }
    }
}
