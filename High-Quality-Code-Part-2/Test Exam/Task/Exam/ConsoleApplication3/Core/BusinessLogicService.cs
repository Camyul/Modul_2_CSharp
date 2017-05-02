using SchoolSystem.Contracts;

namespace SchoolSystem.Core
{
    public class BusinessLogicService
    {
        public void Execute(IReader readedCommand)
        {
            var engine = new Engine(readedCommand);
            engine.BrumBrum();
        }
    }
}
