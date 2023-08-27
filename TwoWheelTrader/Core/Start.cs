using TwoWheelTrader.Core.Interfaces;

namespace TwoWheelTrader.Core
{
    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.RunProgram();
        }
    }
}