using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseisDedomenwn
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moviesDataSet.actors' table. You can move, or remove it, as needed.
           // this.actorsTableAdapter.Fill(this.moviesDataSet.actors);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            String email = emailTextBox.Text;
            String password = passwordTextBox.Text;
            NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; User Id = postgres; " + "Password = theodwrasofia3; Database = Movies; ");
            try
            {

                // Connect to a PostgreSQL database
                
                conn.Open();
                // Define a query
                NpgsqlCommand command = new NpgsqlCommand("SELECT email_id, password FROM customer where email_id= " + $"'{email}'" + " and password= " + $"'{password}'", conn);

                NpgsqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                  
                    this.Hide();
                    MovieListForm movieListForm = new MovieListForm();
                    
                    movieListForm.Show();
                }
                else
                    MessageBox.Show("Email or Password Not Found");


            }
            catch( Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
