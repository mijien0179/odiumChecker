namespace odium
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //bool debug = true;

            //if (debug)
            //{
            //    Application.Run(new alert());
            //    return;
            //}

            if(args.Length == 0)
            {
                Mutex mutex = new Mutex(true, Application.ProductName, out bool isFirst);
                if (isFirst)
                {
                    Application.Run(new main());
                }
                else
                {
                    MessageBox.Show("이미 실행중입니다.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                mutex.Close();
            }
            else
            {
                Mutex mutex = new Mutex(true, Application.ProductName, out bool isFirst);
                if (isFirst)
                {
                    alert a = new alert();
                    Application.Run();
                }
                mutex.Close();
            }
        }
    }
}