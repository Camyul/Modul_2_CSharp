namespace Tasker.Tests.Core.TaskManagerTests.Fakes
{
    using System.Collections.Generic;
    using Tasker.Core;
    using Tasker.Core.Contracts;
    using Tasker.Models.Contract;
    internal class TaskManagerFake : TaskManager
    {
        public TaskManagerFake(IIdProvider provider, ILogger logger) : base(provider, logger)
        {
        }

        public ICollection<ITask> ExposedTasks
        {
            get
            {
                return base.Tasks;
            }
        }
    }
}
