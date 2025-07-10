using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _AddressPartial:ViewComponent
    {
        private readonly IAddressService _addressService;

        public _AddressPartial(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _addressService.GetListAll();
            return View(result);
        }
    }
}
