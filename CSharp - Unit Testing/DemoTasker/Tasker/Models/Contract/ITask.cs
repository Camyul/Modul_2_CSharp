namespace Tasker.Models.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITask
    {
        int Id { get; set; }

        string Description { get; set; }
    }
}
