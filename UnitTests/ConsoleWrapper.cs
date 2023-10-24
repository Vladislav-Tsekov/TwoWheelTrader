using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class ConsoleWrapper
    {
        private TextReader originalInput;
        private TextWriter originalOutput;
        private StringWriter inputBuffer;
        private StringWriter outputBuffer;

        public ConsoleWrapper()
        {
            originalInput = Console.In;
            originalOutput = Console.Out;

            inputBuffer = new StringWriter();
            outputBuffer = new StringWriter();

            Console.SetOut(outputBuffer);
        }

        public void SetInput(params string[] inputLines)
        {
            inputBuffer.GetStringBuilder().Clear();
            foreach (var line in inputLines)
            {
                inputBuffer.WriteLine(line);
            }

            //TODO - FUNCTIONAL CUSTOM READER?
            Console.SetIn(new StringReader(inputBuffer.ToString()));
        }

        public string GetOutput()
        {
            return outputBuffer.ToString();
        }

        public void RestoreConsole()
        {
            Console.SetIn(originalInput);
            Console.SetOut(originalOutput);
        }
    }

}
