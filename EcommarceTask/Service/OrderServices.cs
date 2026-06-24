using System;
using System.Collections.Generic;
using System.Text;
using EcommarceTask.Data;
using Microsoft.EntityFrameworkCore;
using EcommarceTask.Model;

namespace EcommarceTask.Service
{
    public class OrderServices
    {
        private AppDbContext _context;
        public OrderServices(AppDbContext context)
        {
            _context = context;
        }
        
        
    }
}
