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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            DisplayAppointments();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(
  @"Data Source=(LocalDB)\MSSQLLocalDB;
      AttachDbFilename=""D:\Documents\Hospital p.mdf"";Integrated Security=True;Connect Timeout=30;Encrypt=True;
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



       

       

        private void button2_Click_1(object sender, EventArgs e)
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
    }
    }


