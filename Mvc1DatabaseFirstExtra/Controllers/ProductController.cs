using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mvc1DatabaseFirstExtra.Models;
using Mvc1DatabaseFirstExtra.ViewModels;

namespace Mvc1DatabaseFirstExtra.Controllers
{
    public class ProductController : Controller
    {
        private readonly NorthwindContext _dbContext;

        public ProductController(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index(string SearchWord)
        {
            var viewModel = new ProductIndexViewModel();
            viewModel.Names = _dbContext.Products.Where(r=>
                    SearchWord == null || r.ProductName.Contains(SearchWord))
                .Select(r => r.ProductName).ToList();
            return View(viewModel);
        }

        //Product/Edit/2
        public IActionResult Edit(int id)
        {
            var viewModel = new ProductEditViewModel();
            var dbProdukten = _dbContext.Products.First(r => r.ProductId == id);

            viewModel.ProductName = dbProdukten.ProductName;
            viewModel.Discontinued = dbProdukten.Discontinued;
            viewModel.LatestOrderNumbers = _dbContext.Orders.Select(r => r.OrderId)
                .OrderByDescending(i => i).Take(10).ToList();
            return View(viewModel);
        }


        // /2   ProductName=Chang&Discontinued=false      
        [HttpPost]
        public IActionResult Edit( int id, ProductEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //Uppdatera databasen
                var dbProdukten = _dbContext.Products.First(r => r.ProductId == id);
                dbProdukten.ProductName = viewModel.ProductName;
                dbProdukten.Discontinued = viewModel.Discontinued;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }


    }
}