namespace Tasker.Core.Provider
{
    using Tasker.Core.Contracts;

    public class IdProvider : IIdProvider
    {
        private static int currentId = 0;

        public int NextId()
        {
            return currentId++;
        }
    }
}
