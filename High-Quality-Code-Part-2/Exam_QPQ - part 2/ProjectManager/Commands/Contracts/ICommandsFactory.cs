using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager.Commands.Contracts
{
    public interface ICommandsFactory
    {
        /// <summary>
        /// ModelsFactory property
        /// </summary>
        ModelsFactory ModelsFactory { get; set; }

        /// <summary>
        /// Database property
        /// </summary>
        Database Db { get; set; }

        /// <summary>
        /// Call necessary class
        /// </summary>
        /// <param name="commandName">Name of the necessary class</param>
        /// <returns>ICommand</returns>
        ICommand CreateCommandFromString(string commandName);
    }
}