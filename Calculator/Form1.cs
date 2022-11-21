using System;
using System.Windows.Forms;

namespace LabCalculator
{
    public partial class Form1 : Form
    {
        CalcOperations calcOperations;

        public Form1()
        {
            InitializeComponent();
            calcOperations = new CalcOperations();
            lblOutput.Text = "0";
        }

        private void CheckCorrectNumber()
        {
            if (lblOutput.Text.Length > 15)
            {
                lblOutput.Text = lblOutput.Text.Remove(lblOutput.Text.Length - 1, 1);
                MessageBox.Show("Too long number");
                setEnabledForNumbers(false);
            }

            if (lblOutput.Text[0] == '0' && lblOutput.Text.IndexOf(",") != 1)
                lblOutput.Text = lblOutput.Text.Remove(0, 1);

            if (lblOutput.Text[0] == '-')
                if (lblOutput.Text[1] == '0' && (lblOutput.Text.IndexOf(",") != 2))
                    lblOutput.Text = lblOutput.Text.Remove(1, 1);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            lblOutput.Text += "1";
            CheckCorrectNumber();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lblOutput.Text += "2";
            CheckCorrectNumber();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            lblOutput.Text += "3";
            CheckCorrectNumber();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            lblOutput.Text += "4";
            CheckCorrectNumber();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            lblOutput.Text += "5";
            CheckCorrectNumber();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            lblOutput.Text += "6";
            CheckCorrectNumber();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            lblOutput.Text += "7";
            CheckCorrectNumber();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            lblOutput.Text += "8";
            CheckCorrectNumber();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            lblOutput.Text += "9";
            CheckCorrectNumber();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            lblOutput.Text += "0";
            CheckCorrectNumber();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!lblOutput.Text.Contains(","))
                lblOutput.Text += ",";
            CheckCorrectNumber();
        }

        private void setEnabledForNumbers(bool flag)
        {
            btn0.Enabled = flag;
            btn1.Enabled = flag;
            btn2.Enabled = flag;
            btn3.Enabled = flag;
            btn4.Enabled = flag;
            btn5.Enabled = flag;
            btn6.Enabled = flag;
            btn7.Enabled = flag;
            btn8.Enabled = flag;
            btn9.Enabled = flag;
            btnDot.Enabled = flag;
        }

