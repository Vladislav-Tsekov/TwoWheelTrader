namespace FormTest
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MakeSelector());



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of your Windows Forms Application's main form
            MakeSelector form = new MakeSelector();

            // Optionally, you can pass data or configure the form before showing it

            // Show the form
            Application.Run(form);



            string make = "";
            int cc = 0;
            int year = 0;

            
        }
    }
}