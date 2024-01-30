using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-74N9OPR;Initial Catalog=Clients;Integrated Security=True;TrustServerCertificate=True");
        SqlCommand command = new SqlCommand();

        private void LogInbutton_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO tbClients VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')";
            command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Entry added successfully");
            displayData();

            
            
        }
        public void displayData()
        {
            con.Open();
            string query = "SELECT * FROM tbClients";
            command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM tbClients WHERE ID = 2";
            command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Entry deleted successfully");
            displayData();
        }
    }
}
