﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Products_Sales_Commission_Core_Web.BusinessLayer;
using Products_Sales_Commission_Core_Web.Models;

namespace Products_Sales_Commission_Core_Web.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly Products_Sales_Commission_Core_Web.Models.Products_Sales_Commission_Data_Context _context;

        public DetailsModel(Products_Sales_Commission_Core_Web.Models.Products_Sales_Commission_Data_Context context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product
                .Include(p => p.Manufacturer).FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
