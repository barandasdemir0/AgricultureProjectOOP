using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AnnouncementsController : Controller
    {

        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementsController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

        public IActionResult Index()
        {
            var values = _announcementsService.GetListAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncements()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncements(Announcement announcements) 
        {
            announcements.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            announcements.Status = false;
            _announcementsService.Insert(announcements);
            return RedirectToAction("Index");

        }


        public IActionResult DeleteAnnouncements(int id)
        {
            var values = _announcementsService.GetById(id);
            _announcementsService.Delete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateAnnouncements(int id)
        {
            var values = _announcementsService.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncements(Announcement announcement)
        {
            _announcementsService.Update(announcement);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusTrue(int id)
        {
            _announcementsService.AnnouncementStatusToTrue(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusFalse(int id)
        {
            _announcementsService.AnnouncementStatusToFalse(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            _announcementsService.AnnouncementStatus(id);
            return RedirectToAction("Index");
        }




    }
}
