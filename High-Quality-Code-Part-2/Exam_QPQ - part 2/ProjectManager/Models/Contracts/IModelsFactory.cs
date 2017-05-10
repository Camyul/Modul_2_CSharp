namespace ProjectManager.Models.Contracts
{
    public interface IModelsFactory
    {
        /// <summary>
        /// Create Task for the project
        /// </summary>
        /// <param name="owner">The task executor</param>
        /// <param name="name">Name of the Task</param>
        /// <param name="state">Status of the Task</param>
        /// <returns></returns>
        Task CreateTask(User owner, string name, string state);

        /// <summary>
        /// Create user for the project
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="email">E-mail of the user</param>
        /// <returns></returns>
        User CreateUser(string username, string email);
    }
}