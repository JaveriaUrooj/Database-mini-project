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
    public partial class RubricLevelEdit : Form
    {
        public int IDD3;
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public RubricLevelEdit(int rlid, string detailss, int measure)
        {
            InitializeComponent();
            IDD3 = rlid;
            textBox1.Text = detailss;
            textBox2.Text = Convert.ToString(measure);
        }
        public RubricLevelEdit()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rubric_Level r = new Rubric_Level();
            this.Hide();
            r.Show();
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

                string query = "UPDATE RubricLevel SET Details='" + textBox1.Text + "', MeasurementLevel='"+textBox2.Text+"'  where Id='" + IDD3 + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated!");
                textBox1.Text = "";
                textBox2.Text = "";

            }
        }
    }
}
