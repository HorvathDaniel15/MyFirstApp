using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyFirstApp.Data;
using MyFirstApp.Models;
using System.IO.Pipes;

namespace MyFirstApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View(this.repo.ReadAll());
        }

        public IActionResult Details(int id)
        {
            var product = this.repo.Read(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            this.repo.Create(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id) 
        {
            var product = this.repo.Read(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            repo.Update(product);
            return RedirectToAction(nameof(Index));
		}

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = repo.Read(id);
            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            var existingProduct = this.repo.Read(product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            this.repo.Delete(existingProduct.Id);

            return RedirectToAction(nameof(Index));
		}


    }
}
