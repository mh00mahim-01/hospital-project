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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=C:\Users\ASUS\OneDrive - American International University-Bangladesh\Documents\HMS.mdf;
              Integrated Security=True;
              Connect Timeout=30;
              Encrypt=False;
              TrustServerCertificate=True");



        private int GenerateUserId()
        {
            int newId = 1;

            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                string query = "SELECT ISNULL(MAX(UserId), 0) FROM [User]";
                SqlCommand cmd = new SqlCommand(query, Con);
                newId = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }

            return newId;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void ButtonSign_Click(object sender, EventArgs e)
        {
            string email = textBox2.Text.Trim();     // Username
            string password = textBox4.Text.Trim();
            string confirmPassword = textBox5.Text.Trim();
            string role = comboBox1.Text.Trim();

            if (email == "" || password == "" || confirmPassword == "" || role == "")
            {
                MessageBox.Show("Not all the boxes are filled");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match");
                return;
            }

            int userId = GenerateUserId(); // 🔥 AUTO USER ID

            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                string query = @"INSERT INTO [User] (UserId, Username, Password, Role)
                         VALUES (@UserId, @Username, @Password, @Role)";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Username", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.ExecuteNonQuery();

                MessageBox.Show("User is added successfully.\nUser ID: " + userId);
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

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        
       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
