using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EcommarceTask.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Product name is required"), MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public override string ToString()
        {
            return $" Product Name : {Name} Price : {Price} ";
        }

    }
}
