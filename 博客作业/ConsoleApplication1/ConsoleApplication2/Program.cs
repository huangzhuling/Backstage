using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Models;
using ConsoleApplication2.BussinessLayer;

namespace ConsoleApplication2
{
    public class Program
    {
        static void Main(string[] args)
        {
            //createClassName();
            //QueryClassName();
            //Update();
            QueryClassName();
            Delete();
            QueryClassName();
            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
        //增加
        static void createClassName()
        {
            Console.WriteLine("输入一个班级名称");
            string name = Console.ReadLine();
            ClassName CN = new ClassName();
            CN.Name = name;
            BloBussinessLayer bbl = new BloBussinessLayer();
            bbl.Add(CN);
        }
        //显示全部博客
        static void QueryClassName()
        {
            BloBussinessLayer bbl = new BloBussinessLayer();
            var ClassNames = bbl.Query();
            foreach (var item in ClassNames)
            {
                Console.Write(item.ClassNameId + " ");
                Console.WriteLine(item.Name);
            }
        }
        //更新
        static void Update()
        {
            Console.WriteLine("请输入ID：");
            int id = int.Parse(Console.ReadLine());
            BloBussinessLayer bbl = new BloBussinessLayer();
            ClassName CN = bbl.Query(id);
            Console.WriteLine("请输入新名字：");
            string name = Console.ReadLine();
            CN.Name = name;
            bbl.Update(CN);
        }
        //删除
        static void Delete()
        {
            BloBussinessLayer bbl = new BloBussinessLayer();
            Console.WriteLine("请输入id");
            int id = int.Parse(Console.ReadLine());
            ClassName CN = bbl.Query(id);
            bbl.Delete(CN);
        }

    }
}
