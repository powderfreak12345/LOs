using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearningObjectives.Controllers.Admin
{
    [Route("Admin/Users/[Action]")]
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminUsersController(UserManager<IdentityUser> um, RoleManager<IdentityRole> rm)
        {
            _userManager = um;
            _roleManager = rm;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> ChangeRole(string userName, string userRole, bool add)
        {
            IdentityUser user_ = await _userManager.FindByNameAsync(userName);
            IdentityRole role = await _roleManager.FindByNameAsync(userRole);
            if (add)
                await
                  _userManager.AddToRoleAsync(user_, role.Name);
            else
                await
                 _userManager.RemoveFromRoleAsync(user_, role.Name);

            return Json(new
            {
                success = true
            });

        }
    }

}