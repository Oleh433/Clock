using System.ComponentModel;

namespace Lab7Ex2
{
    public partial class Form1 : Form
    {
        const int timePatch = -15;
        int seconds = 0;

        int realSeconds = DateTime.Now.Second + timePatch + 1;
        int realMinutes = DateTime.Now.Minute + timePatch;
        int realHours = DateTime.Now.Hour - 3;

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            
            int angle = (seconds + realSeconds) * 6 % 360;
            int minAngle = ((seconds + realSeconds + 15) / 60 + realMinutes) * 6;
            int hourAngle = ((seconds + realSeconds + 15 + (realMinutes + 15) * 60) / 3600 + realHours) * 30;


            g.Clear(Color.White);
            g.DrawEllipse(Pens.Black, 0, 0, 200, 200);

            //Minutes
            int xMinute = (int)(100 + 100.00 * Math.Cos((minAngle * (Math.PI)) / 180));
            int yMinute = (int)(100 + 100.00 * Math.Sin((minAngle * (Math.PI)) / 180));

            g.DrawLine(Pens.Black, 100, 100, xMinute, yMinute);

            //hours
            int xHour = (int)(100 + 60.00 * Math.Cos((hourAngle * (Math.PI)) / 180));
            int yHour = (int)(100 + 60.00 * Math.Sin((hourAngle * (Math.PI)) / 180));

            g.DrawLine(Pens.CornflowerBlue, 100, 100, xHour, yHour);

            //Seconds
            int xSecond = (int)(100 + 100.00 * Math.Cos((angle * (Math.PI)) / 180));
            int ySecond = (int)(100 + 100.00 * Math.Sin((angle * (Math.PI)) / 180));

            g.DrawLine(Pens.Red, 100, 100, xSecond, ySecond);

            seconds++;
        }
    }
}