using DotnetDeskCore3.Data;
using DotnetDeskCore3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DotnetDeskCore3.Controllers
{
    public class SupportEngineerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupportEngineerController(ApplicationDbContext context)
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
                SupportEngineer supportEngineer = new SupportEngineer();
                supportEngineer.organizationId = org;
                return View(supportEngineer);
            }
            else
            {
                return View(_context.SupportEngineer.Where(x => x.supportEngineerId.Equals(id)).FirstOrDefault());
            }

        }
    }
}
