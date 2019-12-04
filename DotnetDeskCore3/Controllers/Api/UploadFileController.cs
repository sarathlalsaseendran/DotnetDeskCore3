using DotnetDeskCore3.Data;
using DotnetDeskCore3.Models;
using DotnetDeskCore3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetDeskCore3.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/UploadFile")]
    [Authorize]
    public class UploadFileController : Controller
    {
        private readonly IDotnetdesk _dotnetdesk;
        [Obsolete]
        private readonly IHostingEnvironment _env;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        [Obsolete]
        public UploadFileController(IDotnetdesk dotnetdesk,
            IHostingEnvironment env,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _dotnetdesk = dotnetdesk;
            _env = env;
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        [RequestSizeLimit(5000000)]
        [Obsolete]
        public async Task<IActionResult> PostUploadFile(List<IFormFile> files)
        {
            try
            {
                var fileName = await _dotnetdesk.UploadFile(files, _env);
                //try to update the user profile pict
                ApplicationUser appUser = await _userManager.GetUserAsync(User);
                appUser.ProfilePictureUrl = "/uploads/" + fileName;
                _context.Update(appUser);
                _context.SaveChanges();
                return Ok(fileName);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }


        }

        [HttpPost("Wallpaper")]
        [RequestSizeLimit(5000000)]
        [Obsolete]
        public async Task<IActionResult> PostUploadFileWallpaper(List<IFormFile> files)
        {
            try
            {
                var fileName = await _dotnetdesk.UploadFile(files, _env);
                //try to update the user wallpaper pict
                ApplicationUser appUser = await _userManager.GetUserAsync(User);
                appUser.WallpaperPictureUrl = "/uploads/" + fileName;
                _context.Update(appUser);
                _context.SaveChanges();
                return Ok(fileName);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}
