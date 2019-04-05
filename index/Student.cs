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

    public partial class Student : Form
    {
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        
        public Student()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// this function is used to insert data of students into the stdent table in database.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            if(conn.State==ConnectionState.Open)
            {
                string query = "INSERT INTO Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) VALUES ('" + textBox1.Text + "','"+textBox2.Text+ "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "') ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
            else
            {
                MessageBox.Show("Error Occured!");
            }
        }
        /// <summary>
        /// this function is used to disply data of students in the data grid view
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string que = "SELECT * FROM Student";
            conn.Open();
            using (SqlDataAdapter data=new SqlDataAdapter(que, conn))
            {
                DataSet d = new DataSet();
                data.Fill(d);
                dataGridView1.DataSource = d.Tables[0];
            }

        }

        /// <summary>
        /// this function uses a condition that if a button edit is pressed against a row, then it wii open a new form to update the data of that row
        /// and if button delete is pressed then that row will be deleted.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==dataGridView1.Columns["Delete"].Index )
            {
                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string query = "DELETE FROM Student where Id='" + ID + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted!");


                }
                else
                {
                    MessageBox.Show("Error Occured!");
                }
            }
            else
            {
                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                string name = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                string lname = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                string contact = dataGridView1.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
                string email = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                string Reg = dataGridView1.Rows[e.RowIndex].Cells["RegistrationNumber"].Value.ToString();
                int s = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Status"].Value.ToString());
                Form2 frm = new Form2(ID, name, lname, contact, email, Reg, s);
                this.Hide();
                frm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CLO c = new CLO();
            this.Hide();
            c.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assessment a = new Assessment();
            this.Hide();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Result r = new Result();
            this.Hide();
            r.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Class_attendance c = new Class_attendance();
            this.Hide();
            c.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Student_Attendance s = new Student_Attendance();
            this.Hide();
            s.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            this.Hide();
            h.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            CLO c = new CLO();
            this.Hide();
            c.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Assessment a = new Assessment();
            this.Hide();
            a.Show();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Result r = new Result();
            this.Hide();
            r.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Class_attendance c = new Class_attendance();
            this.Hide();
            c.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Student_Attendance s = new Student_Attendance();
            this.Hide();
            s.Show();
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            Home h = new Home();
            this.Hide();
            h.Show();
        }
    }
}
