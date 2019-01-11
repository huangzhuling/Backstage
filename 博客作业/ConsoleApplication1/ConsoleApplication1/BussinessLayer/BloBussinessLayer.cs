using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.DataAccessLayer;
using System.Data.Entity;

namespace ConsoleApplication1.BussinessLayer
{
    public class BloBussinessLayer
    {
        public void Add(Blog blog)
        {
            using (var db=new BloggingContext())
            {
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }
        public List<Blog> Query()
        {
            using (var db=new BloggingContext())
            {
                return db.Blogs.ToList();
            }
        }
        public Blog Query(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Blogs.Find(id);
            }
        }
        public void Update(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void Delete(Blog blog)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(blog).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Add(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public List<Post> Querypost()
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.ToList();
            }
        }
        public Post Querypost(int id)
        {
            using (var db = new BloggingContext())
            {
                return db.Posts.Find(id);
            }
        }

        public void Delete(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Update(Post post)
        {
            using (var db = new BloggingContext())
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        public List<Post>QueryForTitle(string title)
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Posts
                            where b.Title == title
                            select b;
                return query.ToList();
            }
        }
    }
}
