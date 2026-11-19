using System;
using System.Windows.Forms;

namespace SnakeAndApple
{
    public partial class Form1 : Form
    {
        private const int Step = 20;
        private readonly Random random = new Random();
        private int score;

        public Form1()
        {
            InitializeComponent();
            PlaceApple();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    pictureBox1.Left = Math.Max(0, pictureBox1.Left - Step);
                    break;
                case Keys.Right:
                    pictureBox1.Left = Math.Min(ClientSize.Width - pictureBox1.Width, pictureBox1.Left + Step);
                    break;
                case Keys.Up:
                    pictureBox1.Top = Math.Max(0, pictureBox1.Top - Step);
                    break;
                case Keys.Down:
                    pictureBox1.Top = Math.Min(ClientSize.Height - pictureBox1.Height, pictureBox1.Top + Step);
                    break;
                default:
                    return;
            }

            e.Handled = true;
            CheckApple();
        }

        private void CheckApple()
        {
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                score++;
                label1.Text = "Xal: " + score;
                PlaceApple();
            }
        }

        private void PlaceApple()
        {
            int maxX = Math.Max(1, ClientSize.Width - pictureBox2.Width);
            int maxY = Math.Max(1, ClientSize.Height - pictureBox2.Height);
            pictureBox2.Left = random.Next(0, maxX);
            pictureBox2.Top = random.Next(0, maxY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}