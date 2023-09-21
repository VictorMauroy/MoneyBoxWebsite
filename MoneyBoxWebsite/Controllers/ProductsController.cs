using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyBoxWebsite;
using MoneyBoxWebsite.Models;
using MoneyBoxWebsite.Models.ViewModels;
using MoneyBoxWebsite.Repositories;

namespace MoneyBoxWebsite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _productRepository.GetAllAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productCreation)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    Name = productCreation.Name,
                    Description = productCreation.Description,
                    Price = productCreation.Price,
                    Height = productCreation.Height,
                    Width = productCreation.Width,
                    Length = productCreation.Length,
                    Weigth = productCreation.Weight,
                    MoneyCapacity = productCreation.MoneyCapacity,
                    ImageFilePath = "",
                    Reference = "#" + "",
                    Manufacturer = productCreation.Manufacturer,
                    Color = productCreation.Color
                };

                await _productRepository.CreateAsync(product); // Create and save
                
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel editedProduct)
        {
            if (ModelState.IsValid)
            {
                Product product = await _productRepository.GetByIdAsync(id);

                product.Name = editedProduct.Name;
                product.Description = editedProduct.Description;
                product.Price = editedProduct.Price;
                product.Height = editedProduct.Height;
                product.Width = editedProduct.Width;
                product.Length = editedProduct.Length;
                product.Manufacturer = editedProduct.Manufacturer;
                product.Color = editedProduct.Color;
                product.Weigth = editedProduct.Weight;
                product.ImageFilePath = "";

                try
                {
                    await _productRepository.UpdateAsync(product); // Update and Save
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();   
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                await _productRepository.DisableAsync(id); // Disable visibility and Save
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
