using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace REPRECORD_HACKLYTICS
{
    internal class GymUser
    {
        string  Name { get; set; }

        int Age { get; set; }


        double Weight { get; set; }


        double BenchPR { get; set; }    

        double SquatPR { get; set; }

        double CardioPR { get; set; }


        public GymUser(string name, int age, double weight, double benchpr, double squatpr, double cardiopr)
        {

            Name= name;
            Age = age;
            Weight = weight;
            BenchPR= benchpr;
            SquatPR= squatpr;
            CardioPR= cardiopr;
        }

        public override string ToString()
        {
            return Name.PadRight(17) + "\t" + "\t" +Age+"\t"+"\t"+ Weight + "\t" + "\t" + BenchPR + "\t" + "\t" +"\t"+ SquatPR +"\t"+"\t"+"\t"+ CardioPR;

        }


    }
}
