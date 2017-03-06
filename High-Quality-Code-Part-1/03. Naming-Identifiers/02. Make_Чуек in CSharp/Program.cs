using Make_Чуек_in_CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make_Human_in_CSharp
{
    public class CountryClasses
    {
        static void Main()
        {

        }
      
        public void CreateHuman(int magicNumber)
        {
            Human newHuman = new Human();
            newHuman.Age = magicNumber;
            if (magicNumber % 2 == 0)
            {
                newHuman.Name = "Big Brother";
                newHuman.Gender = TypeHuman.UltraBrother;
            }
            else
            {
                newHuman.Name = "Cool Sister";
                newHuman.Gender = TypeHuman.CoolPeach;
            }
        }
    }
}
