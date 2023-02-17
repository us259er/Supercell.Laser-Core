namespace Supercell.Laser.Server
{
    using Supercell.Laser.Titan.Debug;

    internal class Program
    {
        static void Main(string[] args)
        {
            TextDebugger.SetListener(new DebuggerListener());

            TextDebugger.Print("Hello World");


        }
    }
}