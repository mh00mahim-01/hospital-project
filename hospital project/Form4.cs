using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospital_project
{
    public partial class Form4 : Form
    {
        public Form4()
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

        void LoadDoctor()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT UserId, DocName FROM Doctor", Con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                listBox1.DataSource = dt;
                listBox1.DisplayMember = "DocName";   // what patient sees
                listBox1.ValueMember = "UserId";     // hidden ID
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load doctors: " + ex.Message);
            }
        }



        private void Form4_Load(object sender, EventArgs e)
        {
            LoadDoctor();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

       
      

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

       

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        void LoadDoctorInfo(int userId)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT Spec, Qua FROM Doctor WHERE UserId=@id", Con);

            cmd.Parameters.AddWithValue("@id", userId);

            Con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                label3.Text = dr["Spec"].ToString();
                label4.Text = dr["Qua"].ToString();
            }

            dr.Close();
            Con.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            DataRowView drv = listBox1.SelectedItem as DataRowView;

            int doctorUserId = Convert.ToInt32(drv["UserId"]);

            LoadDoctorInfo(doctorUserId);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }



    } 
}
