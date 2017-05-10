using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    internal sealed class ListProjectsCommand : ICommand
    {
        private Database db;

        public ListProjectsCommand(Database db)
        {
            Guard.WhenArgument(db, "ListProjectsCommand Database")
                .IsNull()
                .Throw();

            this.Db = db;
        }

        public Database Db
        {
            get
            {
                return this.db;
            }

            set
            {
                this.db = value;
            }
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 0)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            return string.Join(Environment.NewLine, this.Db.Projects);
        }
    }
}
