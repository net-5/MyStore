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
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        // GET: Customers
        public ActionResult Index()
        {
            var allCustomers = customerService.GetAllCustomers();
            //return View("MyFirstView", allCustomers);
            return View(allCustomers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customers model)
        {
            if (ModelState.IsValid)
            {
                var addedCustomer = customerService.AddCustomer(model);
                if (addedCustomer == null)
                {
                    ModelState.AddModelError("Companyname", "The company name must be unique");

                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = customerService.FindMyCustomerById(id);

            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customers model)
        {
            if (ModelState.IsValid)
            {
                //find the customer to update(if exists)
                var existingCustomer = customerService.FindMyCustomerById(id);
                //update existing db entity with the changes from the model
                TryUpdateModelAsync(existingCustomer);
                //update and save the changes into the db
                customerService.UpdateCustomer(existingCustomer);
                //redirect to index, because everything went ok
                return RedirectToAction(nameof(Index));
            }
            //re-return the view to display errors
            return View(model);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
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