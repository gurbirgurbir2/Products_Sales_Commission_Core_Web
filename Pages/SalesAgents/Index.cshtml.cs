﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Products_Sales_Commission_Core_Web.BusinessLayer;
using Products_Sales_Commission_Core_Web.Models;

namespace Products_Sales_Commission_Core_Web.Pages.SalesAgents
{
    public class IndexModel : PageModel
    {
        private readonly Products_Sales_Commission_Core_Web.Models.Products_Sales_Commission_Data_Context _context;

        public IndexModel(Products_Sales_Commission_Core_Web.Models.Products_Sales_Commission_Data_Context context)
        {
            _context = context;
        }

        public IList<SalesAgent> SalesAgent { get;set; }

        public async Task OnGetAsync()
        {
            SalesAgent = await (from agent in _context.SalesAgent select agent).ToListAsync();
        }
    }
}