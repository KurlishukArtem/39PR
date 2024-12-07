using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop_API_Kurlushuk.Data.Interfaces;
using Shop_API_Kurlushuk.Data.Models;
using Shop_API_Kurlushuk.Data.ViewModell;
using Shop_API_Kurlushuk.Data.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shop_API_Kurlushuk.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
		private IItems IAllItems;
        private ICategories IAllCategories;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems IAllItems, ICategories IAllCategories, IHostingEnvironment environment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategories = IAllCategories;
            this.hostingEnvironment = environment;
        }

        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";
            VMItems.Items = IAllItems.AllItems;
            VMItems.Categories = IAllCategories.AllCategories;
            VMItems.SelectCategory = id;
            return View(VMItems);
        }

        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categories> Categories = IAllCategories.AllCategories;
            return View(Categories);
        }

        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            if (files != null)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categories() { Id=idCategory};
            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Update?id=" + id);
        }
    }
}
