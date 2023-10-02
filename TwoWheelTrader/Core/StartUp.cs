using TwoWheelTrader.Core.Interfaces;

namespace TwoWheelTrader.Core
{
    public class StartUp
    {
        static void Main()
        {
            IController controller = new Controller();  
            IEngine engine = new Engine(controller);
            engine.RunProgram();
        }
    }
}