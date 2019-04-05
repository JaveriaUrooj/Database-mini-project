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
    public partial class Home : Form
    {
        public string connstr = "Data Source=JAVERIA;Initial Catalog=ProjectB;Integrated Security=True";
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            this.Hide();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            Student_Attendance s = new Student_Attendance();
            this.Hide();
            s.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Rubrics r = new Rubrics();
            this.Hide();
            r.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Rubric_Level r = new Rubric_Level();
            this.Hide();
            r.Show();
        }
    }
}
