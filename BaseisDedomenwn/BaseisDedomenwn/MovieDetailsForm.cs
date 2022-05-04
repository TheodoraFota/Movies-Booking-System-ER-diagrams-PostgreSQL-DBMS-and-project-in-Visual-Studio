using Npgsql;
using System;
using System.Windows.Forms;

namespace BaseisDedomenwn
{
    public partial class MovieDetailsForm : Form
    {
        int movie_id;
        int[] show_id;
        public MovieDetailsForm()
        {
            InitializeComponent();
           
        }
        public MovieDetailsForm(int movie_id)
        {
            InitializeComponent();
            this.movie_id = movie_id;

       
        }

        


        private void MovieDetailsForm_Load(object sender, EventArgs e)
        {
           
         

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void showDetailsButton_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server = 127.0.0.1; User Id = postgres; " + "Password =theodwrasofia3; Database = Movies; ");
         
            try
            {

                // Connect to a PostgreSQL database

                conn.Open();
                // Define a query
                NpgsqlCommand command = new NpgsqlCommand("SELECT m_name FROM movie where m_id = " + $"{movie_id}", conn);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read()) { 
                label1.Text = dr.GetString(0).ToString();


                }
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


            try
            {

                // Connect to a PostgreSQL database

                conn.Open();
                // Define a query
                NpgsqlCommand command = new NpgsqlCommand("SELECT actor FROM actors where m_id = " + $"{movie_id}", conn);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    richTextBox1.AppendText("Actor : ");
                    richTextBox1.AppendText(dr.GetString(0).ToString()+ "\n \n");


                }
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


            try
            {

                // Connect to a PostgreSQL database

                conn.Open();
                // Define a query
                NpgsqlCommand command = new NpgsqlCommand("SELECT director FROM director where m_id = " + $"{movie_id}", conn);

                NpgsqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    richTextBox1.AppendText("Director : ");
                    richTextBox1.AppendText(dr.GetString(0).ToString() + "\n \n");


                }
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

            try
            {

                // Connect to a PostgreSQL database

                conn.Open();
                // Define a query
                NpgsqlCommand command = new NpgsqlCommand($"SELECT  show_date, start_time, end_time, language FROM show, tickets where m_id = '{movie_id}' and tickets.show_id = show.show_id", conn) ;

                NpgsqlDataReader dr = command.ExecuteReader();
                
                while (dr.Read())
                {
                   
                    checkedListBox1.Items.Add("Show Date : " + dr.GetDate(0).ToString()  + "\t Start Time : " + dr.GetTimeSpan(1).ToString() + "\t End time : " + dr.GetTimeSpan(2).ToString() + "\t Language : " + dr.GetString(3).ToString());
                    
                }
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Booking has been confirmed. Check your email for more details");
        }
    }
}
