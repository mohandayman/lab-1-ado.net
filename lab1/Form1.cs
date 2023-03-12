using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void connect_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet11);
            sqlConnection1.Close();
            dataGridView1.DataSource =  dataSet11.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow drow = dataSet11.Tables[0].NewRow();
            drow[0] =int.Parse(emp_id.Text);
            drow["empName"] = emp_name.Text;
            drow["deptId"]  = int.Parse(dept_num.Text); 
            dataSet11.Tables[0].Rows.Add(drow);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var recordId = int.Parse(emp_id.Text);
            DataRow updated_row = dataSet11.Tables[0].Rows.Find(recordId);
            if (updated_row != null) {
                updated_row["empName"] = emp_name.Text;
                updated_row["deptId"] = int.Parse(dept_num.Text);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Update(dataSet11);
            sqlConnection1.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();

        }
    }
}
