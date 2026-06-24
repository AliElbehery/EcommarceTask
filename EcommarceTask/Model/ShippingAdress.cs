using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EcommarceTask.Model
{
    public class ShippingAdress
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public ICollection<Order> Order { get; set; } = new List<Order>();
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public override string ToString()
        {
            return $"Customer Id : {CustomerId} Street : {Street} City : {City}";
        }

    }
}
