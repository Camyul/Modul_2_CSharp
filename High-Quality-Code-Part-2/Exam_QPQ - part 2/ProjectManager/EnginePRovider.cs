namespace ProjectManager
{
    internal class EnginePRovider
    {
        public EnginePRovider(Engine engine)
        {
            this.Engine = engine;
        }

        public Engine Engine { get; set; }

        public void Start()
        {
            this.Engine.Start();
        }
    }
}
