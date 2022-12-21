using System.Diagnostics;

namespace odium
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        static alert? a = null;
        
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

            if (args.Length == 0)
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
                Mutex mutex = new Mutex(true, Application.ProductName + " checker", out bool isFirst);
                if (isFirst)
                {
                    //Thread t = new Thread(new ThreadStart(MapleRunCheck));
                    //t.Start();
                    alert a = new alert();
                    a.Show();
                    a.Hide();
                    Application.Run();
                    a.Dispose();
                }
                mutex.Close();
            }
        }

        //static bool finder;
        //static int running = 0;

        //static void MapleRunCheck()
        //{
        //    while (finder)
        //    {
        //        try
        //        {
        //            Process[] proc = Process.GetProcesses();
        //            if (running == 0)    // 실행 감지 전
        //            {
        //                for (int i = 0; i < proc.Length; ++i)
        //                {
        //                    if (proc[i].ProcessName.ToLower().Contains("maplestory"))
        //                    {
        //                        running = 1; break;
        //                    }
        //                }

        //            }
        //            else if (running == 1) // 실행 감지 후
        //            {
        //                bool no = true;
        //                for (int i = 0; i < proc.Length; ++i)
        //                {
        //                    if (proc[i].ProcessName.ToLower().Contains("maplestory"))
        //                    {
        //                        no = false; break;
        //                    }
        //                }

        //                if (no)
        //                {
        //                    a = new alert();
        //                    a.Show();
        //                    running = 0;
        //                }

        //            }

        //        }
        //        catch (Exception ex) { };

        //        Thread.Sleep(1000);
        //    }
        //}


    }
}