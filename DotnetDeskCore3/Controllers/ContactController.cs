using DotnetDeskCore3.Data;
using DotnetDeskCore3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DotnetDeskCore3.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AddEdit(Guid cust, Guid id)
        {
            if (id == Guid.Empty)
            {
                Contact contact = new Contact
                {
                    customerId = cust
                };
                return View(contact);
            }
            else
            {
                return View(_context.Contact.Where(x => x.contactId.Equals(id)).FirstOrDefault());
            }
        }
    }
}
