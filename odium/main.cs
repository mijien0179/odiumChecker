using System.Diagnostics;

namespace odium
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();

            checkBox1.Checked = isSetStartup();

        }

        public static bool isSetStartup()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd";
            proc.StartInfo.Arguments = $"/c schtasks";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();

            string str = proc.StandardOutput.ReadToEnd();


            bool has = str.Contains("odium");

            proc.StandardOutput.Close();
            proc.WaitForExit();
            proc.Close();
            return has;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "cmd";
                proc.StartInfo.Arguments = $"/c schtasks -create /sc onlogon /tn \"\\odium\\autorun\" /tr \"'{Application.ExecutablePath}' '--autorun'\" /RL HIGHEST";
                if (!proc.Start())
                {
                    MessageBox.Show("���� ���α׷� ��Ͽ� �����߽��ϴ�.", "���� ���α׷� ��� ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                Process.Start("cmd", $"/c schtasks -delete /tn \"\\odium\\autorun\" /f");
                Process.Start("cmd", $"/c schtasks -delete /tn \"\\odium\" /f");
            }

            checkBox1.Checked = !checkBox1.Checked;
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkBox1.Checked)
            {
                Process p = Process.Start(Application.ExecutablePath, "--autorun");
            }
        }
    }
}