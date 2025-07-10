using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
