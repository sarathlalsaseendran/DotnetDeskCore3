using DotnetDeskCore3.Data;
using DotnetDeskCore3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DotnetDeskCore3.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(Guid org)
        {
            if (org == Guid.Empty)
            {
                return NotFound();
            }
            Organization organization = _context.Organization.Where(x => x.organizationId.Equals(org)).FirstOrDefault();
            ViewData["org"] = org;
            return View(organization);
        }

        public IActionResult AddEdit(Guid org, Guid id)
        {
            if (id == Guid.Empty)
            {
                Product product = new Product();
                product.organizationId = org;
                return View(product);
            }
            else
            {
                return View(_context.Product.Where(x => x.productId.Equals(id)).FirstOrDefault());
            }

        }
    }
}
