using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAdressDal:IGenericDal<Address>//generic daldan miras alıyoruz ve adress sınıfını generic dal ile kullanıyoruz
    {
    }
}
