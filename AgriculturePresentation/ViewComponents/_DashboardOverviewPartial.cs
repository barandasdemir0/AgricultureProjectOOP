using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial : ViewComponent
    {
        AgriCultureContext c = new AgriCultureContext();
        public IViewComponentResult Invoke()
        {

            ViewBag.teamCount = c.Teams.Count();
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount = c.Contacts.Count();
            ViewBag.currentMonthMessage = c.Contacts
                .Where(x => x.Date.Month == DateTime.Now.Month && x.Date.Year == DateTime.Now.Year)
                .Count();
            ViewBag.AnnouncementTrue = c.Announcements.Select(x => x.Status == true).Count();
            ViewBag.AnnouncementFalse = c.Announcements.Select(x => x.Status == false).Count();

            ViewBag.urunpazarlama = c.Teams.Where(x => x.Title == "süt ürünleri üreticisi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.urunpazarlama2 = c.Teams.Where(x => x.Title == "süt ürünleri üreticisi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.urunpazarlama3 = c.Teams.Where(x => x.Title == "süt ürünleri üreticisi").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.urunpazarlama4 = c.Teams.Where(x => x.Title == "süt ürünleri üreticisi").Select(y => y.PersonName).FirstOrDefault();


            return View();
        }
    }
}
