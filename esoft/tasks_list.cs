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
    public partial class tasks_list : Form
    {
        public static String connectionString = "Data Source = 303-19\\MSSQLSERVER2; Initial Catalog = esoft; Integrated Security = True";
        public tasks_list()
        {
            InitializeComponent();
        }

        private void tasks_list_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@connectionString))
            {
                MessageBox.Show(Form1.is_manager.ToString());
                connection.Open();
                if(Form1.is_manager == false)
                {
                    SqlCommand com = new SqlCommand($"SELECT [task_id],[task_header],[status],(SELECT [executer_fio] FROM executers WHERE [executer_login] = tasks.executer_login) as [FIOE],(SELECT [manager_fio] FROM executers WHERE [executer_login] = tasks.executer_login) as [FIOM]FROM [esoft].[dbo].[tasks]", connection);
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                        }
                    }
                }
                else
                {
                    SqlCommand com = new SqlCommand($"SELECT [task_id],[task_header],[status],(SELECT [executer_fio] FROM executers WHERE [executer_login] = tasks.executer_login) as [FIOE],(SELECT [manager_fio] FROM executers WHERE [executer_login] = tasks.executer_login) as [FIOM]FROM [esoft].[dbo].[tasks] WHERE [executer_id] = '{Form1.user_id}'", connection);
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                        }
                    }
                }
            }
        }
    }
}
