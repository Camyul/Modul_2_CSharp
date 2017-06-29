namespace _08.MatrixPassChecker
{
    internal static class StartUp
    {
        static void Main()
        {
            char[,] matrix =
           {
                {'0', '0', '0', '*', '0', '0', '0'},
                {'*', '*', '0', '*', '0', '*', '0'},
                {'0', '0', '0', '0', '0', '0', '0'},
                {'0', '*', '*', '*', '*', '*', '0'},
                {'0', '0', '0', '0', '0', '0', 'e'},
            };

            char[,] matrix1 =
            {
                {'0', '0', '0'},
                {'0', '0', '0'},
                {'0', '0', 'e'},
            };

            //char[,] matrix2 = new char[100, 100];
            //matrix2[99, 99] = 'e';

            var lab = new Labyrinth(matrix1);
            lab.FindPaths(0, 0, 'R');
        }
    }
}
