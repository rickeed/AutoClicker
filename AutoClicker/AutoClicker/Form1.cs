using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoClicker
{
    public partial class Form1 : Form
    {


        [DllImport("user32.dll")]

        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);
        



        const uint LeftD = 0x0002;
        const uint LeftU = 0x0004;
     
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Update.Start();
            Clicker.Stop();
            label1.Text = trackBar1.Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clicker.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clicker.Stop();
        }

        new private void Update_Tick(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            Clicker.Interval = trackBar1.Value;
        }
        private void Clicker_Tick(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                   {
                        
                        mouse_event(LeftD, 6, 0, 9, (UIntPtr)0);
                        mouse_event(LeftU, 6, 0, 9, (UIntPtr)0);
                    }
            }


               
            
            else
            {
                return;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }





        

        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            btn.BackColor = Color.Yellow;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Mouse konumundaki pikselin rengini alın
            Color color = GetPixelColor(e.X, e.Y);

            // Rengi bir metin olarak gösterin
            label1.Text = "R: " + color.R.ToString() + " G: " + color.G.ToString() + " B: " + color.B.ToString();
        }

        public Color GetPixelColor(int x, int y)
        {
            // Ekranın tüm boyutlarını alın
            Rectangle screenSize = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // Ekranın görüntüsünü alın
            Bitmap bmpScreen = new Bitmap(screenSize.Width, screenSize.Height);
            using (Graphics g = Graphics.FromImage(bmpScreen))
            {
                g.CopyFromScreen(0, 0, 0, 0, bmpScreen.Size);
            }

            // Belirtilen konumdaki pikselin rengini alın
            Color color = bmpScreen.GetPixel(x, y);

            // Belleği serbest bırakın
            bmpScreen.Dispose();

            return color;
        }

    }
}
