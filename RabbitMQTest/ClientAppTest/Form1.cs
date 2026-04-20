using MySql.Data.MySqlClient;
using System.Data;

namespace ClientAppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("server=192.168.92.129;user=client;password=Secret1234**;database=ClientDB"))
            {
                connection.Open();
                string query = "SELECT * FROM TestTable";
                MySqlCommand command = new MySqlCommand(query, connection);

                DataSet ds = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(ds);


                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
