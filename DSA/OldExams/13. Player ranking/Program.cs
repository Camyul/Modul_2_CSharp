using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _13.Player_ranking
{
    public class Player 
    {
        private string name;
        private string type;
        private int age;
        //private int position;

        public Player(string name, string type, int age)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (0 < value.Length && value.Length <= 20)
                {
                    this.name = value;
                }
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (0 < value.Length && value.Length <= 10)
                {
                    this.type = value;
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (10 < value && value <= 50)
                {
                    this.age = value;
                }
            }
        }
        //public int Position
        //{
        //    get
        //    {
        //        return this.position;
        //    }

        //    set
        //    {
        //        if (0 < value)
        //        {
        //            this.position = value;
        //        }
        //    }
        //}

        //public int CompareTo(object obj)
        //{
        //    Player other = obj as Player;

        //    return this.Position - other.Position;
        //}

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append("(");
            sb.Append(this.Age);
            sb.Append(")");
            return sb.ToString();
        }
    }
    class Program
    {
        static BigList<Player> collection = new BigList<Player>();

        static void Main()
        {
            string[] parseCommand = new string[5];
            //SortedSet<Player> collection = new SortedSet<Player>();
            Queue<string[]> listCommands = new Queue<string[]>();

            do
            {
                parseCommand = Console.ReadLine().Split(' ').ToArray();

                if (parseCommand[0] == "end")
                {
                    break;
                }

                listCommands.Enqueue(parseCommand);

            } while (true);

           while(listCommands.Count > 0)
            {
                var command = listCommands.Dequeue();

                if (command[0] == "add")
                {
                    AddPlayerToCollection(command);
                }
                else if (command[0] == "find")
                {
                    FindPlayersByType(command);
                }
                else if (command[0] == "ranklist")
                {
                    int start = int.Parse(command[1]);
                    int end = int.Parse(command[2]);
                    Ranklist(start, end);
                }

            }

            // Console.WriteLine(string.Join(" ", collection));
        }

        private static void Ranklist(int start, int end)
        {
            //var result = new List<Player>();
            var result = new StringBuilder();

            for (int i = 0; i < end; i++)
            {
                result.Append(string.Format("{0}. ", i + 1));
                result.Append(collection[i].ToString());
                

                if (i < end - 1)
                {
                    result.Append("; ");
                }
            }

            Console.WriteLine(result.ToString());
        }

        private static void FindPlayersByType(string[] command)
        {
            //var result = new List<Player>();
            string type = command[1];

            var result = collection
                    .Where(x => x.Type == type)
                    .OrderBy(x => x.Name)
                    .ThenByDescending(x => x.Age)
                    .Take(5)
                    .ToList();

            Console.Write("Type {0}: ", type);
            Console.WriteLine(string.Join("; ", result));
        }

        private static void AddPlayerToCollection(string[] parseCommand)
        {
            Player newPlayer = new Player(parseCommand[1], parseCommand[2], int.Parse(parseCommand[3]));
            int position = int.Parse(parseCommand[4]);

            if (collection.Count < position)
            {
                collection.Add(newPlayer);
            }
            else
            {
                collection.Insert(position - 1, newPlayer);
            }

            Console.WriteLine("Added player {0} to position {1}", newPlayer.Name, position);
        }
    }
}

/*
add Ivan Aggressive 20 1
add Pesho Defensive 25 2
add Georgi Neutral 30 3
add Stamat Aggressive 22 2
add Stamat Aggressive 40 1
find Aggressive
add Pencho Neutral 33 2
find Neutral
end

add Ivan Aggressive 20 1
add Pesho Defensive 25 2
add Georgi Neutral 30 3
add Stamat Aggressive 22 2
add Stamat Aggressive 40 1
find Aggressive
ranklist 1 5
add Pencho Neutral 33 2
find Neutral
ranklist 1 3
end
 */
