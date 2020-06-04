using DoodleJumpEngine;
using DoodleJumpEngine.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DoodleJump
{
    public partial class Form_Main : Form
    {
        public static Engine GameEngine;
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label_Debug.Visible = true;
            label_Debug.BackColor = Color.Empty;
            Main_SizeChanged(sender, e);
            Size = new Size(Program.appSettings.WindowWidth, Program.appSettings.WindowHeight + 39);
            GameEngine = new Engine(Drawer, Program.appSettings);
            GameEngine.Start();
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            switch (FormBorderStyle)
            {
                case FormBorderStyle.None:
                    pictureBox_Main.Size = new Size(Program.appSettings.WindowWidth, Program.appSettings.WindowHeight);
                    break;
                default:
                    pictureBox_Main.Size = new Size(Program.appSettings.WindowWidth, Program.appSettings.WindowHeight);
                    break;
            }
            Program.MainForm.Text = $"Game {Size.Width}/{Size.Height} || {pictureBox_Main.Size.Width}/{pictureBox_Main.Size.Height}";
        }

        DateTime lastupdatedebug = DateTime.Now;
        private void Drawer(Image frame)
        {
            try
            {
                Invoke(new Action(() => pictureBox_Main.Image = frame));
                if (lastupdatedebug.AddSeconds((1000/25)/1000.0) <= DateTime.Now)
                {
                    Invoke(new Action(() => label_Debug.Text = GameEngine.debugTool.GetDebugStr()));
                    lastupdatedebug = DateTime.Now;
                }
            }
            catch (ObjectDisposedException)
            {

            }
            catch (InvalidOperationException)
            {

            }
        }


        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F5:
                    Program.Restart();
                    break;
                case Keys.Right:
                    GameEngine.controls.StartRight();
                    break;
                case Keys.Left:
                    GameEngine.controls.StartLeft();
                    break;
            }
        }

        private void Form_Main_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Right:
                    GameEngine.controls.StopRight();
                    break;
                case Keys.Left:
                    GameEngine.controls.StopLeft();
                    break;
            }
        }
    }
}
