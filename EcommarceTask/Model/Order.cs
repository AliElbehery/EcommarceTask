using EcommarceTask.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommarceTask.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer is required"), ForeignKey(nameof(OrderItem.ProductId))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        [Required(ErrorMessage = "Shipping address is required")]
        public int ShippingAddressId { get; set; }
        public ShippingAdress ShippingAdress { get; set; }

        public override string ToString()
        {
            return $"OrderId : {Id} , CustomerId : {CustomerId} , AddressId : {ShippingAddressId} , Total Price : {CalculateTotalPrice(this.Id)}";
        }
        public decimal CalculateTotalPrice(int orderId)
        {

            decimal totalPrice = 0;
            foreach (var item in Items)
            {
                totalPrice += item.Product.Price * item.Quantity;
            }
            return totalPrice;


        }
    }
}
