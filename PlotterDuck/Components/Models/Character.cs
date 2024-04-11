using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterDuck.Components.Models
{
    public class Character
    {
        public int Id;
        string fName;
        string lName;
        int age;
        string race;

        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public int Age { get => age; set => age = value; }
        public string Race { get => race; set => race = value; }
    }
}
