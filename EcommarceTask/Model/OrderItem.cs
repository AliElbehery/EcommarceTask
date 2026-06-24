using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommarceTask.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(OrderItem.Id)), Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public override string ToString()
        {
            return $"ProductId : {ProductId}  , Quantity : {Quantity}";
        }
    }
}
