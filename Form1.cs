using static System.Windows.Forms.AxHost;

namespace SCREEN
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Pen marcadorS = new Pen(Color.White, 3);
        Pen marcadorL = new Pen(Color.Wheat, 3);
        private int width, height, wMid, hMid;
        private Point l1, l2, l3, l4;
        private Point squareA, squareB, squareC, squareD;
        private Point origen;

        public Form1()
        {
            InitializeComponent();
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            // Initialize the picture box
            InitializePictureBox(width, height);
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            // Reset the picture box
            InitializePictureBox(width, height);

            // Points to draw the square
            squareA = new Point(0, 0);
            squareB = new Point(0, 100);
            squareC = new Point(100, 100);
            squareD = new Point(100, 0);

            // Draw the square
            Render(squareA, squareB, 0);
            Render(squareB, squareC, 0);
            Render(squareC, squareD, 0);
            Render(squareD, squareA, 0);

            pictureBox1.Invalidate();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            // Reset the picture box
            InitializePictureBox(width, height);

            // Points to draw the square
            squareA = new Point(0, 0);
            squareB = new Point(0, 100);
            squareC = new Point(100, 100);
            squareD = new Point(100, 0);

            // Draw the square
            Render(squareA, squareB, 0);
            Render(squareB, squareC, 0);
            Render(squareC, squareD, 0);
            Render(squareD, squareA, 0);

            pictureBox1.Invalidate();

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // Reset the picture box
            InitializePictureBox(width, height);

            // Points to draw the square
            squareA = new Point(-50, -50);
            squareB = new Point(-50, 50);
            squareC = new Point(50, 50);
            squareD = new Point(50, -50);

            // Draw the square
            Render(squareA, squareB, 0);
            Render(squareB, squareC, 0);
            Render(squareC, squareD, 0);
            Render(squareD, squareA, 0);

            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Change color when hover
            button1.MouseEnter += OnMouseEnterButton1;
            button1.MouseLeave += OnMouseLeaveButton1;
            wMid = width / 2;
            hMid = height / 2;
            origen = new Point(wMid, hMid);

            // Reset the picture box
            InitializePictureBox(width, height);

            // Points to draw the square
            squareA = new Point(0, 0);
            squareB = new Point(0, 100);
            squareC = new Point(100, 100);
            squareD = new Point(100, 0);

            // Draw the square
            Render(squareA, squareB, 0);
            Render(squareB, squareC, 0);
            Render(squareC, squareD, 0);
            Render(squareD, squareA, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Reset the picture box
            InitializePictureBox(width, height);

            // Radio button 1 (Example rotation 1) checked
            if (radioButton1.Checked)
            {
                // Points to draw the square
                squareA = new Point(0, 0);
                squareB = new Point(0, 100);
                squareC = new Point(100, 100);
                squareD = new Point(100, 0);

                // Get the angle from the texto box
                Double.TryParse(textBox1.Text, out double text);
                double angle = text * (Math.PI / 180);

                // Draw the square
                Render(squareA, squareB, angle);
                Render(squareB, squareC, angle);
                Render(squareC, squareD, angle);
                Render(squareD, squareA, angle);

                pictureBox1.Invalidate();

            }
            // Radio button 2 (Example rotation 2) checked
            else if (radioButton2.Checked)
            {
                // Points to draw the square
                squareA = new Point(0, 0);
                squareB = new Point(0, 100);
                squareC = new Point(100, 100);
                squareD = new Point(100, 0);

                // Get the angle from the texto box
                Double.TryParse(textBox1.Text, out double text);
                double angle = text * (Math.PI / 180);

                // Draw the square
                RenderLine(squareA, squareB, angle);
                RenderLine(squareB, squareC, angle);
                RenderLine(squareC, squareD, angle);
                RenderLine(squareD, squareA, angle);

                pictureBox1.Invalidate();
            }
            // Radio button 3 (Example rotation 3) checked
            else if (radioButton3.Checked)
            {
                // Points to draw the square
                squareA = new Point(-50, -50);
                squareB = new Point(-50, 50);
                squareC = new Point(50, 50);
                squareD = new Point(50, -50);

                // Get the angle from the texto box
                Double.TryParse(textBox1.Text, out double text);
                double angle = text * (Math.PI / 180);

                // Draw the square
                Render(squareA, squareB, angle);
                Render(squareB, squareC, angle);
                Render(squareC, squareD, angle);
                Render(squareD, squareA, angle);

                pictureBox1.Invalidate();
            }
        }

        private void InitializePictureBox(int width, int height)
        {
            bmp = new Bitmap(width, height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);

            // points to draw intersecting lines
            l1 = new Point(origen.X, 0);
            l2 = new Point(origen.X, height);
            l3 = new Point(0, origen.Y);
            l4 = new Point(width, origen.Y);

            // Draw intersecting lines
            g.DrawLine(marcadorL, l1, l2);
            g.DrawLine(marcadorL, l3, l4);
        }

        private PointF TranslateToCenter(PointF a)
        {
            int Sx = (bmp.Width / 2); // origen central en x
            int Sy = (bmp.Height / 2); // origen central en y

            return new PointF(Sx + a.X, Sy - a.Y);
        }

        private PointF Translate(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        private void Render(Point a, Point b, double angle)
        {
            PointF a2, b2;

            a2 = new PointF(origen.X + a.X, origen.Y - a.Y);
            b2 = new PointF(origen.X + b.X, origen.Y - b.Y);

            // Equations to rotate
            a2.X = origen.X + (float)((a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle)));
            a2.Y = origen.Y - (float)((a.X * Math.Sin(angle)) + (a.Y * Math.Cos(angle)));

            b2.X = origen.X + (float)((b.X * Math.Cos(angle)) - (b.Y * Math.Sin(angle)));
            b2.Y = origen.Y - (float)((b.X * Math.Sin(angle)) + (b.Y * Math.Cos(angle)));

            // Draw line
            g.DrawLine(marcadorS, a2, b2);

            pictureBox1.Invalidate();
        }

        private PointF Rotate(PointF a, double angle)
        {
            PointF b = new PointF();
            b.X = (float)((a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle)));
            b.Y = (float)((a.X * Math.Sin(angle)) + (a.Y * Math.Cos(angle)));
            return b;
        }

        private void RenderLine(PointF a, PointF b, double angle)
        {
            a = Translate(a, new PointF(-50, -50)); // centroide
            b = Translate(b, new PointF(-50, -50)); // centroide
            PointF c = Rotate(a, angle);
            PointF d = Rotate(b, angle);//*/
            c = TranslateToCenter(c);
            d = TranslateToCenter(d);
            c = Translate(c, new PointF(50, -50));
            d = Translate(d, new PointF(50, -50));

            g.DrawLine(marcadorS, c, d);
        }//*/

        private void OnMouseEnterButton1(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(55, 55, 55); // or Color.Red or whatever you want
        }

        private void OnMouseLeaveButton1(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}