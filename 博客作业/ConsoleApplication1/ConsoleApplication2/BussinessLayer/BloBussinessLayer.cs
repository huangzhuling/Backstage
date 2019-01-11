using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Models;
using ConsoleApplication2.DataAccessLayer;
using System.Data.Entity;

namespace ConsoleApplication2.BussinessLayer
{
    public class BloBussinessLayer
    {
        public void Add(ClassName CN)
        {
            using (var db = new BloggingContext())
            {
                db.ClassNmaes.Add(CN);
                db.SaveChanges();
            }
        }
        public List<ClassName> Query()
        {
            using (var db = new BloggingContext())
            {
                return db.ClassNmaes.ToList();
            }
        }
        public ClassName Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.ClassNmaes.Find(id);
            }
        }
        public void Update(ClassName blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(ClassName CN)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(CN).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
