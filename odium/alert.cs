using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;

namespace odium
{
    public partial class alert : Form
    {
        public alert()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            label1.BackColor =
                label2.BackColor = Color.FromArgb(0xe9, 0x94, 0x00);

            t = new Thread(new ThreadStart(MapleRunCheck));
            t.Start();
        }

        Thread t;
        int running = 0;
        bool finder = true;
        bool canClose = false;
        private void alert_Load(object sender, EventArgs e)
        {

        }

        public void open()
        {
            this.Show();
            this.Activate();
        }

        void MapleRunCheck()
        {
            int? procId = null;
            while (finder)
            {
                try
                {
                    Process[]? proc = Process.GetProcessesByName("maplestory");
                    if (running == 0) // 실행 감지 전
                    {
                        if (proc.Length > 0)
                        {
                            if(proc.Length == 1)
                            {
                                procId = proc[0].Id;
                            }
                            running = 1;
                            MessageBox.Show("1");
                        }
                    }
                    else if (running == 1) // 실행 감지 후
                    {
                        if (proc.Length < 1)
                        {
                            running = 0;
                            if (this.InvokeRequired) this.Invoke(new MethodInvoker(open));
                            return;
                        }
                        else
                        {
                            MessageBox.Show($"{proc[0].ProcessName} {proc[0].HasExited} {proc.Length} {proc[0].Id}");
                        }
                    }
                    proc = null;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                };

                Thread.Sleep(1000);
            }
        }

        private bool isPress = false;
        private Point pos;

        private void alert_MouseUp(object sender, MouseEventArgs e)
        {
            isPress = false;
        }

        private void alert_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPress)
            {
                this.SetDesktopLocation(Location.X - pos.X + e.X, Location.Y - pos.Y + e.Y);
            }
        }

        private void alert_MouseDown(object sender, MouseEventArgs e)
        {
            isPress = true;
            pos = e.Location;
        }

        private void alert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!canClose)
            {
                e.Cancel = true;
                Hide();
            }

            finder = false;
            t.Join();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://maplestory.nexon.com");
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Keyboard k = new Keyboard();
            if (k.CtrlKeyDown)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Ctrl 키를 누르면서 클릭하세요", "실수 방지", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("일퀘 했움?을 종료합니다.", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                canClose = true;
                Close();
            }
        }
    }
}
