using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EcommarceTask.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer name is required"), MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<ShippingAdress> ShippingAddresses { get; set; } = new List<ShippingAdress>();
        public override string ToString()
        {
            return $"Customer Name : {Name} Email : {Email}";
        }
    }
}
