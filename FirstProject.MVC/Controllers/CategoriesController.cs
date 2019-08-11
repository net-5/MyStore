using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Services;

namespace FirstProject.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public ActionResult Index()
        {
            var allCategories = _categoryService.GetAllCategories();

            return View(allCategories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories model)
        {
            if (ModelState.IsValid)
            {
                var addedCategory = _categoryService.AddCategory(model);

                if (addedCategory == null)
                {
                    ModelState.AddModelError("Categoryname", "The category name must be unique");

                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryService.FindCategoryById(id);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categories model)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = _categoryService.FindCategoryById(id);
          
                TryUpdateModelAsync(existingCategory);
          
                _categoryService.UpdateCategory(existingCategory);
              
                return RedirectToAction(nameof(Index));
            }

            return View(model);

        }
    }
}