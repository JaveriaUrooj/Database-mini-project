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
    public partial class Rubric_Level : Form
    {
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public Rubric_Level()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home r = new Home();
            this.Hide();
            r.Show();
        }
        /// <summary>
        /// this function is used to disply data of Rubrics in the combo box.it uses te rubric id to display data.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void Rubric_Level_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string que = "SELECT Details,Id FROM Rubric";
            conn.Open();
            using (SqlDataAdapter data = new SqlDataAdapter(que, conn))
            {
                DataSet d = new DataSet();
                data.Fill(d);
                comboBox1.DisplayMember = "Details";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = d.Tables[0];
            }
        }
        
        /// <summary>
        /// this function is used to insert data of rubric levels against each rubric  into the RubricLevel table in database.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                string query = "INSERT INTO RubricLevel(Details, MeasurementLevel, RubricId) VALUES ('" + textBox1.Text + "', '"+textBox2.Text +"', '" + (comboBox1.SelectedValue) + "') ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved!");
                textBox1.Text = "";
                textBox2.Text = "";

            }
            else
            {
                MessageBox.Show("Error Occured!");
            }
        }
        /// <summary>
        /// this function is used to disply data of rubric levels in the data grid view
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string que = "SELECT * FROM RubricLevel";
            conn.Open();
            using (SqlDataAdapter data = new SqlDataAdapter(que, conn))
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
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string query = "DELETE FROM RubricLevel where Id='" + ID + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted!");


                }
                else
                {
                    MessageBox.Show("Error Occured!");
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                string name = dataGridView1.Rows[e.RowIndex].Cells["Details"].Value.ToString();
                int measure = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MeasurementLevel"].Value.ToString());
                RubricLevelEdit c = new RubricLevelEdit(ID, name, measure);
                this.Hide();
                c.Show();
            }
        }
    }
}
