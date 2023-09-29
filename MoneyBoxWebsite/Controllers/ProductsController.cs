using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoneyBoxWebsite;
using MoneyBoxWebsite.Data;
using MoneyBoxWebsite.Models;
using MoneyBoxWebsite.Models.ViewModels;
using MoneyBoxWebsite.Repositories;
using Newtonsoft.Json;

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
            ViewBag.Groups = await FillViewBag();

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productCreation)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = await FillViewBag();
                return View();
            }

            string imgExtension = Path.GetExtension(productCreation.Image.FileName);
            if (imgExtension != ".png" && imgExtension != ".jpg" && imgExtension != ".jpeg")
            {
                ModelState.AddModelError(
                    "Image",
                    "Current extension: " + imgExtension +
                    ". That file format isn't accepted. Please add a .jpg, .jpeg or .png");
                ViewBag.Groups = await FillViewBag();
                return View();
            }

            string storedImgName = FileUploader.UploadImage(productCreation.Image);
            if (storedImgName == "")
            {
                ModelState.AddModelError(
                    "Image",
                    "Couldn't save the file. " +
                        "Please try again with another one. Accepted format : .jpg, .jpeg, .png");
                ViewBag.Groups = await FillViewBag();
                return View();
            }

            string productRef = Guid.NewGuid().ToString();
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
                ImageFilePath = "/images/" + storedImgName,
                Reference = "#" + productRef,
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

        /// <summary>
        /// Fill the ViewBag with the list of group of products.
        /// </summary>
        /// <returns>The group of products list</returns>
        public async Task<List<ProductGroup>> FillViewBag()
        {
            IEnumerable<ProductGroup> groups = await _productRepository.GetAllGroupsAsync();
            List<ProductGroup> orderedGroups = (from groupElement in groups
                                                orderby groupElement.Name
                                                select groupElement)
                                                .ToList();
            return orderedGroups;
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            ViewBag.CurrentProduct = product;

            ViewBag.Groups = await FillViewBag();

            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditProductViewModel editedProduct)
        {
            if (!ModelState.IsValid)
            {
                Product currentProduct = await _productRepository.GetByIdAsync(id);
                ViewBag.CurrentProduct = currentProduct;

                ViewBag.Groups = await FillViewBag();
                return View();
            }

            Product product = await _productRepository.GetByIdAsync(id);

            if (editedProduct.Image != null && editedProduct.Image.Length > 0)
            {
                string imgExtension = Path.GetExtension(editedProduct.Image.FileName);
                if (imgExtension != ".png" && imgExtension != ".jpg" && imgExtension != ".jpeg")
                {
                    ModelState.AddModelError(
                        "Image",
                        "Current extension: " + imgExtension +
                        ". That file format isn't accepted. Please add a .jpg, .jpeg or .png");

                    Product currentProduct = await _productRepository.GetByIdAsync(id);
                    ViewBag.CurrentProduct = currentProduct;

                    ViewBag.Groups = await FillViewBag();
                    return View();
                }

                string storedImgName = FileUploader.UploadImage(editedProduct.Image);
                if (storedImgName == "")
                {
                    ModelState.AddModelError(
                        "Image",
                        "Couldn't save the file. " +
                            "Please try again with another one. Accepted format : .jpg, .jpeg, .png");

                    Product currentProduct = await _productRepository.GetByIdAsync(id);
                    ViewBag.CurrentProduct = currentProduct;

                    ViewBag.Groups = await FillViewBag();
                    return View();
                }


                // I should remove the old image here. Before saving the new one.

                product.ImageFilePath = "/images/" + storedImgName;
            }

            product.Name = editedProduct.Name;
            product.Description = editedProduct.Description;
            product.Price = editedProduct.Price;
            product.Height = editedProduct.Height;
            product.Width = editedProduct.Width;
            product.Length = editedProduct.Length;
            product.Manufacturer = editedProduct.Manufacturer;
            product.Color = editedProduct.Color;
            product.Weight = editedProduct.Weight;

            try
            {
                await _productRepository.UpdateAsync(product); // Update and Save
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToAction("Details", new {id});
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

        [HttpPost]
        public async Task<IActionResult> Restore(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                await _productRepository.EnableAsync(id); // Disable visibility and Save
            }

            return RedirectToAction("Details", new {id});
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
            }
            else
            {
                ViewBag.EditGroupErrors = "";
            }

            ProductGroup? group = await _productRepository.GetGroupByIdAsync(id);
            if (group == null)
                return NotFound(); // Could it be null if removed by another user ?

            group.Name = newName;
            await _productRepository.UpdateGroupAsync(group);

            return RedirectToAction("GroupDetails", new { id });
        }


        public async Task<IActionResult> RemoveProductGroup(Guid id)
        {
            ProductGroup? group = await _productRepository.GetGroupByIdAsync(id);
            if (group == null)
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

        #region Orders
        [HttpPost, Authorize(Roles ="Admin, Manager, Assistant, Client, Moderator")]
        public async Task<IActionResult> AddOrderToCart(IFormCollection formDatas)
        {
            Product currentProduct = await _productRepository.GetByIdAsync(Guid.Parse(formDatas["Id"]));
            Console.WriteLine("\n \n" + "Ordering: " + formDatas["Quantity"] + " of " + currentProduct.Name + "\n \n");
            int quantity = int.Parse(formDatas["Quantity"]);

            ProductOrder order = new()
            {
                Quantity = quantity,
                LinkedProduct = currentProduct,
                SellPrice = currentProduct.Price
            };

            /*  ----- Session datas -----
             *  To save the datas for the session, it's recommended to use a temporary table
             *  inside the database. This is easier to work with when the website is deployed 
             *  into a cluster or with Azure.
             */

            // Shipping cart exists
            if(!HttpContext.Session.GetString("ShippingCart").IsNullOrEmpty())
            {
                string shippingCartJson = HttpContext.Session.GetString("ShippingCart");
                List<ProductOrder> ordersList = JsonConvert.DeserializeObject<List<ProductOrder>>(shippingCartJson);
                ordersList.Add(order);

                string jsonString = JsonConvert.SerializeObject(ordersList, Formatting.Indented);
                HttpContext.Session.SetString("ShippingCart", jsonString);
            } 
            else // Shipping cart doesn't exist
            {
                List<ProductOrder> ordersList = new List<ProductOrder>();
                ordersList.Add(order);

                string jsonString = JsonConvert.SerializeObject(ordersList, Formatting.Indented);
                HttpContext.Session.SetString("ShippingCart", jsonString);
            }
            
            return View("Details", new { id = currentProduct.ProductId });
        }

        #endregion
    }
}
