using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var values = _addressService.GetListAll();
            return View(values);
        }

       
        [HttpGet]
        public IActionResult UpdateAddress(int id)
        {
            var result = _addressService.GetById(id);
            return View(result);
        }


        [HttpPost]
        public IActionResult UpdateAddress(Address address)
        {
            AddressValidator validationRules = new AddressValidator();
            ValidationResult validationResult = validationRules.Validate(address);

            if (validationResult.IsValid)
            {
                _addressService.Update(address);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();



        }
    }
}
