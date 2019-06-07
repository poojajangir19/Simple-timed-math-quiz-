using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Quiz_Game
{
    public partial class Form1 : Form
    {
        // Create a Random object to generate random numbers.
        Random r = new Random();


        // These variables will store the numbers for the addition function.
        int add1;
        int add2;


        // These variables will store the numbers for the subtraction function..
        int sub1;
        int sub2;


        // These variables will store the numbers for the multiplication function.
        int multi1;
        int multi2;


        // These variables will store the numbers for the divisu function.
        int dividend;
        int divisor;


        // This int will keep track of the time left.
        int timeLeft;


        /// Starts the quiz solving all the problems also starts the timer

        public void PlayGame()
        {
            add1 = r.Next(51); add2 = r.Next(51);
            plus1label.Text = add1.ToString();
            plus2label.Text = add2.ToString();
            add.Value = 0;

            sub1 = r.Next(1, 101); sub2 = r.Next(1, sub1);
            LeftMinuslabel.Text = sub1.ToString();
            RightMinuslabel.Text = sub2.ToString();
            subtract.Value = 0;

            multi1 = r.Next(2, 11);
            multi2 = r.Next(2, 11);
            LeftMultilabel.Text = multi1.ToString();
            RightMultilabel.Text = multi2.ToString();
            multiply.Value = 0;


            // Fill in the division problem.
            divisor = r.Next(2, 11);
            int temporaryQuotient = r.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            LeftDividelabel.Text = dividend.ToString();
            RightDividelable.Text = divisor.ToString();
            division.Value = 0;

            // Timer is started
            timeLeft = 30;
            Timeleftlabel.Text = "30 seconds";
            timer1.Start();


        }


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }

        /// Checks if the result is right, returns True if the answer's correct, false otherwise.
        private bool Result()
        {
            if ((add1 + add2 == add.Value)
                && (sub1 - sub2 == subtract.Value)
                && (multi1 * multi2 == multiply.Value)
                && (dividend / divisor == division.Value))
                return true;
            else
                return false;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Result())
            {
                // If the result is right, then timer is stopped and message is displayed
                timer1.Stop();
                MessageBox.Show("ALL ANSWERS ARE RIGHT- You won the quiz!",
                                "Congratulations");
                StartButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                Timeleftlabel.Text = timeLeft + " seconds";


            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                Timeleftlabel.Text = "Time's up!";
                MessageBox.Show("Incorrect result/You didn't finish in time, Sorry!!!");
                add.Value = add1 + add2;
                subtract.Value = sub1 - sub2;
                multiply.Value = multi1 * multi2;
                division.Value = dividend / divisor;
                StartButton.Enabled = true;
            }
        }


        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown contentResult = sender as NumericUpDown;


            if (contentResult != null)
            {
                int answerSize;
                answerSize = contentResult.Value.ToString().Length;
                contentResult.Select(0, answerSize);
            }
        }


        private void StartGameButton_Click_1(object sender, EventArgs e)
        {
            PlayGame();
            StartButton.Enabled = false;
        }

        private void multiply_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
