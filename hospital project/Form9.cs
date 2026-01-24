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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(
    @"Data Source=(LocalDB)\MSSQLLocalDB;
      AttachDbFilename=C:\Users\ASUS\OneDrive - American International University-Bangladesh\Documents\HMS.mdf;
      Integrated Security=True;
      Connect Timeout=30;
      Encrypt=False");


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||   // Patient Name
                string.IsNullOrWhiteSpace(textBox2.Text) ||   // Age
                string.IsNullOrWhiteSpace(textBox3.Text) ||   // Phone
                string.IsNullOrWhiteSpace(comboBox1.Text) ||  // Gender
                string.IsNullOrWhiteSpace(comboBox2.Text) ||  // Blood Group
                string.IsNullOrWhiteSpace(textBox4.Text))     // Major Disease
            {
                MessageBox.Show("Please fill up all the information first!",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Con.Open();

                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO PTable (PName, Date, Time) " +
                    "VALUES (@PName, @Date, @Time)", Con))
                {
                    cmd.Parameters.AddWithValue("@PName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Time", dateTimePicker2.Value.TimeOfDay);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Appointment Confirmed",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Optional: Clear fields
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                Con.Close();
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }
    }
}
