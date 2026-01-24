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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            
        }

        SqlConnection con = new SqlConnection(
 @"Data Source=(LocalDB)\MSSQLLocalDB;
  AttachDbFilename=D:\Documents\Hospital p.mdf;
  Integrated Security=True;
  Connect Timeout=30");


        private void Form4_Load(object sender, EventArgs e)
        {
            LoadDoctor();
        }
        void LoadDoctor()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT UserId, DocName FROM Doctor", con);

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


        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }
     

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;

            DataRowView drv = listBox1.SelectedItem as DataRowView;

            int doctorUserId = Convert.ToInt32(drv["UserId"]);

            LoadDoctorInfo(doctorUserId);
        }
        void LoadDoctorInfo(int userId)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT Spec, Qua FROM Doctor WHERE UserId=@id", con);

            cmd.Parameters.AddWithValue("@id", userId);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                label3.Text = dr["Spec"].ToString();
                label4.Text = dr["Qua"].ToString();
            }

            dr.Close();
            con.Close();
        }

    }
}
