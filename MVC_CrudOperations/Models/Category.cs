using System.ComponentModel.DataAnnotations;

namespace MVC_CrudOperations.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
