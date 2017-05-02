namespace SchoolSystem.Core
{
    public class BusinessLogicService
    {
        public void Execute(ConsoleReaderProvider readedCommand)
        {
            var engine = new Engine(readedCommand);
            engine.BrumBrum();
        }
    }
}
