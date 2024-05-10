using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

namespace FitnessTracker
{
    public partial class forgetPasswordForm : Form
    {
        //Database Connection String
        private string connectionString;

        public forgetPasswordForm(string dbConnectionString)
        {
            InitializeComponent();

            connectionString = dbConnectionString;
        }

        private void SendResetPasswordEmail(string emailAddress)
        {
            //Generate a unique token for password reset
            string resetToken = GenerateRandomToken();

            //Store the reset token in the database along with user's email
            StoreResetToekInDatabase(emailAddress, resetToken);

            //Send the reset token to the user's email
            SendEmail(emailAddress, resetToken);

            //Show success message
            MessageBox.Show("Password reset token has been sent to your email address.");

            //Provide an input box for the user to enter the reset token
            string inputToken = Microsoft.VisualBasic.Interaction.InputBox("Enter the reset token:", "Password Reset", "");

            //Check if the entered token is correct
            if(inputToken == resetToken)
            {
                MessageBox.Show("Token is correct. You can now reset your password.");
            }
            else
            {
                MessageBox.Show("Invalid reset token.");
            }
        }

        //Generate a random token for password reset
        private string GenerateRandomToken()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //Send email to user with password reset token
        private void SendEmail(string emailAddress, string resetToken)
        {
            //Configure SMTP Client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("fitnesstracker.1738@gmail.com", "Aung@2005123"),
                EnableSsl = true
            };

            //Create email message
            MailMessage message = new MailMessage("fitnesstracker.1738@gmail.com", emailAddress)
            {
                Subject = "Password Reset For Your Fitness Tracker Account",
                Body = $"Your Password Reset Token is: {resetToken}"
            };

            //Send email
            try
            {
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }
        }

        //Store reset token in database
        private void StoreResetToekInDatabase(string emailAddress, string resetToken)
        {
            // Store the reset token in the database
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO password_reset_tokens (emailAddress, resetToken, expiryDate) VALUES (@emailAddress, @resetToken, @expiryDate)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@emailAddress", emailAddress);
                command.Parameters.AddWithValue("@resetToken", resetToken);
                command.Parameters.AddWithValue("@expiryDate", DateTime.Now.AddDays(1)); // Token expire in 1 day

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error storing reset token in the database: {ex.Message}");
                }
            }
        }

        private void send_reset_link_Click(object sender, EventArgs e)
        {
            string emailAddress = reset_link_email.Text;

            if (string.IsNullOrEmpty(emailAddress))
            {
                MessageBox.Show("Please enter your email address.");
                return;
            }

            //Send the reset email to the User
            SendResetPasswordEmail(emailAddress);
        }
    }
}
