using webapi1.API.DTO;

namespace webapi1.API.Helpers
{
    public class Pageinitation<T> where T: class
    {
        private IReadOnlyList<ProductDto> data;

        public Pageinitation(int pageIndex, int pageSize, int totalItems, IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            this.Count = totalItems;
            this.Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T>  Data { get; set; }
    }
}
