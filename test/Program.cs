using System;
using System.Collections.Generic;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuLogick logick = new MenuLogick();
            logick.Test();
        }
    }

    public class MenuLogick
    {
        //public MenuLogick()
        //{
        //    list = new List<MenuItem>()
        //    {
        //        new MenuItem(name: "Load"),
        //        new MenuItem(name: "Save"),
        //        new MenuItem(name: "Delete"),
        //        new MenuItem(name: "Edit"),
        //        new MenuItem(name: "Exit")
        //    };
        //}

        //public Menu menuList;
        public List<MenuItem> list = new List<MenuItem>()
        {
            new MenuItem(name: "Load"),
            new MenuItem(name: "Save"),
            new MenuItem(name: "Delete"),
            new MenuItem(name: "Edit"),
            new MenuItem(name: "Exit")
        };

        private void Initialize(ref List<MenuItem> li )
        {
            var tmp = li[0];
            tmp.IsFocus = true;
            li[0] = tmp;
        }
        public void Test()
        {
            Initialize(ref list);
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].IsFocus);
            }
            foreach (var tmp in list)
            {
                Console.WriteLine(tmp.IsFocus);
            }
        }
    }


    public struct MenuItem
    {
        public string Name;
        public bool IsFocus { get; set; }
        public MenuItem( string name, bool isFocus = false)
        {
            Name = name;
            IsFocus = isFocus;
        }
    }

    //public struct Menu
    //{
    //    public List<MenuItem> Items
    //    {
    //        get
    //        {
    //            if (items.Count == 0)
    //            {
    //                items.AddRange(itemsArray);
    //            }
    //            return items;
    //        }
    //    }
    //    static private List<MenuItem> items = new List<MenuItem>() { };
    //    static private MenuItem[] itemsArray = new[]
    //    {
    //        new MenuItem( name: "Load"  ),
    //        new MenuItem( name: "Save" ),
    //        new MenuItem( name: "Delete" ),
    //        new MenuItem( name: "Edit" ),
    //        new MenuItem( name: "Exit" )
    //    };
    //}
}
