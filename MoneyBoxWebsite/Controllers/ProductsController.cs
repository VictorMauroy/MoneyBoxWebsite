using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoneyBoxWebsite;
using MoneyBoxWebsite.Models;
using MoneyBoxWebsite.Models.ViewModels;
using MoneyBoxWebsite.Repositories;

namespace MoneyBoxWebsite.Controllers
{
    [Authorize(Roles = "Admin, Manager, Assistant")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        #region Products
        // GET: Products
        [AllowAnonymous, Route("/")]
        public async Task<IActionResult> Index()
        {
            return View(await _productRepository.GetAllAsync());
        }

        // GET: Products/Details/5
        [AllowAnonymous]
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
        public async Task<IActionResult> Create()
        {
            IEnumerable<ProductGroup> groups = await _productRepository.GetAllGroupsAsync();
            List<ProductGroup> orderedGroups = (from groupElement in groups
                                                orderby groupElement.Name
                                                select groupElement)
                                                .ToList();
            ViewBag.Groups = orderedGroups;
            
            return View();
        }

        // POST: Products/Create
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
                    Weight = productCreation.Weight,
                    MoneyCapacity = productCreation.MoneyCapacity,
                    ImageFilePath = "",
                    Reference = "#" + "",
                    Manufacturer = productCreation.Manufacturer,
                    Color = productCreation.Color
                };

                if (productCreation.GroupIds.Count > 1)
                {
                    foreach (Guid groupId in productCreation.GroupIds)
                    {
                        ProductGroup? group = await _productRepository.GetGroupByIdAsync(groupId);
                        if (group != null)
                            product.ProductGroups.Add(group);
                    }
                }

                await _productRepository.CreateAsync(product); // Create and save
                
                return RedirectToAction("Index");
            }

            IEnumerable<ProductGroup> groups = await _productRepository.GetAllGroupsAsync();
            List<ProductGroup> orderedGroups = (from groupElement in groups
                                                orderby groupElement.Name
                                                select groupElement)
                                                .ToList();
            ViewBag.Groups = orderedGroups;

            return View();
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

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
                product.Weight = editedProduct.Weight;
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
        #endregion

        #region Product Groups
        public async Task<IActionResult> ProductGroupIndex()
        {
            IEnumerable<ProductGroup> productGroups = await _productRepository.GetAllGroupsAsync();
            List<ProductGroup> orderedGroups = (from productGroup in productGroups
                                                orderby productGroup.Name
                                                select productGroup).ToList();
            return View(orderedGroups);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductGroup(string name)
        {
            if (name == null)
            {
                ViewBag.AddGroupErrors = "Please enter a valid group name.";
                return RedirectToAction("ProductGroupIndex");
            }
            else
            {
                ViewBag.AddGroupErrors = "";
            }

            ProductGroup group = new() { Name = name };
            await _productRepository.CreateGroupAsync(group);
            return RedirectToAction("ProductGroupIndex");
        }

        public async Task<IActionResult> GroupDetails(Guid id)
        {
            ProductGroup? group = await _productRepository.GetGroupByIdAsync(id);
            if (group == null)
                return NotFound();

            return View(group);
        }

        [HttpPost]
        public async Task<IActionResult> EditGroup(Guid id, string newName)
        {
            if (newName == null)
            {
                ViewBag.EditGroupErrors = "Please enter a valid group name.";
                return RedirectToAction("GroupDetails", new { id });
            } else
            {
                ViewBag.EditGroupErrors = "";
            }

            ProductGroup? group = await _productRepository.GetGroupByIdAsync(id);
            if (group == null)
                return NotFound(); // Could it be null if removed by another user ?

            group.Name = newName;
            await _productRepository.UpdateGroupAsync(group);

            return RedirectToAction("GroupDetails", new {id});
        }


        public async Task<IActionResult> RemoveProductGroup(Guid id)
        {
            ProductGroup? group = await _productRepository.GetGroupByIdAsync(id);
            if(group == null)
                return NotFound();

            return View(group);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroup()
        {
            string groupId = Request.Form["groupId"];
            if (string.IsNullOrEmpty(groupId)) 
                return RedirectToAction("ProductGroupIndex");

            Guid id = Guid.Parse(groupId);
            await _productRepository.RemoveGroupAsync(id);
            return RedirectToAction("ProductGroupIndex");
        }
        #endregion
    }
}
