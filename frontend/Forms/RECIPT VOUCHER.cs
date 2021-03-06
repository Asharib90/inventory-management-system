﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace frontend.Forms
{
    public partial class FormRecipt : Form
    {
        SqlCommand cmd;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-EU1SO11;Initial Catalog=ALROUGI;Integrated Security=True");

        public FormRecipt()
        {
            InitializeComponent();
        }
        private void LoadTheme()
        {

            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = Themecolor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = Themecolor.SecondaryColor;
                }
            }
        }
        public void clearboxes()
        {
            nametb.Text = null;
            dateTP.Text = null;
            categoryCB.Text = "السيولة النقدية";
            RfromCB.Text = "مدير";
            priceIWCB.Text = null;
            priceTb.Text = null;
            discription.Text = null;

        }
        private void FormRecipt_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        void Print()
        {
            print.ReciptPrintForm f = new print.ReciptPrintForm(this);
            f.Show();
        }

        private void submitBT_Click(object sender, EventArgs e)
        {

            if (priceTb.Text != "")
            {
                Print();


                cmd = new SqlCommand("insert into recived values(N'" + nametb.Text + "',N'" + dateTP.Text + "',N'" + RfromCB.Text + "',N'" + categoryCB.Text + "','" + Int64.Parse(priceTb.Text) + "',N'" + priceIWCB.Text + "',N'" + discription.Text + "')", con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    clearboxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {

                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Insert Amount", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void priceTb_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
