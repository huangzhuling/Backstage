using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.BussinessLayer;
using ConsoleApplication1.DataAccessLayer;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            QueryPostForTitle();

            //NewMethod();
        }

        private static void NewMethod()
        {
            //显示所有博客
            Console.WriteLine("所有博客：");
            QueryBlog();
            Console.WriteLine("-1-退出 -2-新增博客 -3-更改博客 -4-删除博客 -5-操作帖子");
            Console.WriteLine("请输入操作指令");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                Environment.Exit(0);
                return;
            }

            else if (i == 2)
            {
                createBlog();
                QueryBlog();
                Console.Clear(); NewMethod();

            }
            else if (i == 3)
            {
                Update();
                QueryBlog();
                Console.Clear();
                NewMethod();

            }
            else if (i == 4)
            {
                Delete();
                QueryBlog();
                Console.Clear();
                NewMethod();

            }
            else if (i == 5)
            {
                int blogid = GeBlogId();
                Console.WriteLine(blogid);
                //显示指定博客的帖子列表
                DisplayPosts(blogid);
                //清楚控制台信息
                Console.Clear();
                Console.WriteLine("-0-返回上一层 -1-新增帖子 -2-更改帖子 -3-删除帖子");
                int A = int.Parse(Console.ReadLine());
                if (A == 0)
                {
                    NewMethod();
                    Console.Clear();
                    Console.WriteLine("所有博客：");
                    QueryBlog();
                    Console.WriteLine("-1-退出 -2-新增博客 -3-更改博客 -4-删除博客 -5-操作帖子");
                    return;
                }
                else if (A == 1)
                {
                    createPost(blogid);
                    DisplayPosts(blogid);
                    Console.WriteLine("新增成功");
                }
                else if (A == 2)
                {
                    UpdatePost();
                    DisplayPosts(blogid);
                    Console.WriteLine("修改成功");

                }
                else if (A == 3)
                {
                    DeletePost();
                    DisplayPosts(blogid);
                    Console.WriteLine("删除成功");
                }
            }
            else
            {
                Console.WriteLine("无效字符");
                return;
            }
        }

        
        static void QueryPostForTitle()
        {
            Console.WriteLine("输入要查找的博客：");
            string name = Console.ReadLine();
            BloBussinessLayer bbl = new BussinessLayer.BloBussinessLayer();
            var query = bbl.QueryForTitle(name);

            foreach (var item in query)
            {
                Console.WriteLine(item.Title+" "+item.Content);
            }
        }


        static void AddPost()
        {
            //显示博客列表
            //QueryBlog();
            //用户选择某个博客（id）
            int blogId = GeBlogId();
            //显示指定博客的帖子列表
            DisplayPosts(blogId);
            //根据指定到博客信息创建新帖子 
            //createPost(blogId);
            //DeletePost();
            //DisplayPosts(blogId);
            UpdatePost();
            DisplayPosts(blogId);
            //显示指定博客的帖子列表
        }
        static int GeBlogId()
        {
            Console.WriteLine("请输入ID：");
            int id = int.Parse(Console.ReadLine());
            return id;
        }
        //显示指定帖子列表
        static void DisplayPosts(int blogId)
        {
            Console.WriteLine(blogId + "的帖子列表：");
            List<Post> list = null;
            //根据博客Id获取博客
            using (var db=new BloggingContext())
            {
                Blog blog = db.Blogs.Find(blogId);
                //根据博客导航属性，获取所有该博客的帖子
                list = blog.Posts;
            }
            //遍历所有帖子，显示帖子标题（博客号-帖子标题）
            foreach(var item in list)
            {
                Console.WriteLine(item.Blog.BlogId + "--" + item.Title+"--"+item.Content+ "--" + item.PostId);
            }
            
        }
        //新增帖子
        static void createPost(int blogId)
        {
            Console.WriteLine("请创建新帖子：");
            string title = Console.ReadLine();
            Console.WriteLine("请输入帖子的内容");
            string content = Console.ReadLine();
            Post post = new Post();
            post.BlogId = blogId;
            post.Title = title;
            post.Content = content;
            BloBussinessLayer bbl = new BloBussinessLayer();
            bbl.Add(post);

        }
        //删除帖子
        static void DeletePost()
        {
            BloBussinessLayer bbl = new BloBussinessLayer();
            Console.WriteLine("请输入要删除的帖子:");
            int id = int.Parse(Console.ReadLine());
            Post post = bbl.Querypost(id);
            bbl.Delete(post);
        }
        //更新帖子
        static void UpdatePost()
        {
            Console.WriteLine("输入帖子Id：");
            int id = int.Parse(Console.ReadLine());
            BloBussinessLayer bbl = new BloBussinessLayer();
            Post post = bbl.Querypost(id);
            Console.WriteLine("输入新的帖子:");
            string content = Console.ReadLine();
            string title = Console.ReadLine();
            //int blogId = int.Parse(Console.ReadLine());
            //post.BlogId = blogId;
            post.Title = title;
            post.Content = content;
            bbl.Update(post);
        }
        //增加--交互
        static void createBlog()
        {
            Console.WriteLine("请输入一个博客名称");
            string name = Console.ReadLine();
            Blog blog = new Blog();
            blog.Name = name;
            BloBussinessLayer bbl = new BloBussinessLayer();
            bbl.Add(blog); 

        }

        //显示全部博客
        static void QueryBlog()
        {
            BloBussinessLayer bbl = new BloBussinessLayer();
            var blogs = bbl.Query();
            foreach(var item in blogs)
            {
                Console.Write(item.BlogId+" ");
                Console.WriteLine(item.Name);
            }
        }
        //更新
        static void Update()
        {
            Console.WriteLine("请输入ID：");
            int id = int.Parse(Console.ReadLine());
            BloBussinessLayer bbl = new BloBussinessLayer();
            Blog blog = bbl.Query(id);
            Console.WriteLine("请输入新名字：");
            string name = Console.ReadLine();
            blog.Name = name;
            bbl.Update(blog);
        }

        //删除
        static void Delete()
        {
            BloBussinessLayer bbl = new BloBussinessLayer();
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            Blog blog = bbl.Query(id);
            bbl.Delete(blog);
        }

    }
}
