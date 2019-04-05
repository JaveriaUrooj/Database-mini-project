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
    public partial class Result : Form
    {
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public Result()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            this.Hide();
            f.Show();
        }
        /// <summary>
        /// this function is used to disply data of students in the combo box1.it uses te student id to display data.
        /// and displays data of assessment component in combo box2 using its Id. and displays data of rubric evel in combo box 3.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void Result_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string que = "SELECT RegistrationNumber,Id FROM Student";
            conn.Open();
            SqlDataAdapter data = new SqlDataAdapter(que, conn);
            DataSet d = new DataSet();
            data.Fill(d);
            comboBox1.DisplayMember = "RegistrationNumber";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = d.Tables[0];



            string que2 = "SELECT Name,Id FROM AssessmentComponent";
            SqlDataAdapter data2 = new SqlDataAdapter(que2, conn);

            DataSet d2 = new DataSet();
            data2.Fill(d2);
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = d2.Tables[0];


            string que3 = "SELECT Details,Id FROM RubricLevel";
            SqlDataAdapter data3 = new SqlDataAdapter(que3, conn);

            DataSet d3 = new DataSet();
            data3.Fill(d3);
            comboBox3.DisplayMember = "Details";
            comboBox3.ValueMember = "Id";
            comboBox3.DataSource = d3.Tables[0];


            conn.Close();
        }
    }
}
