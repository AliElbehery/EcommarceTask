using EcommarceTask.Data;
using Microsoft.EntityFrameworkCore;
using EcommarceTask.Model;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;


namespace EcommarceTask.Service
{
    public class CategoryServices
    {
        private AppDbContext _context;

        public CategoryServices(AppDbContext context)
        {
            _context = context;
        }
        public void DisplayCategoryWithProducts()
        {

            var categories = _context.Categories.Include(p => p.Products).ToList();
            foreach (var category in categories)
            {
                Console.WriteLine(category);
                foreach (var product in category.Products)
                {
                    Console.WriteLine(product);
                }
            }

        }
    }
}
