using EcommarceTask.Service;
using EcommarceTask.Model;
using EcommarceTask.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks.Sources;

namespace EcommarceTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();
            var categoryServices = new CategoryServices(context);
            categoryServices.DisplayCategoryWithProducts();
            Console.WriteLine("======================================");
            var customerServices = new CustomerServices(context);
            customerServices.DisplayCustomerWithShippingAddresses();
            Console.WriteLine("======================================");
            customerServices.DisplayCustomerWithOrdersWithItems();




        }
    }
}
