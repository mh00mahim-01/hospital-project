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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            DisplayAppointments();
        }

        SqlConnection Con = new SqlConnection(
    @"Data Source=(LocalDB)\MSSQLLocalDB;
      AttachDbFilename=C:\Users\ASUS\OneDrive - American International University-Bangladesh\Documents\HMS.mdf;
      Integrated Security=True;
      Connect Timeout=30;
      Encrypt=False");


        private void DisplayAppointments()
        {
            try
            {
                Con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(
                    "SELECT PName, Date, Time FROM PTable", Con);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView1.DataSource = dt;

                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete");
                return;
            }

            try
            {
                string pname = dataGridView1.SelectedRows[0].Cells["PName"].Value.ToString();

                Con.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM PTable WHERE PName = @PName", Con);

                cmd.Parameters.AddWithValue("@PName", pname);
                cmd.ExecuteNonQuery();

                Con.Close();

                MessageBox.Show("Appointment Deleted");
                DisplayAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}
