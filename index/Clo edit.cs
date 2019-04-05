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
    public partial class Clo_edit : Form
    {
        public int IDD;
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public Clo_edit(int id, string name)
        {
            InitializeComponent();
            IDD = id;
            textBox1.Text = name;
        }
        public Clo_edit()
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

                string query = "UPDATE Clo SET Name='" + textBox1.Text + "',DateUpdated='" + DateTime.Now + "'  where Id='" + IDD + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated!");
                textBox1.Text = "";
               

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CLO c = new CLO();
            this.Hide();
            c.Show();
        }
    }
}
