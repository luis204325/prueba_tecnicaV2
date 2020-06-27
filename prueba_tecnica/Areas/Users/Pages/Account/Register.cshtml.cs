using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using prueba_tecnica.Areas.Users.Models;
using prueba_tecnica.library;

namespace prueba_tecnica.Areas.Users.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private SignInManager<IdentityUser> _singInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private LUsersRoles _usersRole;
        private static InputModel _dataInput;

        public RegisterModel(

         SignInManager<IdentityUser> singInManager,
         UserManager<IdentityUser> userManager,
         RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _roleManager = roleManager;
            _usersRole = new LUsersRoles();

        }
        public void OnGet()
        {
            if (_dataInput != null)
            {
                Input = _dataInput;
                Input.rolesLista = _usersRole.getRoles(_roleManager);
                Input.AvatarImage = null;
            }
            else {
                Input = new InputModel
                {
                    rolesLista = _usersRole.getRoles(_roleManager)
                };
            }

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel : InputModelRegister
        {
            public IFormFile AvatarImage { get; set; }
            public string ErrorMessage { get; set; }

            public List<SelectListItem> rolesLista { get; set; }
        }

        public async Task<IActionResult> OnPost()
        {
            if (await SaveAsync())
            {
                return Redirect("/Users/Users?area=Users");
            }
            else
            {
                return Redirect("/Users/Register");
            }

           
        }

        public async Task<bool> SaveAsync() 
        {
            _dataInput = Input;
            var valor = false;

            return valor;
        }

    }
}
