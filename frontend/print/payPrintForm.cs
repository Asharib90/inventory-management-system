﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend.print
{
    public partial class payPrintForm : Form
    {
        Forms.FPayment pay;
        public payPrintForm(Forms.FPayment pay)
        {
            InitializeComponent();
            this.pay = pay;
        }
        void payment()
        {
            payPrintReport p = new payPrintReport();
            p.SetParameterValue("Name", pay.nametb.Text);
            p.SetParameterValue("Amount", pay.priceTb.Text);
            p.SetParameterValue("amountIW", pay.priceIWCB.Text);
            p.SetParameterValue("cashCheque", pay.amountypeCB.Text);
            p.SetParameterValue("description", pay.discription.Text);
            p.SetParameterValue("Date", pay.dateTP.Text);
            p.SetParameterValue("Paidto", pay.category.Text);
            crystalReportViewer1.ReportSource = p;
            crystalReportViewer1.Refresh();

        }

        private void payPrintForm_Load(object sender, EventArgs e)
        {
            payment();
        }
    }
}
