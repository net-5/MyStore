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
    public class SuppliersController : Controller
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            var allSuppliers = supplierService.GetAllSuppliers();
            //return View("MyFirstView", allSuppliers);
            return View(allSuppliers);
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Suppliers model)
        {
            if (ModelState.IsValid)
            {
                var addedSupplier = supplierService.AddSupplier(model);
                if (addedSupplier == null)
                {
                    ModelState.AddModelError("Suppliername", "The supplier name must be unique");

                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id)
        {
            var supplier = supplierService.FindMySupplierById(id);

            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Suppliers model)
        {
            if (ModelState.IsValid)
            {
                //find the supplier to update(if exists)
                var existingSupplier = supplierService.FindMySupplierById(id);
                //update existing db entity with the changes from the model
                TryUpdateModelAsync(existingSupplier);
                //update and save the changes into the db
                supplierService.UpdateSupplier(existingSupplier);
                //redirect to index, because everything went ok
                return RedirectToAction(nameof(Index));
            }
            //re-return the view to display errors
            return View(model);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Suppliers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}