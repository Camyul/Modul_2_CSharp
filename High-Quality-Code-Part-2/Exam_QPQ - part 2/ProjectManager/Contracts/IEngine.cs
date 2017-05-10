namespace ProjectManager.Contracts
{
    public interface IEngine
    {
        /// <summary>
        /// Read string from console and execute or capture exceptions and log in log.txt
        /// </summary>
        void Start();
    }
}
