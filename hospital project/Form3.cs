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
            try 
            {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Info Missing");
                }
                else
                {
                    Con.Open();
                    string query = "insert into Doctor values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Added Successfully");
                    DisplayDoctor();
                }
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
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                string query = "DELETE FROM Doctor WHERE DocID=@id";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record Deleted Successfully");
                DisplayDoctor();
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
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Info Missing");
                }
                else
                {
                    if (Con.State == ConnectionState.Closed)
                        Con.Open();
                    string query = "update Doctor Set DocName = @DocName, DocGen = @DocGen, DocQua = @DocQua, DocEXP = @DocEXP where DocId = @DocId ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@DocName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@DocGen", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@DocQua", textBox3.Text);
                    cmd.Parameters.AddWithValue("@DocEXP", textBox4.Text);
                    cmd.Parameters.AddWithValue("@DocId", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    //Con.Close();
                    MessageBox.Show("Record Updated Successfully");
                    DisplayDoctor();
                }
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
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

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
    }
}
