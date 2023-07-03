using System.ComponentModel.DataAnnotations;

namespace MVC_CrudOperations.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        [Required(ErrorMessage ="Please enter category Name")]
        public string CategoryName { get; set; }
    }
}
