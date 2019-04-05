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
    public partial class Assessment_edit : Form
    {
        public int IDD4;
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public Assessment_edit(int aid, string title, int marks, int weigh)
        {
            InitializeComponent();
            IDD4 = aid;
            textBox1.Text = title;
            textBox2.Text = Convert.ToString(marks);
            textBox3.Text = Convert.ToString(weigh);
        }
        public Assessment_edit()
        {
            InitializeComponent();
        }

        private void Assessment_edit_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Assessment a = new Assessment();
            this.Hide();
            a.Show();
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

                string query = "UPDATE Assessment SET Title='" + textBox1.Text + "', TotalMarks='" + textBox2.Text + "', TotalWeightage='"+textBox3.Text+"'  where Id='" + IDD4 + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }
    }
}
