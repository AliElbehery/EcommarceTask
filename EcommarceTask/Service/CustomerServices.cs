using System;
using System.Collections.Generic;
using System.Text;
using EcommarceTask.Data;
using Microsoft.EntityFrameworkCore;
using EcommarceTask.Model;

namespace EcommarceTask.Service
{
    public class CustomerServices
    {
        private AppDbContext _context;
        public CustomerServices(AppDbContext context)
        {
            _context = context;
        }
        public void DisplayCustomerWithShippingAddresses()
        {
            var customers = _context.Customers.Include(c => c.ShippingAddresses).ToList();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
                foreach (var address in customer.ShippingAddresses)
                {
                    Console.WriteLine($"  Shipping Address: {address}");
                }
            }
        }
        public void DisplayCustomerWithOrdersWithItems()
        {
            var customers = _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.Items)
                .ThenInclude(o => o.Product)
                .ToList();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine(order);
                    foreach (var item in order.Items)
                    {
                        Console.WriteLine($"  Order Item: {item}, Product: {item.Product}");
                    }
                }
            }
        }
    }
}
