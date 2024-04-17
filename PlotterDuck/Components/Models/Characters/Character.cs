using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotterDuck.Components.Models.Characters
{
    public class Character
    {
        public int Id;
        string fName;
        string lName;
        int age;

        string ch_race;
        string ch_class;
        string ch_fraction;

        string description;

        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public int Age { get => age; set => age = value; }
        public string Race { get => ch_race; set => ch_race = value; }
        public string Fraction { get => ch_fraction; set => ch_fraction = value; }
        public string Class { get => ch_class; set => ch_class = value; }
        public string Description { get => description; set => description = value; }
    }
}
