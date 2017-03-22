using System;

namespace PeshoCode
{
   internal class Program
    {
       internal static void Main()
        {
            int result = 0;
            string word = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            string[] text = new string[row];
            string sentence = string.Empty;
            string clearSentence = string.Empty;
            for (int i = 0; i < row; i++)
            {
                text[i] = Console.ReadLine();
            }

            for (int i = 0; i < row; i++)
            {
                sentence += text[i];
            }

            int startIndex = 0;
            int endIndex = 0;
            int secondEndInd = 0;
            bool isDot = true;
                startIndex = 0;
                startIndex = sentence.IndexOf(word, startIndex);
                endIndex = sentence.IndexOf('.', startIndex);
                secondEndInd = sentence.IndexOf('?', startIndex);
                if (endIndex > secondEndInd && secondEndInd != -1)
                {
                    endIndex = secondEndInd;
                    isDot = false;
                }

            if (isDot)
            {
                endIndex = startIndex;
                int temtSecStartInd = sentence.LastIndexOf(".", startIndex);
                int tempStartInd = sentence.LastIndexOf("?", startIndex);
                startIndex = Math.Max(tempStartInd, temtSecStartInd);
                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                clearSentence = sentence.Substring(startIndex + 1, (endIndex - startIndex) - 1);
            }
            else
            {
                clearSentence = sentence.Substring(startIndex + word.Length, endIndex - (startIndex + word.Length));
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
