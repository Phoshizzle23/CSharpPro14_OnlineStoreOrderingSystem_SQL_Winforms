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

namespace Online_Ordering_Sys
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");
        private void nightPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void parrotSuperButton3_Click(object sender, EventArgs e) // Del
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete customertab where customer_id = @customer_id", con);

            cnn.Parameters.AddWithValue("@Customer_ID", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            BindData();
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");

            SqlCommand cnn = new SqlCommand("Select * from customertab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void parrotSuperButton1_Click(object sender, EventArgs e) //Add
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into customertab values(@customer_id,@customer_name,@phone,@address)", con);

            cnn.Parameters.AddWithValue("@Customer_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Customer_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@Phone", (textBox3.Text));

            cnn.Parameters.AddWithValue("@address", textBox4.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void parrotSuperButton2_Click(object sender, EventArgs e) //new
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
