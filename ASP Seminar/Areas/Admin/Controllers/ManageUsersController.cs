using ASP_Seminar.Data;
using ASP_Seminar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace ASP_Seminar.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageUsersController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public ManageUsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<AppUser> userAppList = await _userManager.Users.ToListAsync();
            List<UserViewModel> userList = new List<UserViewModel>();

            foreach (AppUser user in userAppList)
            {
                UserViewModel buffUser = new UserViewModel();
                buffUser.UserId = user.Id;
                buffUser.Email = user.Email;
                buffUser.FirstName = user.FirstName;
                buffUser.LastName = user.LastName;
                buffUser.Roles = await _userManager.GetRolesAsync(user);
                userList.Add(buffUser);
            }

            return View(userList);
        }

        public async Task<IActionResult> Details(string id)
        {
            if( id == null)
            {
                return NotFound();
            }

            AppUser? userApp = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if(userApp == null )
            {
                return NotFound();
            }

            UserViewModel buffUser = new UserViewModel();
            buffUser.UserId = userApp.Id;
            buffUser.Email = userApp.Email;
            buffUser.FirstName = userApp.FirstName;
            buffUser.LastName = userApp.LastName;
            buffUser.Roles = await _userManager.GetRolesAsync(userApp);

            return View(buffUser);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser? userApp = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (userApp == null)
            {
                return NotFound();
            }

            UserRoleViewModel buffUser = new UserRoleViewModel();
            buffUser.UserId = userApp.Id;
            buffUser.Email = userApp.Email;
            var buffAllRoles = await _roleManager.Roles.ToListAsync();
            var buffUserRoles = await _userManager.GetRolesAsync(userApp);
            foreach (var item in buffAllRoles)
            {
                RoleVM buffRole = new RoleVM();
                buffRole.Name = item.Name;
                if (buffUserRoles.Contains(item.Name)) buffRole.Selected = true;
                    else buffRole.Selected = false;
                buffUser.Roles.Add(buffRole);
            }

            return View(buffUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("UserId,Email,Roles")] UserRoleViewModel user)
        {
            if (ModelState.IsValid)
            {
                AppUser? myUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == user.UserId);

                if (myUser == null) return RedirectToAction("Index");

                List<string> rolesToRemove = new List<string>();
                List<string> rolesToAdd = new List<string>();

                foreach (var item in user.Roles)
                {
                    if (!item.Selected && await _userManager.IsInRoleAsync(myUser, item.Name))
                    {
                        rolesToRemove.Add(item.Name);
                    }
                    else if (item.Selected && await _userManager.IsInRoleAsync(myUser, item.Name) == false)
                    {
                        rolesToAdd.Add(item.Name);
                    }
                }

                if (rolesToAdd.Count > 0) await _userManager.AddToRolesAsync(myUser, rolesToAdd);
                if (rolesToRemove.Count > 0) await _userManager.RemoveFromRolesAsync(myUser, rolesToRemove);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            RegisterUserVM newUser = new RegisterUserVM();
            var buffAllRoles = await _roleManager.Roles.ToListAsync();

            foreach (var item in buffAllRoles)
            {
                RoleVM buffRole = new RoleVM();
                buffRole.Name = item.Name;
                buffRole.Selected = false;
                newUser.Roles.Add(buffRole);
            }

            return View(newUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterUserVM userModel)
        {
            if( ModelState.IsValid )
            {
                AppUser user = new AppUser { UserName = userModel.Email, Email = userModel.Email, FirstName = userModel.FirstName, LastName = userModel.LastName };
                IdentityResult result = await _userManager.CreateAsync(user, userModel.Password);

                if( result.Succeeded )
                {
                    List<string> rolesToAdd = new List<string>();
                    foreach (var item in userModel.Roles)
                    {
                        if( item.Selected ) rolesToAdd.Add(item.Name);
                    }

                    if( rolesToAdd.Count > 0 ) await _userManager.AddToRolesAsync(user, rolesToAdd);
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser? userApp = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (userApp == null)
            {
                return NotFound();
            }

            UserViewModel buffUser = new UserViewModel();
            buffUser.UserId = userApp.Id;
            buffUser.Email = userApp.Email;
            buffUser.FirstName = userApp.FirstName;
            buffUser.LastName = userApp.LastName;
            buffUser.Roles = await _userManager.GetRolesAsync(userApp);

            return View(buffUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser? userApp = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (userApp == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(userApp);

            if (result.Succeeded) return RedirectToAction("Index");
            else return NotFound();
        }
    }
}
