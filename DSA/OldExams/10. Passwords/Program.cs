using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Passwords
{
    class Program
    {
        static int counter;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string relations = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());

            counter = k;
            //GenPasswords("", relations);

            char[] password = new char[n];
            Recursion(password, 0, relations);
        }

        // Slowlest 96/100
        static void GenPasswords(string pass, string relations)
        {
            

            if (pass == string.Empty)
            {
                for (int i = 0; i <= 9; i++)
                {
                    GenPasswords(i.ToString(), relations);
                }
                return;
            }

            int index = pass.Length - 1;

            if (index >= relations.Length)
            {
                counter--;
                if (counter == 0)
                {
                    Console.WriteLine(pass);
                }
                
                return;
            }

            if (counter < 0)
            {
                return;
            }

            if (relations[index] == '=')
            {
                GenPasswords(pass + pass[index], relations);
            }
            else if (relations[index] == '<')
            {
                char last = pass[index] == '0' ? '9' : (char)(pass[index] - 1);

                for (char c = '1'; c <= last; c++)
                {
                    GenPasswords(pass + c, relations);
                }
            }
            else if(pass[index] != '0')
            {
                GenPasswords(pass + '0', relations);

                for (char c = (char)(pass[index] + 1); c <= '9'; c++)
                {
                    GenPasswords(pass + c, relations);
                }
            }
        }

        static void Recursion(char[] pass, int index, string relations)
        {
            if (index == 0)
            {
                for (char c = '0'; c <= '9'; c++)
                {
                    pass[0] = c;
                    Recursion(pass, 1, relations);
                }
                return;
            }

            if (index - 1 >= relations.Length)
            {
                counter--;
                if (counter == 0)
                {
                    Console.WriteLine(string.Join("", pass));
                }
                return;
            }

            if (counter <= 0)
            {
                return;
            }

            if (relations[index - 1] == '=')
            {
                pass[index] = pass[index - 1];
                Recursion(pass, index + 1, relations);
            }
            else if (relations[index - 1] == '<')
            {
                char last = pass[index - 1] == '0' ? '9' : (char)(pass[index - 1] - 1);

                for (char c = '1'; c <= last; c++)
                {
                    pass[index] = c;
                    Recursion(pass, index + 1, relations);
                }
            }
            else if (pass[index - 1] != '0')
            {
                pass[index] = '0';
                Recursion(pass, index + 1, relations);

                for (char c = (char)(pass[index - 1] + 1); c <= '9'; c++)
                {
                    pass[index] = c;
                    Recursion(pass, index + 1, relations);
                }
            }
        }
    }
}
