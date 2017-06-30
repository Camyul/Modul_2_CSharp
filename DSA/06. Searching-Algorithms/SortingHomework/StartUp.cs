namespace SortingHomework
{
    internal static class StartUp
    {
        static void Main()
        {
            var collection = new SortableCollection<int>(new[] { 0, 11, 22, 33, 33, 33, 101, 101 });
            int searchedIndex = collection.BinarySearch(33, 0, collection.Collection.Count);
            System.Console.WriteLine(searchedIndex);
        }
    }
}
