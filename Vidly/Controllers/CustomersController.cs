using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Vidly.Models;
using Vidly.ViewModels;
using WebGrease.Css.Extensions;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index(string message, GenericData.MessageTypes? messageType)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            if (messageType != null || !message.IsNullOrWhiteSpace())
            {
                ViewBag.StatusMessage = message;
                ViewBag.MessageTypeClass = GenericData.MessageTypeClass((GenericData.MessageTypes)messageType);
            }
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer() { Email = User.Identity.GetUserName(), UserId = User.Identity.GetUserId() },
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var message = "Customer is not registered to your user";
            var messageType = GenericData.MessageTypes.Danger;
            var dbCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (dbCustomer.UserId.Equals(User.Identity.GetUserId()) || User.IsInRole("administrator"))
            {
                _context.Customers.Remove(dbCustomer);
                _context.SaveChanges();
                message = "Customer deleted successfuly";
                messageType = GenericData.MessageTypes.Success;
            }
            _context.Dispose();
            return RedirectToAction("Index", new { message = message, messageType = messageType });
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            var message = "Customer was created successfylly";
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()

                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var dbCustomer = _context.Customers.Single(c => c.Id == customer.Id);
                dbCustomer.Name = customer.Name;
                dbCustomer.Dob = customer.Dob;
                dbCustomer.MembershipTypeId = customer.MembershipTypeId;
                dbCustomer.Newsletter = customer.Newsletter;
                dbCustomer.Email = customer.Email;
                dbCustomer.Sex = customer.Sex;
                dbCustomer.CountryCode = customer.CountryCode;
                dbCustomer.PhoneNumber = customer.PhoneNumber;
                message = "Customer was updated successfully";

            }

            try
            {
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                    e = e.InnerException;
                return RedirectToAction("Index", new { message = "There was an issue with your request, please contact us: \n" + e.Message, messageType = GenericData.MessageTypes.Danger });
            }

            return RedirectToAction("Index", new { message = message, messageType = GenericData.MessageTypes.Success });

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToSafeReadOnlyCollection()
            };
            return View("CustomerForm", viewModel);
        }
    }
}