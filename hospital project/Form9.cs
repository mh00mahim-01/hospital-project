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
            
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||   
                string.IsNullOrWhiteSpace(textBox2.Text) ||   
                string.IsNullOrWhiteSpace(textBox3.Text) ||   
                string.IsNullOrWhiteSpace(comboBox1.Text) ||  
                string.IsNullOrWhiteSpace(comboBox2.Text) ||  
                string.IsNullOrWhiteSpace(textBox4.Text))     
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
                    "INSERT INTO PTable (PName, Date, Time, DoctorId) VALUES (@PName, @Date, @Time, @DoctorId)", Con))
                {
                    cmd.Parameters.AddWithValue("@PName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@Time", dateTimePicker2.Value.TimeOfDay);
                    cmd.Parameters.AddWithValue("@DoctorId", Form4.SelectedDoctorId);

                    cmd.ExecuteNonQuery();
                }


                string appointmentDate = dateTimePicker1.Value.ToString("dd MMM yyyy");
                string appointmentTime = dateTimePicker2.Value.ToString("hh:mm tt");

                MessageBox.Show(
                    $"Appointment Confirmed!\n\nDate: {appointmentDate}\nTime: {appointmentTime}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

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

        private void Form9_Load(object sender, EventArgs e)
        {

            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(10);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday ||
                           dateTimePicker1.Value.DayOfWeek == DayOfWeek.Saturday)
            {
                MessageBox.Show("Appointments cannot be booked on Fridays or Saturdays.",
                                "Invalid Day",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                
                DateTime nextDay = dateTimePicker1.Value.AddDays(1);
                while (nextDay.DayOfWeek == DayOfWeek.Friday || nextDay.DayOfWeek == DayOfWeek.Saturday)
                {
                    nextDay = nextDay.AddDays(1);
                }

                
                if (nextDay <= dateTimePicker1.MaxDate)
                {
                    dateTimePicker1.Value = nextDay;
                }
                else
                {
                    
                    dateTimePicker1.Value = dateTimePicker1.MinDate;
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            TimeSpan minTime = new TimeSpan(10, 0, 0);
            TimeSpan maxTime = new TimeSpan(16, 0, 0);

            
            TimeSpan selectedTime = dateTimePicker2.Value.TimeOfDay;

            
            if (selectedTime < minTime || selectedTime > maxTime)
            {
                MessageBox.Show("Please select a time between 10:00 AM and 4:00 PM.",
                                "Invalid Time",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                
                dateTimePicker2.Value = DateTime.Today.Add(minTime);
            }
        }
    }
}

