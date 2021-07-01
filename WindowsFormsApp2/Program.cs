using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2
{
    static class Program
    {
        static void Main()
        {
            var form1 = new MyForm();
            Application.Run(form1);
        }
    }

    public class MyForm : Form
    {
        private Label label, label2;
        private Button button;
        Random rndX = new Random(1235);
        Random rndY = new Random();

        int timerCounter = 3; //счётчик для таймера
        readonly Timer timer = new Timer();

        private void TimerTick()
        {
            if (timerCounter == 0)
            {
                button.Location = new Point(rndX.Next(0, ClientSize.Width - 80),
                    rndY.Next(61, ClientSize.Height - 60));
                timerCounter = 3;
            }
            label2.Text = string.Format("Oсталось времени : {0}", (timerCounter--).ToString());
        }

        public MyForm()
        {
            int numberOfClick = 0;
            timer.Interval = 500;
            timer.Tick += (x,y) => TimerTick();
            timer.Enabled = true;

            BackColor = Color.YellowGreen;

            label = new Label
            {
                Location = new Point(ClientSize.Width/2, 0),
                Size = new Size(ClientSize.Width, 30),
                Text = string.Format("Количество нажатий: {0}", numberOfClick),
                Font = new Font("arial", 14)
            };
            Controls.Add(label);

            label2 = new Label
            {
                Location = new Point(ClientSize.Width / 2, label.Bottom),
                Size = new Size(ClientSize.Width, 30),
                Text = string.Format("Oсталось времени : {0}", 3),
                Font = new Font("arial", 14)
            };
            Controls.Add(label2);

            button = new Button
            {
                
                Size = new Size(110, 40),
                Location = new Point(rndX.Next(0, ClientSize.Width-80), rndY.Next(61, ClientSize.Height-60)),
                Text = "Поймай!",
                Font = new Font("verdana", 12),
                BackColor = Color.Coral
            };
            Controls.Add(button);

            button.Click += (sender, args) =>
            {
                numberOfClick++;
                label.Text = string.Format("Количество нажатий: {0}", numberOfClick);
                button.Location = new Point(rndX.Next(0, ClientSize.Width-80),
                    rndY.Next(61, ClientSize.Height-60));
                timerCounter = 3;
                label2.Text = string.Format("Oсталось времени : {0}", 3);
            };

            SizeChanged += (x, y) => label.Location = new Point((ClientSize.Width / 2) - 60, 0);
            SizeChanged += (x, y) => label2.Location = new Point((ClientSize.Width / 2) - 60, label.Bottom);
        }
    }
}
