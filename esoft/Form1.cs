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

namespace esoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static Boolean auth = false;

        private void button1_Click(object sender, EventArgs e)
        {
            String login = login_field.Text;
            String password = password_field.Text;
            int manager_id;
            int executer_id;

            String connectionString = "Data Source = 303-19\\MSSQLSERVER2; Initial Catalog = esoft; INtegrated Security = True";

            using(SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                SqlCommand com = new SqlCommand($"SELECT [execuret_id] FROM [esoft].[dbo].[executers] WHERE executer_login = '{login}' AND executer_password = '{password}'", connection);
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        auth = true;
                        executer_id = (int)reader[0];

                    }
                }
                com = new SqlCommand($"SELECT [manager_id] FROM [esoft].[dbo].[managers] WHERE [manager_login] = '{login}' AND [manager_password] = '{password}'", connection);
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        auth = true;
                        manager_id = (int)reader[0];

                    }
                }
            }

            if (!auth)
            {
                MessageBox.Show("Невервный логин или пароль!");
            }

        }
    }
}
