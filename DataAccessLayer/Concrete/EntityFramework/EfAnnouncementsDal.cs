using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAnnouncementsDal : GenericRepository<Announcement>, IAnnouncementsDal
    {
        public void AnnouncementStatus(int id)
        {
            using var context = new AgriCultureContext();
            Announcement announcement = context.Announcements.Find(id);
            if (announcement.Status == true)
            {
                announcement.Status = false;
            }
            else
            {
                announcement.Status = true;
            }
            context.SaveChanges();
        }

        public void AnnouncementStatusToFalse(int id)
        {
            using var context = new AgriCultureContext();
            var values = context.Announcements.Where(x => x.AnnouncementID == id).FirstOrDefault();
            values.Status = false;
            context.SaveChanges();
        }

        public void AnnouncementStatusToTrue(int id)
        {
            using var context = new AgriCultureContext();
            var values = context.Announcements.Where(x => x.AnnouncementID == id).FirstOrDefault();
            values.Status = true;
            context.SaveChanges();
        }
    }
}
