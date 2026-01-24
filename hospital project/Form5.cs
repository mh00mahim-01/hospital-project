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

namespace hospital_project
{
    public partial class Form5 : Form
    {
        // 🔹 NEW: Database connection added
        SqlConnection Con = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;
              AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Documents\Hospital p.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=True
              Integrated Security=True;
              Connect Timeout=30;
              Encrypt=False;
              TrustServerCertificate=True");

        public Form5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // 🔒 Fixed Admin Login (UNCHANGED as requested)
            if (txtUsername.Text == "admin" && txtPassword.Text == "12345")
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
                return;
            }

            // ❌ Empty Check (FIXED condition)
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all the boxes!!");
                return;
            }

            try
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();

                // 🔹 NEW: Fetch role from User table
                string query = @"SELECT Role 
                                 FROM [User]
                                 WHERE Username=@Username AND Password=@Password";

                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string role = dr["Role"].ToString().ToLower();

                    // 🩺 Doctor Login
                    if (role == "doctor")
                    {
                        Form8 doctorForm = new Form8();
                        doctorForm.Show();
                        this.Hide();
                    }
                    // 👤 Patient Login
                    else if (role == "patient")
                    {
                        Form4 patientForm = new Form4();
                        patientForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid role assigned!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
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

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
