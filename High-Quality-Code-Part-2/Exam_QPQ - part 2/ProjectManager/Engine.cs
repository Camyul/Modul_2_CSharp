using Bytes2you.Validation;
using ProjectManager.Common;
using ProjectManager.Common.Exceptions;
using ProjectManager.Contracts;
using System;

namespace ProjectManager
{
    internal class Engine : IEngine
    {
        private FileLogger logger;
        private CommandProcessor processor;

        public Engine(FileLogger logger, CommandProcessor processor)
        {
            Guard.WhenArgument(logger, "Engine Logger provider")
                .IsNull()
                .Throw();

            Guard.WhenArgument(processor, "Engine Processor provider")
                .IsNull()
                .Throw();

            this.logger = logger;

            this.processor = processor;
        }

        public void Start()
        {
            while (true)
            {
                var readedCommand = Console.ReadLine();

                if (readedCommand.ToLower() == "exit")
                {
                    Console.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.Process(readedCommand);
                    Console.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                    this.logger.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
