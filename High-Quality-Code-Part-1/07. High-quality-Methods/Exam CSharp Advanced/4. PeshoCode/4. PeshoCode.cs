using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.PeshoCode
{
    class Program
    {
        static void Main()
        {
            int result = 0;
            string word = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            string[] text = new string[row];
            string sentence = string.Empty;
            string clearSentence = string.Empty;
            //string[] sentences = new string[500];
            for (int i = 0; i < row; i++)
            {
                text[i] = Console.ReadLine();
            }
            for (int i = 0; i < row; i++)
            {
                sentence += text[i];
            }
            int startInd = 0;
            int endInd = 0;
            int secondEndInd = 0;
            bool isDot = true;
            //for (int i = 0; i < sentence.Length; i++)
            //{
                startInd = 0;
                startInd = sentence.IndexOf(word, startInd);
                endInd = sentence.IndexOf('.', startInd);
                secondEndInd = sentence.IndexOf('?', startInd);
                if (endInd > secondEndInd && secondEndInd != -1)
                {
                    endInd = secondEndInd;
                    isDot = false;
                }
            if (isDot)
            {
                endInd = startInd;
                int temtSecStartInd = sentence.LastIndexOf(".", startInd);
                int tempStartInd = sentence.LastIndexOf("?", startInd);
                startInd = Math.Max(tempStartInd, temtSecStartInd);
                if (startInd < 0)
                {
                    startInd = 0;
                }
                clearSentence = sentence.Substring(startInd + 1, (endInd - startInd) - 1);
            }
            else
            {

                clearSentence = sentence.Substring((startInd + word.Length), (endInd - (startInd + word.Length)));

            }
            clearSentence = clearSentence.ToUpper();
            for (int i = 0; i < clearSentence.Length; i++)
            {
                if (clearSentence[i] != ' ')
                {
                    result += (int)clearSentence[i];
                }
                
            }

            Console.WriteLine(result);
        }
    }
}
