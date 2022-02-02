using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{

    [TableAttribute("ProductBrand")]

    public class ProductBrand : BaseEntity
    {

        public string? Name { get; set; }
    }
}