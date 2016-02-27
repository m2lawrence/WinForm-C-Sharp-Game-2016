using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormAppWinGuessGame1
{
    public partial class frmPickANumber : Form
    {
        public frmPickANumber()
        {
            InitializeComponent();
        }
        
        private Label lblTag1;
        private Button btnGuess;
        private Label lblInfo;
        private TextBox txtEntry;
        private int WinningNumber = 0;
        private int Guesses = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

            //Mikes game - Pick a Number!
            
            // Get a random number from zero to 10...     
            WinningNumber = getRandomNumber(10);

                // Put title into window title bar
                this.Text = "Mikes C# Game!";

                // Center form on screen
                this.StartPosition = FormStartPosition.CenterScreen;

                // Set form style
                this.FormBorderStyle = FormBorderStyle.Fixed3D;

                lblTag1 = new Label();        // Create label
                lblTag1.Text = "Enter A Number:";
                lblTag1.Location = new Point(50, 20);
                this.Controls.Add(lblTag1);   // Add label to form

                lblInfo = new Label();        // Create label
                lblInfo.Text = "Enter a number between 0 and 10.";
                lblInfo.Location = new Point(50, 80);
                lblInfo.Width = 200;
                lblInfo.Height = 40;
                this.Controls.Add(lblInfo);   // Add label to form

                txtEntry = new TextBox();     // Create text  box
                txtEntry.Location = new Point(150, 18);
                this.Controls.Add(txtEntry);  // Add to form


                btnGuess = new Button();     // Create a button  
                btnGuess.Text = "Try Number";
                btnGuess.BackColor = Color.LightGray;
                // following centers button and puts it near bottom
                btnGuess.Location = new Point(((this.Width / 2) -
                                                 (btnGuess.Width / 2)),
                                                 (this.Height - 75));
                this.Controls.Add(btnGuess); // Add button to form

                // Add a click event handler using the default event handler
                btnGuess.Click += new System.EventHandler(this.btnGuess_Click);
            }

            private int getRandomNumber(int nbr)
            {
                if (nbr > 0)
                {
                    Random Rnd = new Random();
                    return (Rnd.Next(0, nbr));
                }
                else
                {
                    return 0;
                }
            }

            protected void btnGuess_Click(object sender, System.EventArgs e)
            {
                int val = 0;
                StringBuilder tmpString = new StringBuilder();
                tmpString.Append("Current Guess: ");
                tmpString.Append(txtEntry.Text);
                tmpString.Append("\n");

                try   // try, catch, and finally are covered on Day 9
                {
                    val = int.Parse(txtEntry.Text);

                    // If a number was not entered, an exception will be
                    // throw. Program flow will go to catch statement below

                    tmpString.Append("Guesses: ");

                    Guesses += 1;      // Add one to Guesses

                    tmpString.Append(Guesses.ToString());
                    tmpString.Append("\n");

                    if (val < 0 || val > 10)
                    {
                        // bad value entered
                        tmpString.Append("Number is out of range...Try again.\n");
                        tmpString.Append("Enter a number from 0 to 10");
                    }
                    else
                    {
                        if (val < WinningNumber)
                        {
                            tmpString.Append("You guessed low...  Try again.\n");
                            tmpString.Append("Enter a number from 0 to 10");
                        }
                        else
                        if (val > WinningNumber)
                        {
                            tmpString.Append("You guessed high... Try again.\n");
                            tmpString.Append("Enter a number from 0 to 10");
                        }
                        else
                        {
                            tmpString.Append("You guessed correctly!!");
                        }
                    }
                }
                // Catch format errors....
                catch (FormatException)
                {
                    tmpString.Append("Please enter a valid number...\n");
                    tmpString.Append("Enter a number from 0 to 10");
                }
                finally
                {
                    this.lblInfo.Text = tmpString.ToString();
                    this.txtEntry.Text = "";

                    // Next line will put winning number in window title
                    this.Text = "Hint: " + WinningNumber.ToString();
                }
            }
        
        }
}

