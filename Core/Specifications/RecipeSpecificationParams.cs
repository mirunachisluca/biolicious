using System;

namespace Core.Specifications
{
    public class RecipeSpecificationParams
    {
        private const int MaxPageSize = 20;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 20;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

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
