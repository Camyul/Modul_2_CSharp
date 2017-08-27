using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Hungry_Tom
{
    class Program
    {                   // Don't WORK
        public class Room
        {
            public Room(int val)
            {
                this.Val = val;
                this.Doors = new List<Door>();
            }
            public int Val { get; set; }
            public List<Door> Doors { get; set; }
        }

        public class Door
        {
            public Door(Room startRoom, Room endRoom)
            {
                this.StartRoom = startRoom;
                this.EndRoom = endRoom;
            }

            public Room StartRoom { get; set; }
            public Room EndRoom { get; set; }
        }

        static Dictionary<int, Door> graph = new Dictionary<int, Door>();

        static HashSet<Room> visited = new HashSet<Room>();

        


        static void Main()
        {
            int numberRooms = int.Parse(Console.ReadLine());
            Room[] rooms = new Room[numberRooms + 1];
            for (int i = 1; i < numberRooms + 1; i++)
            {
                Room newRoom = new Room(i);
                rooms[i] = newRoom;
            }

            int numberDoors = int.Parse(Console.ReadLine());


            for (int i = 0; i < numberDoors; i++)
            {
                int[] door = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var newDoor = new Door(rooms[door[0]], rooms[door[1]]);

                rooms[door[0]].Doors.Add(newDoor);
            }
            
            Dfs(rooms[1], rooms);

            Console.WriteLine();
        }

        public static void Dfs(Room node, Room[] rooms)
        {
            var path = new List<int>();
            path.Add(node.Val);
            visited.Add(node);
                foreach (var door in node.Doors)
                {

                    if (!visited.Contains(door.EndRoom))
                    {
                        Dfs(door.EndRoom, rooms);
            Console.WriteLine(string.Join(" ", path));        
                    }
                }
            }
        
    }
}
/*
4 
4 
1 2
2 3
3 4
4 1
*/
