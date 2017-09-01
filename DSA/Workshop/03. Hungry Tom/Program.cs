using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Hungry_Tom
{
    class Program
    {                   
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

        static List<int[]> results = new List<int[]>();

        


        static void Main()
        {
            int numberRooms = int.Parse(Console.ReadLine());
            Room[] rooms = new Room[numberRooms + 1];
            HashSet<Room> visited = new HashSet<Room>();

            for (int i = 1; i < numberRooms + 1; i++)
            {
                Room newRoom = new Room(i);
                rooms[i] = newRoom;
            }

            int numberDoors = int.Parse(Console.ReadLine());


            for (int i = 0; i < numberDoors; i++)
            {
                int[] door = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                rooms[door[0]].Doors.Add(new Door(rooms[door[0]], rooms[door[1]]));
                rooms[door[1]].Doors.Add(new Door(rooms[door[1]], rooms[door[0]]));
            }
            var path = new int[numberRooms + 1];
            path[0] = rooms[1].Val;
           
            Dfs(rooms[1], rooms, path, 1, visited);

            Console.WriteLine(results.Count);
            foreach (var result in results)
            {
                Console.WriteLine(string.Join(" ", result));
            }
            
        }

        public static void Dfs(Room node, Room[] rooms, int[] path, int index, HashSet<Room> visited)
        {
            
            visited.Add(node);
            
            foreach (Door door in node.Doors)
            {
                path[index] = door.EndRoom.Val;

                if (door.EndRoom.Val == 1 && index == rooms.Length - 1)
                {
                    var result = path.ToArray();
                    results.Add(result);
                    return;
                }

                if (!visited.Contains(door.EndRoom))
                {
                    
                    Dfs(door.EndRoom, rooms, path, index + 1, visited);
                    visited.Remove(door.EndRoom);
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
