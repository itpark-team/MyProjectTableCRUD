using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectTableCRUD
{
    public struct MenuItem
    {
        public int Id;
        public string Name;
        public string Description;
        public bool IsFocus { get; set; } = false;


        public MenuItem(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        
    }
}
