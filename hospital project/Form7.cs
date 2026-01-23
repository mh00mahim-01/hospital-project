using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace hospital_project
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            DisplayUser();
        }

        SqlConnection Con = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=C:\Users\ASUS\OneDrive - American International University-Bangladesh\Documents\HMS.mdf;
              Integrated Security=True;
              Connect Timeout=30;
              Encrypt=False;
              TrustServerCertificate=True");

        private void DisplayUser()
        {
            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                string Query = "SELECT * FROM [User]";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter UserId");
                return;
            }

            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                string query = "DELETE FROM [User] WHERE UserId=@UserId";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@UserId", textBox1.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record Deleted Successfully");
                DisplayUser();
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
            if (textBox1.Text == "" || textBox2.Text == "" ||
                 textBox3.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Info Missing");
                return;
            }

            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                string query = @"UPDATE [User]
                                 SET Username=@Username,
                                     Password=@Password,
                                     Role=@Role
                                 WHERE UserId=@UserId";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@UserId", textBox1.Text);
                cmd.Parameters.AddWithValue("@Username", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                cmd.Parameters.AddWithValue("@Role", comboBox1.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record Updated Successfully");
                DisplayUser();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||
                textBox3.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Info Missing");
                return;
            }

            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                string query = @"INSERT INTO [User] (UserId, Username, Password, Role)
                                 VALUES (@UserId, @Username, @Password, @Role)";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@UserId", textBox1.Text);
                cmd.Parameters.AddWithValue("@Username", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                cmd.Parameters.AddWithValue("@Role", comboBox1.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record Added Successfully");
                DisplayUser();
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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            DisplayUser();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
