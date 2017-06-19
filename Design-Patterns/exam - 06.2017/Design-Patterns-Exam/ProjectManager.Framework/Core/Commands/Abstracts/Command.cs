using ProjectManager.Data;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Framework.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected readonly Database Database;

        public Command()
        {
            this.Database = Database.Instance;
        }

        public abstract int ParameterCount
        {
            get;
        }

        public abstract string Execute(IList<string> parameters);

        protected virtual void ValidateParameters(IList<string> parameters)
        {
            if (parameters.Count != this.ParameterCount)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }
        }
    }
}
