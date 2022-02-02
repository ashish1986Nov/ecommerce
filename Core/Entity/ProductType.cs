using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [TableAttribute("ProductType")]

    public class ProductType : BaseEntity
    {

        public string? Name { get; set; }
    }
}