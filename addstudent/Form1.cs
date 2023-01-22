using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace addstudent
{
    public partial class Form1 : Form
    {
        //connection
        static string constr = "SERVER = localhost; DATABASE = school ; USERNAME = root ; PASSWORD = asmit;";
        MySqlConnection conn = new MySqlConnection(constr);

        int rollno = 0;
        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }
        public void DisplayData()
        {
            conn.Open();
            string query = "SELECT * FROM student";
            MySqlDataAdapter adr = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adr.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {

                conn.Open();
                //MessageBox.Show("Connection Sucessful");
                //conn.Close();
                int rollno = int.Parse(textBox1.Text);
                string name = textBox2.Text;
                string address = textBox3.Text;

                string query = "INSERT INTO student VALUES (" + rollno + ", '" + name + "' , '" + address + "') ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)

                    MessageBox.Show("Data Insert Successful");

                else

                    MessageBox.Show("Error in Insertion data");
                conn.Close();
                DisplayData();
                


            }
            else
            {
                MessageBox.Show("Insert data Value");
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rollno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string address = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            //MessageBox.Show(name);
            textBox1.Text = rollno.ToString();
            textBox2.Text = name;
            textBox3.Text = address;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                conn.Open();
                string name = textBox2.Text;
                string address = textBox3.Text;

                string query = "UPDATE student SET name = '" + name + "' , address = '" + address + "'  WHERE rollno = " + rollno + "";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)

                    MessageBox.Show("Update Sucessful");

                else

                    MessageBox.Show("Error in Update");
                conn.Close();
                DisplayData();





            }
            else
            {
                MessageBox.Show("Data Not Fill");
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rollno != 0)
            {
                conn.Open();
                string query = "DELETE FROM student WHERE rollno = " + rollno + "";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)

                    MessageBox.Show("Delete Successful");

                else

                    MessageBox.Show("Error in Delete");


                conn.Close();
                DisplayData();

            }
            else
            {
                MessageBox.Show("Select the row to delete");
            }
            
        }
    }
}
