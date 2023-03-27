using CoruseThree.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualBasic;
using System;
using System.Globalization;

namespace CoruseThree.Controllers
{

   // [Authorize]
   
    public class AccountController : Controller
    {

        private UserManager<IdentityUser> _userManenger;
        private SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> _RoleManenger;


        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManenger, RoleManager<IdentityRole> roleManager)
        {
            _userManenger = userManager;
            _signInManager = signInManenger;
            _RoleManenger = roleManager;
        }


        [AllowAnonymous]
        public IActionResult Rigister()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Rigister(ViewRigisterModel model)
        {
            if (ModelState.IsValid)
            {

                IdentityUser user = new IdentityUser()
                {
                    Email = model.Email,
                    UserName = model.Email, // here some speceif info
                    PhoneNumber = model.MoblieNumber

                };

                var result = await _userManenger.CreateAsync(user, model.password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);

                    }
                   // return View(model);
                }

            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(ViewLoginModel model)
        {

            if (ModelState.IsValid)
            {

                var Res = await _signInManager.PasswordSignInAsync
                     (model.Email, model.Password, model.RememberMe, false);


                if (Res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }


                else
                {
                    ModelState.AddModelError("", "Invalid in User or pass");
                    return View(model);
                }



            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        
        [HttpGet]
        
        public IActionResult RollList()
        {

            return View(_RoleManenger.Roles);
        }
        
        [HttpGet]
       
        public IActionResult CreateRole()
        {

            return View();
        }

        
        [HttpPost]
        
        public async Task<IActionResult> CreateRole(CreateRoleModelView model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.RoleName
                };

               var res = await _RoleManenger.CreateAsync(role);

                if (res.Succeeded)
                { 
                
                   return RedirectToAction("RollList");

                }

                return View(model);

            }
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var data = await _RoleManenger.FindByIdAsync(id);

            EditViewRoleModel editViewRoleModel = new EditViewRoleModel()
            {

                RoleId = data.Id,
                RoleName = data.Name
            };

            foreach(var user in _userManenger.Users)
            {
                if (await _userManenger.IsInRoleAsync(user , editViewRoleModel.RoleName))
                {

                    editViewRoleModel.UserName.Add(user.UserName);
                }


            }

            return View(editViewRoleModel);
        }



        [HttpPost]
        public async Task<IActionResult> EditRole(EditViewRoleModel Model)
        {
            if (ModelState.IsValid)
            {
                var Role = await _RoleManenger.FindByIdAsync(Model.RoleId);

                Role.Name = Model.RoleName;

                var result = await _RoleManenger.UpdateAsync(Role);

                if (result.Succeeded)
                {

                    return RedirectToAction ("RollList");

                }

                foreach (var er in result.Errors)   
                {
                    ModelState.AddModelError("", er.Description);
                
                }

            
                    return View(Model);
                



            }

            return View(Model);
        }


    }
}
