using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.class_123_in_CSharp
{
    public class BoolToString
    {
        const int MaxCount = 6;
      
           public void ConvertBoolToString(bool input)
            {
                string variableToString = input.ToString();
                Console.WriteLine(variableToString);
            }
        
    }
}
