using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ProfileController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditView userEditView = new UserEditView();
            userEditView.Mail = values.Email;
            userEditView.Phone = values.PhoneNumber;
            return View(userEditView);
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserEditView userEditView    )
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEditView.Password == userEditView.ConfirmPassword)
            {
                values.Email = userEditView.Mail;
                values.PhoneNumber = userEditView.Phone;

                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userEditView.Password);
                var result = await _userManager.UpdateAsync(values);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }

            }
          
            return View();
        }
    }
}
