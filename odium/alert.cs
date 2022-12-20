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
            t = new Thread(new ThreadStart(MapleRunCheck));
            t.Start();
            label1.BackColor =
                label2.BackColor = Color.FromArgb(0xe9, 0x94, 0x00);
        }

        Thread t;
        int running = 0;
        bool finder = true;
        bool canClose = false;
        private void alert_Load(object sender, EventArgs e)
        {

        }

        private void open()
        {
            this.Visible = true;
            this.Activate();

        }

        void MapleRunCheck()
        {
            while (finder)
            {
                try
                {
                    Process[] proc = Process.GetProcessesByName("maplestory");
                    if (running == 0)    // 실행 감지 전
                    {
                        if (proc.Length > 0)
                        {
                            running = 1;
                        }

                    }
                    else if (running == 1) // 실행 감지 후
                    {
                        if (proc.Length == 0)
                        {
                            if (this.InvokeRequired)
                            {
                                this.Invoke(open);
                            }
                            running = 0;
                        }

                    }

                }
                catch (Exception ex) { };

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
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start("https://maplestory.nexon.com/");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Keyboard k = new Keyboard();
            if (k.CtrlKeyDown)
            {
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Ctrl 키를 누르면서 클릭하세요", "실수 방지", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
