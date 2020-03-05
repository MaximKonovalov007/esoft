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
        public static int user_id;
        public static Boolean is_manager = false;
        public static Boolean auth = false;
        public Form1()
        {
            InitializeComponent();
        }
        public static String connectionString = "Data Source = 303-19\\MSSQLSERVER2; Initial Catalog = esoft; INtegrated Security = True";

        private void button1_Click(object sender, EventArgs e)
        {
            String login = login_field.Text;
            String password = password_field.Text;
            

            String connectionString = "Data Source = 303-19\\MSSQLSERVER2; Initial Catalog = esoft; INtegrated Security = True";

            using(SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                SqlCommand com = new SqlCommand($"SELECT [manager_id] FROM [esoft].[dbo].[managers] WHERE manager_login = '{login}' AND manager_password = '{password}'", connection);
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if(reader.Read())
                    {
                         user_id = (int)reader[0];
                         auth = true;
                         is_manager = true;
                         manager_main mm = new manager_main();
                         mm.Show();
                         this.Hide();
                    }
                }

                com = new SqlCommand($"SELECT [execuret_id] FROM [esoft].[dbo].[executers] WHERE [executer_login] = '{login}' AND [executer_password] = '{password}'", connection);
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user_id = (int)reader[0];
                        auth = true;
                        executer_main em = new executer_main();
                        em.Show();
                        this.Hide();
                    }
                }
                if(auth == false)
                    {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
