using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{


    [TableAttribute("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string ? Name { get; set; }

    }
}
