using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EcommarceTask.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required"), MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public override string ToString()
        {
            return $"Name : {Name}" ;
        }
    }
}
