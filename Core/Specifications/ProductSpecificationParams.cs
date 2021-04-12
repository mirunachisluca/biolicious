using System;

namespace Core.Specifications
{
    public class ProductSpecificationParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 20;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public string Sort { get; set; }

        private string _search;
        public string Search
        {
            get => _search;
            set => _search = String.IsNullOrEmpty(value) ? "" : value.ToLower();
        }
    }
}
