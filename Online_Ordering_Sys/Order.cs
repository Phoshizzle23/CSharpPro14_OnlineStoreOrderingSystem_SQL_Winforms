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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");
        private void Order_Load(object sender, EventArgs e)
        {
            BindData();
        }
        void BindData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");

            SqlCommand cnn = new SqlCommand("Select * from ordertab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void parrotSuperButton1_Click(object sender, EventArgs e) //Add
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("insert into ordertab values(@order_id,@product_name,@order_date,@price)", con);

            cnn.Parameters.AddWithValue("@Order_ID", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Product_Name", textBox2.Text);

            cnn.Parameters.AddWithValue("@Order_Date", DateTime.Parse(dateTimePicker1.Text));

            cnn.Parameters.AddWithValue("@Price", textBox4.Text);

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();

            MessageBox.Show("Record Added Successfully", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void parrotSuperButton2_Click(object sender, EventArgs e) //Add
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            textBox4.Text = "";
        }

        private void parrotSuperButton3_Click(object sender, EventArgs e) //Del
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5KJ157N\MATTDATABASEPRO;Initial Catalog=onlineOrderDB;Persist Security Info=True;User ID=sa;Password=1234qwer");

            con.Open();

            SqlCommand cnn = new SqlCommand("delete ordertab where order_id = @order_id", con);

            cnn.Parameters.AddWithValue("@Order_ID", int.Parse(textBox1.Text));

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
