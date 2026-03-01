using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Size = new Size(1100, 900);
            this.AutoScroll = true;
        }

        private void ClearAllTextboxes(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;
                }
                if (ctrl.Controls.Count > 0)
                {
                    ClearAllTextboxes(ctrl);
                }
            }
        }

        private void grossBTN_Click(object sender, EventArgs e)
        {
            double.TryParse(txtBIrateperhour.Text, out double BIRateperHr);
            double.TryParse(txtBIhourspercutoff.Text, out double BIHrperCutOff);
            double.TryParse(txtHIrateperhour.Text, out double HIRateperHr);
            double.TryParse(txtHIhourspercutoff.Text, out double HIHrperCutOff);
            double.TryParse(txtOIrateperhour.Text, out double OIRateperHr);
            double.TryParse(txtOIhourspercutoff.Text, out double OIHrperCutOff);

            double BIIncomeperCutoff = BIRateperHr * BIHrperCutOff;
            double HIIncomeperCutoff = HIRateperHr * HIHrperCutOff;
            double OIIncomeperCutoff = OIRateperHr * OIHrperCutOff;
            double GrossIncome = BIIncomeperCutoff + HIIncomeperCutoff + OIIncomeperCutoff;

            txtBIincomepercutoff.Text = BIIncomeperCutoff.ToString("N2");
            txtHIincomepercutoff.Text = HIIncomeperCutoff.ToString("N2");
            txtOIincomepercutoff.Text = OIIncomeperCutoff.ToString("N2");
            txtSIgrossincome.Text = GrossIncome.ToString("N2");


            double monthlyGross = GrossIncome * 2;

            txtRDpagibigcontribution.Text = "200.00";

            txtRDssscontribution.Text = CalculateSSS(monthlyGross).ToString("N2");
            txtRDincometaxcontribution.Text = CalculateTax(monthlyGross).ToString("N2");
            txtRDphilhealthcontribution.Text = (monthlyGross * 0.025).ToString("N2");
        }

        private void netincomeBTN_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtSIgrossincome.Text, out double GrossIncome))
            {
                MessageBox.Show("Please calculate Gross Income first.", "Missing Data");
                return;
            }

            double.TryParse(txtRDssscontribution.Text, out double SSSC);
            double.TryParse(txtRDphilhealthcontribution.Text, out double PhilHC);
            double.TryParse(txtRDpagibigcontribution.Text, out double PagibigC);
            double.TryParse(txtRDincometaxcontribution.Text, out double ITC);
            double.TryParse(txtODsssloan.Text, out double SSSL);
            double.TryParse(txtODpagibigloan.Text, out double PagibigL);
            double.TryParse(txtODfacultysavingsdeposit.Text, out double FacultyDeposit);
            double.TryParse(txtODfacultysavingsloan.Text, out double FacultyLoan);
            double.TryParse(txtODsalaryloan.Text, out double SalaryLoan);
            double.TryParse(txtODotherloans.Text, out double OtherLoan);

            double TotalDeduction = SSSC + PhilHC + PagibigC + ITC + SSSL + PagibigL + FacultyDeposit + FacultyLoan + SalaryLoan + OtherLoan;
            double NetIncome = GrossIncome - TotalDeduction;

            txtDStotaldeductions.Text = TotalDeduction.ToString("N2");
            txtSInetincome.Text = NetIncome.ToString("N2");
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSInetincome.Text))
            {
                MessageBox.Show("Please compute Net Income before saving.", "Warning");
                return;
            }

            Form2 payslip = new Form2();

            // 1. Employee Identification
            payslip.txtCompanyName.Text = "Lyceum of the Philippines University Cavite";
            payslip.txtEmployeeCode.Text = txtEmployeeNumber.Text;
            // Note: Ensure txtSurname, txtFirstName, txtMiddleName match your Form1 Designer names
            payslip.txtEmployeeName.Text = $"{txtSurname.Text}, {txtFirstName.Text} {txtMiddleName.Text}";
            payslip.txtDepartment.Text = txtDepartment.Text;
            payslip.txtCutOff.Text = txtPayDate.Text;
            payslip.txtPayPeriod.Text = txtPayDate.Text;

            // 2. Earnings & Hours (Actual Data)
            payslip.txtBasicHours.Text = txtBIhourspercutoff.Text;
            payslip.txtBasicTaxable.Text = txtBIincomepercutoff.Text;
            payslip.txtOtherTaxable.Text = txtOIincomepercutoff.Text;
            payslip.txtHonorariumTaxable.Text = txtHIincomepercutoff.Text;

            // 3. Mandatory Deductions
            payslip.txtWithholdingTax.Text = txtRDincometaxcontribution.Text;
            payslip.txtSSSContribution.Text = txtRDssscontribution.Text;
            payslip.txtHDMFContribution.Text = txtRDpagibigcontribution.Text;
            payslip.txtPhilHealthContribution.Text = txtRDphilhealthcontribution.Text;
            payslip.txtSSSWISPContribution.Text = "750.00";

            // 4. Totals & Summaries
            payslip.txtTotalEarnings.Text = txtSIgrossincome.Text;
            payslip.txtTotalDeductionSum.Text = txtDStotaldeductions.Text;
            payslip.txtTotalOvertime.Text = txtOIincomepercutoff.Text;

            payslip.txtSummaryGrossEarnings.Text = txtSIgrossincome.Text;
            payslip.txtSummaryTotalDeductions.Text = txtDStotaldeductions.Text;
            payslip.txtSummaryNetPay.Text = txtSInetincome.Text;

            // Pro-Tip: You don't need to manually set the "0.00" fields here 
            // if you set "0.00" as the default Text property in the Form2 Designer window.

            payslip.Show();
        }

        private void updateBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSInetincome.Text))
            {
                MessageBox.Show("No data found to update.", "Warning");
                return;
            }
            MessageBox.Show("Record updated successfully!", "Update Success");
        }

        private void newBTN_Click(object sender, EventArgs e)
        {
  
            ClearAllTextboxes(this);
            txtEmployeeNumber.Focus();
        }

        private double CalculateSSS(double monthlyGross)
        {
            double msc = monthlyGross;

            if (msc < 5000) msc = 5000;
            if (msc > 35000) msc = 35000;

            double totalEEShare = msc * 0.05;

            return totalEEShare / 2;
        }

        private double CalculateTax(double monthlyGross)
        {
            double annualTaxable = monthlyGross * 12;
            double annualTax = 0;

            if (annualTaxable <= 250000)
            {
                annualTax = 0;
            }
            else if (annualTaxable <= 400000)
            {
                annualTax = (annualTaxable - 250000) * 0.15;
            }
            else if (annualTaxable <= 800000)
            {
                annualTax = 22500 + (annualTaxable - 400000) * 0.20;
            }
            else if (annualTaxable <= 2000000)
            {
                annualTax = 102500 + (annualTaxable - 800000) * 0.25;
            }
            else if (annualTaxable <= 8000000)
            {
                annualTax = 402500 + (annualTaxable - 2000000) * 0.30;
            }
            else
            {
                annualTax = 2202500 + (annualTaxable - 8000000) * 0.35;
            }

            return annualTax / 24;
        }
    }


}