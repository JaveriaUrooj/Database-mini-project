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
    public partial class Form2 : Form
    {
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public int Id;

        public Form2(int id, string name, string lname, string cont, string email, string reg, int status)
        {
            InitializeComponent();
            Id = id;
            textBox1.Text = name;
            textBox2.Text = lname;
            textBox3.Text = cont;
            textBox4.Text = email;
            textBox5.Text = reg;
            textBox6.Text = Convert.ToString(status);
        }
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student frm = new Student();
            this.Hide();
            frm.Show();
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
                
                string query = "UPDATE Student SET FirstName='"+textBox1.Text+ "', LastName='" + textBox2.Text + "',Contact='" + textBox3.Text + "',Email='" + textBox4.Text + "',RegistrationNumber='" + textBox5.Text + "',Status='" + textBox6.Text + "' where Id='" +Id+ "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
