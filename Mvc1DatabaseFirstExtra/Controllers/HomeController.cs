using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc1DatabaseFirstExtra.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mvc1DatabaseFirstExtra.ViewModels;

namespace Mvc1DatabaseFirstExtra.Controllers
{
    // Web backend ÄR Händelsestyrd programmering
    //             Eventstyrd
    //Händelser    - Windows Forms-programmering    void button1_OnClick() .. hjah
    //               "URL Change"

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NorthwindContext _dbContext;

        public HomeController(ILogger<HomeController> logger, NorthwindContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public class ProductItem
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string CategoryName { get; set; }
        }

        public IActionResult Index()
        {

            var list = _dbContext.Products.Select(dbProd => new ProductItem
            {
                Id = dbProd.ProductId,
                CategoryName = dbProd.Category.CategoryName,
                ProductName = dbProd.ProductName
            }).ToList();

            //var l = _dbContext.Products.ToList();

            //var l2 = new List<ProductItem>();
            //foreach (var dbProd in l)
            //{
            //    l2.Add(new ProductItem
            //    {
            //        Id = dbProd.ProductId,
            //        CategoryName = dbProd.Category.CategoryName,
            //        ProductName = dbProd.ProductName
            //    });
            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
