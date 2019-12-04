using DotnetDeskCore3.Data;
using DotnetDeskCore3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DotnetDeskCore3.Controllers
{
    public class ModuleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ModuleController(ApplicationDbContext context)
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
    }
}
