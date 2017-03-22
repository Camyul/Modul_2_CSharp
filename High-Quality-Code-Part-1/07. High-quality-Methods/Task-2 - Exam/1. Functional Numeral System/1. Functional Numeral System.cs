﻿namespace Functional_Numeral_System
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Program
    {
        internal static void Main()
        {
            string[] separator = { ", " };
            string[] input = Console.ReadLine().Split(separator, StringSplitOptions.None);
            string[] encodeWords = 
                {
                "ocaml", "haskell", "scala", "f#", "lisp", "rust", "ml", "clojure", "erlang",
                "standardml", "racket", "elm",  "mercury",  "commonlisp", "scheme", "curry"
                };
            StringBuilder encodeDigit = new StringBuilder();
            List<string> encodeWorsdList = new List<string>();
            long result = 1;
            for (int i = 0; i < input.Length; i++)
            {
                int index = 0;
                for (int j = 0; j < encodeWords.Length; j++)
                {
                    index = 0;
                    index = input[i].IndexOf(encodeWords[j], index);
                    if (index != -1 && index < 1)
                    {
                        encodeWorsdList.Add(input[i].Substring(index, encodeWords[j].Length));
                        input[i] = input[i].Remove(index, encodeWords[j].Length);
                        j = 0;
                        if (input[i].Length < 1)
                        {
                            break;
                        }
                    }
                    else
                    {
                        index++;
                    }
                }

                ConvertToHex(encodeWords, encodeDigit, encodeWorsdList);
                result *= Convert.ToInt64(encodeDigit.ToString(), 16);
                encodeDigit.Clear();
                encodeWorsdList.Clear();
            }

            Console.WriteLine(result);
        }

        private static void ConvertToHex(string[] encodeWords, StringBuilder encodeDigit, List<string> encodeWorsdList)
        {
            for (int i = 0; i < encodeWorsdList.Count; i++)
            {
                for (int j = 0; j < encodeWords.Length; j++)
                {
                    if (encodeWorsdList[i] == encodeWords[j])
                    {
                        if (j < 9)
                        {
                            encodeDigit.Append(j.ToString());
                        }
                        else
                        {
                            switch (j)
                            {
                                case 10:
                                    encodeDigit.Append("A");
                                    break;
                                case 11:
                                    encodeDigit.Append("B");
                                    break;
                                case 12:
                                    encodeDigit.Append("C");
                                    break;
                                case 13:
                                    encodeDigit.Append("D");
                                    break;
                                case 14:
                                    encodeDigit.Append("E");
                                    break;
                                case 15:
                                    encodeDigit.Append("F");
                                    break;
                                default:
                                    break;
                            }
                        }

                        break;
                    }
                }
            }
        }
    }
}
