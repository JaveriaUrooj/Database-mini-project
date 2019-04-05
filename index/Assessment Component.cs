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
    public partial class Assessment_Component : Form
    {
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public Assessment_Component()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home a = new Home();
            this.Hide();
            a.Show();
        }
        /// <summary>
        /// this function is used to disply data of Rubrics in the combo box1.it uses te rubric id to display data.
        /// and displays data of assessments in combo box2 using assessmentId.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void Assessment_Component_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string que = "SELECT Details,Id FROM Rubric";
            conn.Open();
            SqlDataAdapter data = new SqlDataAdapter(que, conn);
            DataSet d = new DataSet();
            data.Fill(d);
            comboBox1.DisplayMember = "Details";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = d.Tables[0];
            
            
            
            string que2 = "SELECT Title,Id FROM Assessment";
            SqlDataAdapter data2 = new SqlDataAdapter(que2, conn);

            DataSet d2 = new DataSet();
            data2.Fill(d2);
            comboBox2.DisplayMember = "Title";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = d2.Tables[0];

            conn.Close();

        }
        /// <summary>
        /// this function is used to insert data of Assessment components into the AssessmentComponent table in database.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                string query = "INSERT INTO AssessmentComponent(Name, RubricId, TotalMarks,DateCreated, DateUpdated, AssessmentId) VALUES ('" + textBox1.Text + "', '"+comboBox1.SelectedValue+"' ,'" + textBox2.Text + "','"+DateTime.Now+ "','" + DateTime.Now + "' , '" + (comboBox2.SelectedValue) + "') ";
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
        /// this function is used to disply data of assessment components in the data grid view
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string que = "SELECT * FROM AssessmentComponent";
            conn.Open();
            using (SqlDataAdapter data = new SqlDataAdapter(que, conn))
            {
                DataSet d = new DataSet();
                data.Fill(d);
                dataGridView1.DataSource = d.Tables[0];
            }
        }
        /// <summary>
        /// this function is used to disply data of CLO in the combo box.it uses te clo id to display data.
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
                    string query = "DELETE FROM AssessmentComponent where Id='" + ID + "'";
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
                string name = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                int marks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TotalMarks"].Value.ToString());
                Assessment_Component_Edit c = new Assessment_Component_Edit(ID, name, marks);
                this.Hide();
                c.Show();
            }
        
        }
    }
}
