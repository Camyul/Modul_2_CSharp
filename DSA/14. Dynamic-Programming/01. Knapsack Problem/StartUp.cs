using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.Knapsack_Problem
{
    class Product : IComparable
    {

        public Product(int weight, int cost)
        {
            this.Weight = weight;
            this.Cost = cost;
        }

        public int Weight { get; set; }
        public int Cost { get; set; }

        public int CompareTo(Object obj)
        {
            Product otherProduct = obj as Product;
            if (this.Cost > otherProduct.Cost)
            {
                return 1;
            }
            else if (this.Cost < otherProduct.Cost)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    class StartUp
    {
        static void Main()
        {
            int numberProducts = int.Parse(Console.ReadLine());
            int maxWeight = int.Parse(Console.ReadLine());
            SortedSet<Product> products = new SortedSet<Product>();
            List<int> elementsInBag = new List<int>();

            for (int i = 0; i < numberProducts; i++)
            {
                int[] parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Product newProduct = new Product(parameters[0], parameters[1]);

                products.Add(newProduct);
            }

            int result = 0;
            while (result < maxWeight)
            {
                Product element = products.Last();
               products.Remove(element);
                
                if (products.Count < 1)
                {
                    break;
                }
                else if (element.Weight + result <= maxWeight)
                {
                    result += element.Weight;
                    elementsInBag.Add(element.Weight);
                }
                
            }

            Console.WriteLine(result);
            Console.WriteLine(String.Join(" ", elementsInBag));
        }
    }
}

/*
6
10
3 2
8 12
4 5
1 4
2 3
8 13
*/