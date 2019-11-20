using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationProject.Identity;

namespace StudentAutomationProject.Controllers
{
    
    public class BaseController : Controller
    {
        protected UserManager<SapIdentityUser> _userManager { get; }
        protected SignInManager<SapIdentityUser> _signInManager { get; }
        protected RoleManager<SapIdentityRole> _roleManager { get; }
        public BaseController(UserManager<SapIdentityUser> userManager, SignInManager<SapIdentityUser> signInManager, RoleManager<SapIdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        protected SapIdentityUser CurrentUser => _userManager.FindByNameAsync(User.Identity.Name).Result;
        //public SapIdentityUser CurrentUser()
        //{
        //    return _userManager.FindByNameAsync(User.Identity.Name).Result;
        //        }
    }
}