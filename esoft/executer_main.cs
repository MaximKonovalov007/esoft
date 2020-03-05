using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esoft
{
    public partial class executer_main : Form
    {
        public static String connectionString = "Data Source = 303-19\\MSSQLSERVER2; Initial Catalog = esoft; INtegrated Security = True";
        public executer_main()
        {
            InitializeComponent();

        }

        private void executer_main_Load(object sender, EventArgs e)
        {

        }

        private void task_list_button_Click(object sender, EventArgs e)
        {
            tasks_list tl = new tasks_list();
            tl.Show();
        }
    }
}
