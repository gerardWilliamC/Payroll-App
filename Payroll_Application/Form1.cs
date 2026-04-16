using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Payroll_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RegularDeduction(double GrossIncome)
        {
            double sss = 0;
            double msc = 0;

            if (GrossIncome < 5250)
                msc = 5000;
            else if (GrossIncome >= 34750)
                msc = 35000;
            else
            {
                msc = Math.Floor((GrossIncome - 250) / 500) * 500 + 500;
            }
            sss = msc * 0.05;
            txtSSSContribute.Text = (sss).ToString("N2");

            double PHILHealth = 0;
            double PHILrate = 0.05;
            double PHILC = 100000;
            double PHILF = 10000;
            if (GrossIncome <= PHILF)
                PHILHealth = (PHILF * PHILrate) / 2;
            else if (GrossIncome >= PHILC)
                PHILHealth = (PHILC * PHILrate) / 2;
            else
                PHILHealth = (GrossIncome * PHILrate) / 2;
            txtPhilHContribute.Text = (PHILHealth).ToString("N2");

            double PAGIBIG = 0;
            double PAGIBIGFund = Math.Min(GrossIncome, 10000);
            if (GrossIncome <= 1500)
                PAGIBIG = PAGIBIGFund * 0.01;
            else 
                PAGIBIG = PAGIBIGFund * 0.02;
            txtPagibigContribute.Text = (PAGIBIG).ToString("N2");

            double TAX = 0;
            if (GrossIncome <= 20833)
                TAX = 0;
            else if (GrossIncome <= 33332)
                TAX = (GrossIncome - 20833) * 0.15; 
            else if (GrossIncome <= 66666)
                TAX = 1875 + (GrossIncome - 33333) * 0.20;
            else if (GrossIncome <= 166666)
                TAX = 8541.8 + (GrossIncome - 66667) * 0.25; 
            else if (GrossIncome <= 666666)
                TAX = 33541.8 + (GrossIncome - 166667) * 0.30; 
            else
                TAX = 183541.8 + (GrossIncome - 666667) * 0.35; 
            txtIncomeTaxContribute.Text = (TAX).ToString("N2");

          
        }
        private void btnGrossIncome_Click(object sender, EventArgs e)
        {
            double BIRateperHr, BIHrperCutOff, HIRateperHr, HIHrperCutOff, OIRateperHr, OIHrperCutOff;
            double.TryParse(txtBIRateperHr.Text, out BIRateperHr);
            double.TryParse(txtBIHrperCutoff.Text, out BIHrperCutOff);
            double.TryParse(txtHIRateperHr.Text, out HIRateperHr);
            double.TryParse(txtHIHrperCutoff.Text, out HIHrperCutOff);
            double.TryParse(txtOIRateperHr.Text, out OIRateperHr);
            double.TryParse(txtOIHrperCutoff.Text, out OIHrperCutOff);

            double BIIncomeperCutoff = BIRateperHr * BIHrperCutOff;
            double HIIncomeperCutoff = HIRateperHr * HIHrperCutOff;
            double OIIncomeperCutoff = OIRateperHr * OIHrperCutOff;
            double GrossIncome = BIIncomeperCutoff + HIIncomeperCutoff + OIIncomeperCutoff;

            txtBIIncomeperCutoff.Text = (BIIncomeperCutoff).ToString("N2");
            txtHIIncomeperCutoff.Text = (HIIncomeperCutoff).ToString("N2");
            txtOIIncomeperCutoff.Text = (OIIncomeperCutoff).ToString("N2");
            txtGrossIncome.Text = (GrossIncome).ToString("N2");
        }

        private void btnNetIncome_Click(object sender, EventArgs e)
        {
            double.TryParse(txtGrossIncome.Text, out double GrossIncome);
            if (!double.TryParse(txtGrossIncome.Text, out GrossIncome))
            {
                MessageBox.Show("Please enter a valid Gross Income.");
                return;
            }
            RegularDeduction(GrossIncome);

            double SSSC, PhilHC, PagibigC, ITC, SSSL, PagibigL, FacultyDeposit, FacultyLoan, SalaryLoan, OtherLoan;
            double.TryParse(txtSSSContribute.Text, out SSSC);
            double.TryParse(txtPhilHContribute.Text, out PhilHC);
            double.TryParse(txtPagibigContribute.Text, out PagibigC);
            double.TryParse(txtIncomeTaxContribute.Text, out ITC);

            double.TryParse(txtSSSLoan.Text, out SSSL);
            double.TryParse(txtPagibigLoan.Text, out PagibigL);
            double.TryParse(txtFacultyDeposit.Text, out FacultyDeposit);
            double.TryParse(txtFacultyLoan.Text, out FacultyLoan);
            double.TryParse(txtSalaryLoan.Text, out SalaryLoan);
            double.TryParse(txtOtherLoan.Text, out OtherLoan);
            double TotalDeduction = SSSC + PhilHC + PagibigC + ITC + SSSL + PagibigL + FacultyDeposit + FacultyLoan + SalaryLoan + OtherLoan;
            double NetIncome = GrossIncome - TotalDeduction;
            txtTotalDeduction.Text = (TotalDeduction).ToString("N2");
            txtNetIncome.Text = (NetIncome).ToString("N2");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Company = "Lyceum of the Philippines University Cavite";
            string ECode = txtEmployeeNumber.Text.ToString();
            string EName = txtFirstName.Text + " " + txtMiddleName.Text + " " + txtSurname.Text;
            string Dpt = txtDepartment.Text.ToString();
            string PayDate = dtpPayDate.Text.ToString();
            string BPHrs = txtBIRateperHr.Text;
            string BPTax = string.Empty;
            string BPNonTax = string.Empty;
            string OverHrs = txtOIRateperHr.Text;
            string OverTax = string.Empty;
            string OverNonTax = string.Empty;
            string HonHrs = txtHIRateperHr.Text;
            string HonTax = string.Empty;
            string HonNonTax = string.Empty;
            string HAHrs = string.Empty;
            string HATax = string.Empty;
            string HANonTAx = string.Empty;
            string SubHrs = string.Empty;
            string SubTax = string.Empty;
            string SubNonTax = string.Empty;
            string TardyHrs = string.Empty;
            string TardyTax = string.Empty;
            string TardyNonTAx = string.Empty;
            string WithTax = txtIncomeTaxContribute.Text;
            string SSSContribute = txtSSSContribute.Text.ToString();
            string HDMF = string.Empty;
            string PHilHealth = txtPhilHContribute.Text.ToString();
            string SSSWisp = "750.00";
            string EARNINGS = txtGrossIncome.Text.ToString();
            string DEDUCTIONS = txtTotalDeduction.Text.ToString();
            string OVERTIME = string.Empty;
            string GrossEarn = txtGrossIncome.Text.ToString();
            string Deduct = txtTotalDeduction.Text.ToString();
            string NetPay = txtNetIncome.Text.ToString();

            Form2 payslip = new Form2(Company,  ECode,  EName,  Dpt, PayDate,
                BPHrs, BPTax,  BPNonTax,  OverHrs,  OverTax,  OverNonTax,
                HonHrs,  HonTax,  HonNonTax,  HAHrs,  HATax,  HANonTAx,
                SubHrs,  SubTax,  SubNonTax,  TardyHrs,  TardyTax,  TardyNonTAx,
                WithTax,  SSSContribute,  HDMF,  PHilHealth,  SSSWisp,
                EARNINGS,  DEDUCTIONS,  OVERTIME,  GrossEarn,  Deduct,  NetPay);
            payslip.ShowDialog();
            MessageBox.Show("Saved and Payslip Generated.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNetIncome.Text))
            {
                MessageBox.Show("No data found to update.", "Warning");
                return;
            }
            MessageBox.Show("Record updated successfully!", "Update Success");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            GroupBox[] groups = { gboxEmployeeInfo, gboxBasicIncome, gboxHonorariumIncome, gboxOtherIncome,
                gboxSummaryIncome, gboxRegulardeductions, gboxOtherDeductions, gbDeductionSummary };

            foreach (var group in groups)
            {
                foreach (Control control in group.Controls)
                {
                    if (control is TextBox) control.Text = string.Empty;
                }
            }
        }
    }
}
