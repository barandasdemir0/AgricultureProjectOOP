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
    public class AboutManager : IAboutService
    {
        IAboutDal _AboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _AboutDal = aboutDal;
        }

        public void Delete(About t)
        {
            _AboutDal.Delete(t);
        }

        public About GetById(int id)
        {
            return _AboutDal.GetById(id);
        }

        public List<About> GetListAll()
        {
            return _AboutDal.GetListAll();
        }

        public void Insert(About t)
        {
            _AboutDal.Insert(t);
        }

        public void Update(About t)
        {
            _AboutDal.Update(t);
        }
    }
}
