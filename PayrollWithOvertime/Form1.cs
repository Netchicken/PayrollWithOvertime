namespace PayrollWithOvertime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Named constants
                const decimal BASE_HOURS = 40m;
                const decimal OT_MULTIPLIER = 1.5m;

                // Local variables
                decimal hoursWorked;        // Number of hours worked
                decimal hourlyPayRate;      // Hourly pay rate
                decimal basePay;            // Pay not including overtime
                decimal overtimeHours;      // overtime hours worked
                decimal overtimePay;        // overtime pay
                decimal grossPay;           // total gross pay

                // Get the hours worked and hourly pay rate.
                hoursWorked = decimal.Parse(hoursWorkedTextBox.Text);
                hourlyPayRate = decimal.Parse(hourlyPayRateTextBox.Text);

                // Determine the gross pay.
                if (hoursWorked > BASE_HOURS)
                {
                    // Calculate the base pay (without overtime).
                    basePay = hourlyPayRate * BASE_HOURS;

                    // Calculate the number of overtime hours.
                    overtimeHours = hoursWorked - BASE_HOURS;

                    // Calculate the overtime pay.
                    overtimePay = overtimeHours * hourlyPayRate * OT_MULTIPLIER;

                    // Calculate the gross pay.
                    grossPay = basePay + overtimePay;
                }
                else
                {
                    // Calculate the gross pay.
                    grossPay = hoursWorked * hourlyPayRate;
                }

                // Display the gross pay.
                grossPayLabel.Text = grossPay.ToString("c");
            }
            catch (Exception ex)
            {
                // Display an error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear the TextBoxes and gross pay label.
            hoursWorkedTextBox.Text = "";
            hourlyPayRateTextBox.Text = "";
            grossPayLabel.Text = "";

            // Reset the focus.
            hoursWorkedTextBox.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}