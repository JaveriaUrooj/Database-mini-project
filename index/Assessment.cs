﻿using System;
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
    public partial class Assessment : Form
    {
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public Assessment()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this function is used to insert data of assessments into the assessment table in database.
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                string query = "INSERT INTO Assessment(Title,DateCreated,TotalMarks,TotalWeightage) VALUES ('" + textBox1.Text + "', '"+DateTime.Now+"'  ,'" + textBox2.Text + "','" + textBox3.Text + "') ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                
            }
            else
            {
                MessageBox.Show("Error Occured!");
            }

        }
        /// <summary>
        /// this function is used to disply data of assessments in the data grid view
        /// </summary>
        /// <param name="sender">Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event</param>
        /// <param name="e">EventArgs e is a parameter called e that contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            string que = "SELECT * FROM Assessment";
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
                    string query = "DELETE FROM Assessment where Id='" + ID + "'";
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
                string title = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                int marks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TotalMarks"].Value.ToString());
                int weightage = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TotalWeightage"].Value.ToString());
               
                Assessment_edit frm = new Assessment_edit(ID, title,marks,weightage);
                this.Hide();
                frm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home f = new Home();
            this.Hide();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Assessment_Component ac = new Assessment_Component();
            this.Hide();
            ac.Show();
        }
    }
}
