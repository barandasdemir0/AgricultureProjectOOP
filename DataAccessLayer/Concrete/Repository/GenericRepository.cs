﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()  // buranın amacı generic bir repository oluşturmak ve generic dal ile kullanmak
    {
        public void Delete(T t)
        {
            using var context = new AgriCultureContext();
            context.Remove(t); // T tipindeki nesneyi siler
            context.SaveChanges();
        }

        public T GetById(int id)
        {
            using var context = new AgriCultureContext();
            return context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var context = new AgriCultureContext();
            return context.Set<T>().ToList(); // T tipindeki nesneleri liste olarak döndürür
        }

        public void Insert(T t)
        {
            using var context = new AgriCultureContext();
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using var context = new AgriCultureContext();
            context.Update(t);
            context.SaveChanges();
        }
    }
}
