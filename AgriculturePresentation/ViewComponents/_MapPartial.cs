using BusinessLayer.Abstract;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _MapPartial:ViewComponent
    {
       

        public IViewComponentResult Invoke()
        {
            AgriCultureContext agriCultureContext = new AgriCultureContext();
            var values = agriCultureContext.Addresses.Select(x => x.Mapinfo).FirstOrDefault();
            ViewBag.v = values;
            return View();
        }
    }
}
