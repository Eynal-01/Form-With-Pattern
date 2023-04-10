using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_With_Pattern.ViewModels
{
    public class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Speciality { get; set; }
        public override string ToString()
        {
            return $"{Name} - {Surname} - {Speciality} - {Age}";
        }
    }
}