        private void setEnabledForOperations(bool flag)
        {
            btnPlus.Enabled = flag;
            btnMinus.Enabled = flag;
            btnDivision.Enabled = flag;
            btnMultiplication.Enabled = flag;
            btnCos.Enabled = flag;
            btnSin.Enabled = flag;
            btnTg.Enabled = flag;
            btnCtg.Enabled = flag;
            btnDivOnX.Enabled = flag;
            btnLog10.Enabled = flag;
            btnLn.Enabled = flag;
            btnFact.Enabled = flag;
            btnSqrt.Enabled = flag;
            btnSquaring.Enabled = flag;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            calcOperations.saveFirstNumber(double.Parse(lblOutput.Text));
            lblOutput.Text = "0";
            calcOperations.saveOperation(CalcOperations.Operation.plus);
            setEnabledForNumbers(true);
            setEnabledForOperations(false);

        }
        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            calcOperations.saveFirstNumber(double.Parse(lblOutput.Text));
            lblOutput.Text = "0";
            calcOperations.saveOperation(CalcOperations.Operation.multiplication);
            setEnabledForNumbers(true);
            setEnabledForOperations(false);
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            calcOperations.saveFirstNumber(double.Parse(lblOutput.Text));
            lblOutput.Text = "0";
            calcOperations.saveOperation(CalcOperations.Operation.division);
            setEnabledForNumbers(true);
            setEnabledForOperations(false);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            calcOperations.saveFirstNumber(double.Parse(lblOutput.Text));
            lblOutput.Text = "0";
            calcOperations.saveOperation(CalcOperations.Operation.minus);
            setEnabledForNumbers(true);
            setEnabledForOperations(false);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            calcOperations.clear();
            lblOutput.Text = "0";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = calcOperations.equal(lblOutput.Text);
            }
            catch (Exception a) when (a.Message == "Mistake")
            {
                MessageBox.Show("Division by 0!.");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            calcOperations.cleanFirstNumber();
            setEnabledForNumbers(true);
            setEnabledForOperations(true);
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = calcOperations.sqrt(lblOutput.Text);
            }
            catch (Exception a) when (a.Message == "Mistake")
            {
                MessageBox.Show("Root of negative number");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            setEnabledForNumbers(true);
        }

        private void btnMemoryRead_Click(object sender, EventArgs e)
        {
            lblOutput.Text = calcOperations.MR();
            setEnabledForNumbers(true);
        }

        private void btnMemorySave_Click(object sender, EventArgs e)
        {
            calcOperations.setNumberInMemory(Convert.ToDouble(lblOutput.Text));
            setEnabledForNumbers(true);
        }

        private void btnDivOnX_Click(object sender, EventArgs e)
        {
            lblOutput.Text = calcOperations.divisionOnX(lblOutput.Text);
            setEnabledForNumbers(true);
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            lblOutput.Text = calcOperations.sin(lblOutput.Text);
            setEnabledForNumbers(true);
        }

        private void btnLn_Click(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = calcOperations.ln(lblOutput.Text);
            }
            catch (Exception a) when (a.Message == "Mistake")
            {
                MessageBox.Show("Logarithm of a negative number or 0.");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            setEnabledForNumbers(true);
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            lblOutput.Text = calcOperations.cos(lblOutput.Text);
            setEnabledForNumbers(true);
        }

        private void btnFact_Click(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = calcOperations.factorial(lblOutput.Text);
            }
            catch (Exception a) when (a.Message == "Mistake")
            {
                MessageBox.Show("Factorial of a negative number.");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            setEnabledForNumbers(true);
        }

        private void btnTg_Click(object sender, EventArgs e)
        {
            lblOutput.Text = calcOperations.tg(lblOutput.Text);
            setEnabledForNumbers(true);
        }

        private void btnLog10_Click(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = calcOperations.logarithm10(lblOutput.Text);
            }
            catch (Exception a) when (a.Message == "Mistake")
            {
                MessageBox.Show("Logarithm of a negative number or 0.");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            setEnabledForNumbers(true);
        }

        private void btnCtg_Click(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = calcOperations.ctg(lblOutput.Text);
            }
            catch (Exception a) when (a.Message == "Mistake")
            {
                MessageBox.Show("Tangent equal 0. Cotanget doesn't exist.");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            setEnabledForNumbers(true);
        }

        private void btnSquaring_Click(object sender, EventArgs e)
        {
            lblOutput.Text = calcOperations.square(lblOutput.Text);
            setEnabledForNumbers(true);
        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text[0] == '-')
                lblOutput.Text = lblOutput.Text.Remove(0, 1);
            else
                lblOutput.Text = "-" + lblOutput.Text;
            setEnabledForNumbers(true);
        }

        private void DEL_Click(object sender, EventArgs e)
        {
            if (lblOutput.Text.Length != 0)
                lblOutput.Text = lblOutput.Text.Remove(lblOutput.Text.Length - 1, 1);
            if (lblOutput.Text.Length == 1 && lblOutput.Text[0] == '-')
                lblOutput.Text = lblOutput.Text.Remove(0, 1);
            setEnabledForNumbers(true);
        }

        private void MC_Click(object sender, EventArgs e)
        {
            calcOperations.memoryClear();
        }

        private void MD_Click(object sender, EventArgs e)
        {
            calcOperations.memoryDelete();
        }

        private void MPlus_Click(object sender, EventArgs e)
        {
            calcOperations.memoryPlus(lblOutput.Text);
        }

        private void MMinus_Click(object sender, EventArgs e)
        {
            calcOperations.memoryMinus(lblOutput.Text);
        }
    }
}