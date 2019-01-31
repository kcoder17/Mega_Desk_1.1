using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_3_BradKellogg
{
    public partial class AddQuote : Form
    {
        public AddQuote()
        {
            InitializeComponent();
        }

        private void addQuoteButton_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        public bool ValidWidth(string width, out string errorMessage)
        {
            int temp = 0;

            // Parsing failed
            if (!Int32.TryParse(width, out temp))
            {
                errorMessage = "Width must be a number.";
                return false;
            }

            // Confirm that the width field is not empty.
            if (width.Length == 0)
            {
                errorMessage = "Width is required.";
                return false;
            }

            if (temp < 24)
            {
                errorMessage = "Width must be at least 24.";
                return false;
            } else if (temp > 96)
            {
                errorMessage = "Width must be less than 96.";
                return false;
            } else
            {
                errorMessage = "";
                return true;
            }
        }

        private void widthInput_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidWidth(widthInput.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                widthInput.Select(0, widthInput.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.widthErrorProvider.SetError(widthInput, errorMsg);
            }
        }

        private void widthInput_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            widthErrorProvider.SetError(widthInput, "");
        }

        private void heightInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char.IsDigit(heightInput.Text, 0);
        }
    }
}
