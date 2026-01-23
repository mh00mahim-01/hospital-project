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

        readonly SqlConnection Con = new SqlConnection(
        @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=""C:\Users\ASUS\OneDrive - American International University-Bangladesh\Documents\HMS.mdf"";
        Integrated Security=True;
        Connect Timeout=30;
        Encrypt=False");
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

        private void ClearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
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
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Missing Information");
                    return;
                }

                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                string query = "INSERT INTO Doctor (UserId, DocName, Spec, Qua) VALUES (@Id, @Name, @Spec, @Qua)";
                SqlCommand cmd = new SqlCommand(query, Con);

                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Spec", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Qua", textBox3.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Added Successfully");

                DisplayDoctor();
                ClearFields();
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

        private void Form3_Load(object sender, EventArgs e)
        {
            DisplayDoctor();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Select Doctor to Delete");
                    return;
                }

                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                string query = "DELETE FROM Doctor WHERE UserId=@Id";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Deleted Successfully");

                DisplayDoctor();
                ClearFields();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Select Doctor to Update");
                    return;
                }

                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                string query = "UPDATE Doctor SET DocName=@Name, Spec=@Spec, Qua=@Qua WHERE UserId=@Id";
                SqlCommand cmd = new SqlCommand(query, Con);

                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Spec", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Qua", textBox3.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Updated Successfully");

                DisplayDoctor();
                ClearFields();
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["UserId"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["DocName"].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells["Spec"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["Qua"].Value.ToString();
            }
        }
    }
}
