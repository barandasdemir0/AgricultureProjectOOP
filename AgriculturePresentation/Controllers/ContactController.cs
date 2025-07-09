using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.GetListAll();
            return View(values);
        }


        [HttpGet]
        public IActionResult DeleteMessage(int id)
        {
            var result = _contactService.GetById(id);
            _contactService.Delete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DetailsContact(int id)
        {
            var result = _contactService.GetById(id);
            return View(result);
        }


    }
}
