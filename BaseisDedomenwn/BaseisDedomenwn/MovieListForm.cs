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
    public partial class MovieListForm : Form
    {
        public MovieListForm()
        {
            InitializeComponent();
        }
        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void MovieListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moviesDataSet.movie' table. You can move, or remove it, as needed.
            //this.movieTableAdapter.Fill(this.moviesDataSet.movie);

        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; User Id = postgres; " + "Password =theodwrasofia3; Database = Movies; ");
            try
            {

                // Connect to a PostgreSQL database

                conn.Open();
                // Define a query
                NpgsqlCommand command = new NpgsqlCommand("SELECT m_name, release_date, FROM movie", conn);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                   
                    checkedListBox1.Items.Add(dr.GetString(0).ToString() + " " + dr.GetDate(1).ToString());

                   
                };
                dr.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                conn.Close();
            }
        }

   

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = checkedListBox1.SelectedIndex + 1;
            MovieDetailsForm mdf = new MovieDetailsForm(index);
            this.Hide();
            mdf.Show();
        }
    }
}
