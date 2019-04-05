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
    public partial class Student_Attendance : Form
    {
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public Student_Attendance()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            this.Hide();
            f.Show();
        }
        /// <summary>
        /// this function is used to disply data of students in the combo box1.it uses te student id to display data.
        /// and displays data of class attendance in combo box2 using its Id.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void Student_Attendance_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string que = "SELECT RegistrationNumber,Id FROM Student";
            conn.Open();
            SqlDataAdapter data = new SqlDataAdapter(que, conn);
            DataSet d = new DataSet();
            data.Fill(d);
            comboBox2.DisplayMember = "RegistrationNumber";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = d.Tables[0];



            string que2 = "SELECT AttendanceDate,Id FROM ClassAttendance";
            SqlDataAdapter data2 = new SqlDataAdapter(que2, conn);

            DataSet d2 = new DataSet();
            data2.Fill(d2);
            comboBox1.DisplayMember = "AttendanceDate";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = d2.Tables[0];

            conn.Close();
        }
        /// <summary>
        /// this function is used to insert data of Student attendance into the StudenceAttendance table in database.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                string query = "INSERT INTO StudentAttendance(AttendanceId, StudentId, AttendanceStatus) VALUES ('" + comboBox1.SelectedItem + "' ,'" + comboBox2.SelectedItem+ "' , '" + Convert.ToInt32(textBox2.Text) + "' ) ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved!");

            }
            else
            {
                MessageBox.Show("Error Occured!");
            }
        }
        /// <summary>
        /// this function is used to disply data of Student attendance in the data grid view
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string que = "SELECT * FROM StudentAttendance";
            conn.Open();
            using (SqlDataAdapter data = new SqlDataAdapter(que, conn))
            {
                DataSet d = new DataSet();
                data.Fill(d);
                dataGridView1.DataSource = d.Tables[0];
            }
        }
    }
}
