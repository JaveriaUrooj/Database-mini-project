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
    public partial class Class_attendance : Form
    {
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public Class_attendance()
        {

            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            this.Hide();
            f.Show();
        }
        /// <summary>
        /// this function is used to insert data of Class attendnce into the database.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                string query = "INSERT INTO ClassAttendance(AttendanceDate) VALUES ('" + dateTimePicker1.Value + "') ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved!");

            }
            else
            {
                MessageBox.Show("Error Occured!");
            }
        }
    }
}
