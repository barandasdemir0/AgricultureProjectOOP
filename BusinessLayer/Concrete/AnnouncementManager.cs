using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementsService
    {
        private readonly IAnnouncementsDal _announcementsDal;

        public AnnouncementManager(IAnnouncementsDal announcementsDal)
        {
            _announcementsDal = announcementsDal;
        }

        public void AnnouncementStatus(int id)
        {
            _announcementsDal.AnnouncementStatus(id);
        }

        public void AnnouncementStatusToFalse(int id)
        {
            _announcementsDal.AnnouncementStatusToFalse(id);
        }

        public void AnnouncementStatusToTrue(int id)
        {
            _announcementsDal.AnnouncementStatusToTrue(id);
        }

        public void Delete(Announcement t)
        {
            _announcementsDal.Delete(t);
        }

        public Announcement GetById(int id)
        {
            return _announcementsDal.GetById(id);
        }

        public List<Announcement> GetListAll()
        {
            return _announcementsDal.GetListAll();
        }

        public void Insert(Announcement t)
        {
            _announcementsDal.Insert(t);
        }

        public void Update(Announcement t)
        {
            _announcementsDal.Update(t);
        }
    }
}
