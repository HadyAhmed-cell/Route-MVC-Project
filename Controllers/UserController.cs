using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Route.NetDAL.Entities;

namespace Route.NetPL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(string SearchValue = "")
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var users = userManager.Users.ToList();
                return View(users);
            }
            else
            {
                var user = await userManager.Users.Where(x => x.NormalizedEmail.Contains(SearchValue.ToUpper())).ToListAsync();
                return View(user);
            }
        }
        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(viewName, user);
        }

        public async Task<IActionResult> Update(string id)
        {
            return await Details(id, "Update");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var appUser = await userManager.FindByIdAsync(id);

                    appUser.UserName = user.UserName;
                    appUser.NormalizedUserName = user.UserName.ToUpper();
                    appUser.PhoneNumber = user.PhoneNumber;

                    var result = await userManager.UpdateAsync(appUser);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }

            }

            return View(user);
        }


        public async Task<IActionResult> Delete(string id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                var appUser = await userManager.FindByIdAsync(id);



                var result = await userManager.DeleteAsync(appUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }




        }
    }
}


