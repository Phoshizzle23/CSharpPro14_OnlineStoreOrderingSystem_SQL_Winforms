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

namespace Online_Ordering_Sys
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void parrotSuperButton1_Click(object sender, EventArgs e) //Add Button
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into producttab values(@product_id,@product_name,@product_price)", con);

            cnn.Parameters.AddWithValue("@Product_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Product_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@Product_Price", textBox3.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Product_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");

            SqlCommand cnn = new SqlCommand("Select * from producttab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void parrotSuperButton2_Click(object sender, EventArgs e) //New button
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void parrotSuperButton3_Click(object sender, EventArgs e) // Del button
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete producttab where product_id = @product_id", con);

            cnn.Parameters.AddWithValue("@Product_ID", int.Parse(textBox1.Text));

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
