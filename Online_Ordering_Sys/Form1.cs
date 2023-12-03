namespace Online_Ordering_Sys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void parrotSuperButton1_Click(object sender, EventArgs e) // Product Button
        {
            Product ProductInfo = new Product();
            ProductInfo.Show();
        }

        private void parrotSuperButton2_Click(object sender, EventArgs e) // Order Button
        {
            Order OrderInfo = new Order();
            OrderInfo.Show();
        }

        private void parrotSuperButton3_Click(object sender, EventArgs e) // Customer Button
        {
            Customer CustomerInfo = new Customer();
            CustomerInfo.Show();
        }

        private void parrotSuperButton4_Click(object sender, EventArgs e) // Seller Button
        {
            Seller SellerInfo = new Seller();
            SellerInfo.Show();
        }

        private void parrotSuperButton5_Click(object sender, EventArgs e) // Delivery Button
        {
            Delivery DeliveryInfo = new Delivery();
            DeliveryInfo.Show();
        }

        private void parrotSuperButton6_Click(object sender, EventArgs e) // Payment Button
        {
            Payment PaymentInfo = new Payment();
            PaymentInfo.Show();
        }
    }
}