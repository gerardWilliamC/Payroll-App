using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_Application
{
    public partial class Form2 : Form
    {
        public Form2(string Company, string ECode, string EName, string Dpt, string PayDate, 
            string BPHrs, string BPTax, string BPNonTax, string OverHrs, string OverTax, string OverNonTax,
            string HonHrs, string HonTax, string HonNonTax, string HAHrs, string HATax, string HANonTAx,
            string SubHrs, string SubTax, string SubNonTax, string TardyHrs, string TardyTax, string TardyNonTAx,
            string WithTax, string SSSContribute, string HDMF, string PHilHealth, string SSSWisp,
            string EARNINGS, string DEDUCTIONS, string OVERTIME, string GrossEarn, string Deduct, string NetPay)
        {
            InitializeComponent();

            lblCompany.Text = Company;
            lblEmpCode.Text = ECode;
            lblEmpName.Text = EName;
            lblDepartment.Text = Dpt;
            lblCutOff.Text = PayDate;
            lblPayPeriod.Text = PayDate;

            lblBPhrs.Text = BPHrs;
            lblBPTax.Text = BPTax;
            lblBPNonTax.Text = BPNonTax;

            lblOverHrs.Text = OverHrs;
            lblOverTax.Text = OverTax;
            lblOverNonTax.Text = OverNonTax;

            lblHonHrs.Text = HonHrs;
            lblHonTax.Text = HonTax;
            lblHonNonTax.Text = HonNonTax;

            lblHAHrs.Text = HAHrs;
            lblHATax.Text = HATax;
            lblHANonTax.Text = HANonTAx;

            lblSubHrs.Text = SubHrs;
            lblSubTax.Text = SubTax;
            lblSubNonTax.Text = SubNonTax;

            lblTardyHrs.Text = TardyHrs;
            lblTardyTax.Text = TardyTax;
            lblTardyNonTax.Text = TardyNonTAx;

            lblWithTax.Text = WithTax;
            lblSSSContribute.Text = SSSContribute;
            lblHDMFContribute.Text = HDMF;
            lblPHILHealth.Text = PHilHealth;
            lblSSSWisp.Text = SSSWisp;
            
            lblEARNINGS.Text = EARNINGS;
            lblDEDUCTIONS.Text = DEDUCTIONS;
            lblOVERTIME.Text = OVERTIME;

            lblGrossEarn.Text = GrossEarn;
            lblDeduct.Text = Deduct;
            lblNetPay.Text = NetPay;
        }
    }
}
