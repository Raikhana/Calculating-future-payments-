using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatingThePresentValueAndFutureValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double presentValue;
        double InterestRate;
        double period;
        double futureValue;

        string[,] calculationsTable = new string[10, 4];
        int row = 0;

        string[,] calculationsTable1 = new string[10, 4];
        int row1 = 0;

        private void CalculatingTheFutureValue()
        {
            try
            {
                if (string.IsNullOrEmpty(txtPresentValue.Text))
                {
                    presentValue = 0;
                }
                else
                {
                    presentValue = double.Parse(txtPresentValue.Text);
                }
                InterestRate = double.Parse(txtInterestRate.Text);
                period = double.Parse(txtPeriod.Text);

                double p = InterestRate / 100;
                double exponentiation = Math.Pow((1 + p), period);
                futureValue = Math.Round(presentValue * exponentiation);

                txtFutureValue.Text = futureValue.ToString();

                calculationsTable[row, 0] = presentValue.ToString("c");
                calculationsTable[row, 1] = InterestRate.ToString();
                calculationsTable[row, 2] = period.ToString();
                calculationsTable[row, 3] = futureValue.ToString("C");
                //row++;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid numeric format. Please check all entries.", "Entry Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Overflow error. Please enter smaller values.", "Entry Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void txtPresentValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInterestRate.Text) ||
                string.IsNullOrEmpty(txtPeriod.Text))
            {}
            else {
                if (txtPresentValue.ReadOnly == false)
                {
                    CalculatingTheFutureValue();
                }
            }
        }

        private void txtInterestRate_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInterestRate.Text) ||
                string.IsNullOrEmpty(txtPresentValue.Text) ||
                string.IsNullOrEmpty(txtPeriod.Text))
            {}
            else {
                if (txtInterestRate.ReadOnly == false)
                {
                    CalculatingTheFutureValue();
                }
            }
        }

        private void txtPeriod_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPresentValue.Text) ||
                string.IsNullOrEmpty(txtInterestRate.Text) ||
                string.IsNullOrEmpty(txtPeriod.Text))
            {}
            else {
                if (txtPeriod.ReadOnly == false)
                {
                    CalculatingTheFutureValue();
                }
            }
        }

        private void CalculatingThePresentValue()
        {
            try
            {
                if (string.IsNullOrEmpty(txtFutureValue.Text))
                {
                    futureValue = 0;
                }
                else
                {
                    futureValue = double.Parse(txtFutureValue.Text);
                }
                InterestRate = double.Parse(txtInterestRate.Text);
                period = double.Parse(txtPeriod.Text);

                double p = InterestRate / 100;
                double exponentiation = Math.Pow((1 + p), period);
                presentValue = Math.Round(futureValue / exponentiation, 2);

                txtPresentValue.Text = presentValue.ToString();

                calculationsTable1[row, 0] = presentValue.ToString("c");
                calculationsTable1[row, 1] = InterestRate.ToString();
                calculationsTable1[row, 2] = period.ToString();
                calculationsTable1[row, 3] = futureValue.ToString("C");
                //row1++;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid numeric format. Please check all entries.", "Entry Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Overflow error. Please enter smaller values.", "Entry Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private string value;
        private void txtFutureValue_TextChanged(object sender, EventArgs e)
        {
            if(value1 == true)
            {
                value1 = false;
            }
            else
            {
                var oldValue = value;
                value = ((TextBox)sender).Text; // = txtFutureValue.Text

                if (oldValue != null)
                {
                    if (txtFutureValue.ReadOnly == false)
                    {
                        CalculatingThePresentValue();
                    }
                }
            }
        }

        private void txtPresentValue_MouseClick(object sender, MouseEventArgs e)
        {
            txtPresentValue.ReadOnly = false;
            txtInterestRate.ReadOnly = true;
            txtPeriod.ReadOnly = true;
            txtFutureValue.ReadOnly = true;
        }

        private void txtInterestRate_MouseClick(object sender, MouseEventArgs e)
        {
            txtPresentValue.ReadOnly = true;
            txtInterestRate.ReadOnly = false;
            txtPeriod.ReadOnly = true;
            txtFutureValue.ReadOnly = true;
        }

        private void txtPeriod_MouseClick(object sender, MouseEventArgs e)
        {
            txtPresentValue.ReadOnly = true;
            txtInterestRate.ReadOnly = true;
            txtPeriod.ReadOnly = false;
            txtFutureValue.ReadOnly = true;
        }

        private void txtFutureValue_MouseClick(object sender, MouseEventArgs e)
        {
            txtPresentValue.ReadOnly = true;
            txtInterestRate.ReadOnly = true;
            txtPeriod.ReadOnly = true;
            txtFutureValue.ReadOnly = false;
        }

        bool value1 = false;
        private void btnResetDefaults_Click(object sender, EventArgs e)
        {
            value1 = true;
            txtPresentValue.Clear();
            txtInterestRate.Clear();
            txtPeriod.Clear();
            txtFutureValue.Clear();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtPresentValue.Clear();
            txtPeriod.Clear();
            txtFutureValue.Clear();
        }

        private void btnSent_Click(object sender, EventArgs e)
        {
            string message = "Pr/Value  \tRate   \tPeriod    \tFt/Value\n";
            for (int i = 0; i < calculationsTable.GetLength(0); i++)
            {
                if (calculationsTable[i, 0] != null)
                {
                    for (int j = 0; j < calculationsTable.GetLength(1); j++)
                    {
                        message += calculationsTable[i, j] + "\t";
                    }
                    message += "\n";
                }
            }
            MessageBox.Show(message, "Future Value Calculations");

            string message1 = "Pr/Value  \tRate   \tPeriod    \tFt/Value\n";
            for (int i = 0; i < calculationsTable1.GetLength(0); i++)
            {
                if (calculationsTable1[i, 0] != null)
                {
                    for (int j = 0; j < calculationsTable1.GetLength(1); j++)
                    {
                        message1 += calculationsTable1[i, j] + "\t";
                    }
                    message1 += "\n";
                }
            }
            MessageBox.Show(message1, "Present Value Calculations");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
