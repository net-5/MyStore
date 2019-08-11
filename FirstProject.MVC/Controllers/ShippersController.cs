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
    public class ShippersController : Controller
    {
        private readonly IShipperService shipperService;

        public ShippersController(IShipperService shipperService)
        {
            this.shipperService = shipperService;
        }
        // GET: Shippers
        public ActionResult Index()
        {
            var allShippers = shipperService.GetAllShippers();
            //return View("MyFirstView", allShippers);
            return View(allShippers);
        }

        // GET: Shippers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shippers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shippers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Shippers model)
        {
            if (ModelState.IsValid)
            {
                var addedShipper = shipperService.AddShipper(model);
                if (addedShipper == null)
                {
                    ModelState.AddModelError("Shippername", "The shipper name must be unique");

                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        // GET: Shippers/Edit/5
        public ActionResult Edit(int id)
        {
            var shipper = shipperService.FindMyShipperById(id);

            return View(shipper);
        }

        // POST: Shippers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Shippers model)
        {
            if (ModelState.IsValid)
            {
                //find the shipper to update(if exists)
                var existingShipper = shipperService.FindMyShipperById(id);
                //update existing db entity with the changes from the model
                TryUpdateModelAsync(existingShipper);
                //update and save the changes into the db
                shipperService.UpdateShipper(existingShipper);
                //redirect to index, because everything went ok
                return RedirectToAction(nameof(Index));
            }
            //re-return the view to display errors
            return View(model);
        }

        // GET: Shippers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shippers/Delete/5
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