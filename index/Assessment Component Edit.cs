using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace index
{
    public partial class Assessment_Component_Edit : Form
    {
        public int IDD5;
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public Assessment_Component_Edit(int acid, string name, int marks)
        {
            InitializeComponent();
            IDD5 = acid;
            textBox1.Text = name;
            textBox2.Text =Convert.ToString( marks);
        }
        public Assessment_Component_Edit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this function uses UPDATE query to update the data of selected row.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {

                string query = "UPDATE AssessmentComponent SET name='" + textBox1.Text + "', TotalMarks='" + textBox2.Text + "', DateUpdated='"+DateTime.Now+"'  where Id='" + IDD5 + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated!");
                textBox1.Text = "";
                textBox2.Text = "";
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Assessment_Component ac = new Assessment_Component();
            this.Hide();
            ac.Show();
        }
    }
}
