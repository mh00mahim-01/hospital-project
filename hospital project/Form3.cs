using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospital_project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            DisplayDoctor();
        }

        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ASUS\OneDrive - American International University-Bangladesh\Documents\HMS.mdf"";Integrated Security=True;Connect Timeout=30");
        private void DisplayDoctor()
        {
            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();
                string Query = "SELECT * FROM Doctor";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            { 
                Con.Close();
            }
               
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DisplayDoctor();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }
    }
}
