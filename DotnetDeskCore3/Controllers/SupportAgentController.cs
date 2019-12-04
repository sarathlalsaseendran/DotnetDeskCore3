using DotnetDeskCore3.Data;
using DotnetDeskCore3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DotnetDeskCore3.Controllers
{
    public class SupportAgentController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SupportAgentController(ApplicationDbContext context)
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
                SupportAgent supportAgent = new SupportAgent();
                supportAgent.organizationId = org;
                return View(supportAgent);
            }
            else
            {
                return View(_context.SupportAgent.Where(x => x.supportAgentId.Equals(id)).FirstOrDefault());
            }
        }
    }
}
