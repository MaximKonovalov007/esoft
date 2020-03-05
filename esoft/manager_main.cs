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
    public partial class manager_main : Form
    {
        private int manager_id = Form1.user_id;
        public static String connectionString = "Data Source = 303-19\\MSSQLSERVER2; Initial Catalog = esoft; INtegrated Security = True";
        public manager_main()
        {
            InitializeComponent();
        }
       

        private void manager_main_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                SqlCommand com = new SqlCommand($"SELECT  [execuret_id],[executer_fio],[executer_login],[executer_grade],[junior_salary],[middle_salary],[senior_salary],[koef_analyse_and_projecting],[koef_install_hardware],[koef_tech_support],[koef_time],[koef_difficult],[koef_convert] FROM [esoft].[dbo].[executers] WHERE manager_id = '{manager_id}'", connection);
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                          dataGridView1.Rows.Add(reader[0], reader[1],reader[2],reader[3],reader[4], reader[5], reader[6], reader[7], reader[8], reader[9], reader[10], reader[11], reader[12]);
                    }
                }
            }
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@connectionString))
            {
                connection.Open();
                SqlCommand com = new SqlCommand($"UPDATE [dbo].[executers] SET [junior_salary] = '{dataGridView1.CurrentRow.Cells[4].Value}', [middle_salary] = '{dataGridView1.CurrentRow.Cells[5].Value}',[senior_salary] = '{dataGridView1.CurrentRow.Cells[6].Value}', [koef_analyse_and_projecting] = '{dataGridView1.CurrentRow.Cells[7].Value}', [koef_install_hardware] =  '{dataGridView1.CurrentRow.Cells[8].Value}',[koef_tech_support] = '{dataGridView1.CurrentRow.Cells[9].Value}',[koef_time] = '{dataGridView1.CurrentRow.Cells[10].Value}',[koef_difficult] =  '{dataGridView1.CurrentRow.Cells[11].Value}',[koef_convert] = '{dataGridView1.CurrentRow.Cells[12].Value}' WHERE [execuret_id] = '{dataGridView1.CurrentRow.Cells[0].Value}'", connection);
                using (SqlDataReader reader = com.ExecuteReader())
                {
                    reader.Read();
                    MessageBox.Show("Изменеиня внесены");
                }
            }
        }

        private void task_list_button_Click(object sender, EventArgs e)
        {
            tasks_list tl = new tasks_list();
            tl.Show();
        }
    }
}
