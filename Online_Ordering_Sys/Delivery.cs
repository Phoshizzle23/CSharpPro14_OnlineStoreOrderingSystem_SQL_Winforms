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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Online_Ordering_Sys
{
    public partial class Delivery : Form
    {
        public Delivery()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");
        private void Delivery_Load(object sender, EventArgs e)
        {
            BindData();
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");

            SqlCommand cnn = new SqlCommand("Select * from delivery", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void parrotSuperButton1_Click(object sender, EventArgs e) //Add
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into delivery values(@delivery_id,@customer_name,@product_name,@deliverydate)", con);

            cnn.Parameters.AddWithValue("@Delivery_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Customer_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@Product_Name", textBox3.Text);

            cnn.Parameters.AddWithValue("@DeliveryDate", DateTime.Parse(dateTimePicker1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void parrotSuperButton2_Click(object sender, EventArgs e) //New
        {
            textBox1.Text = "";

            textBox2.Text = "";

            textBox3.Text = "";

            dateTimePicker1.Text = "";
        }

        private void parrotSuperButton3_Click(object sender, EventArgs e) //del
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete delivery where delivery_id = @delivery_id", con);

            cnn.Parameters.AddWithValue("@Delivery_ID", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
