using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ImageShow
{
    public partial class BrowseForm : Form
    {
        Helper helper = new Helper();

        public BrowseForm()
        {
            InitializeComponent();
        }
       
        // PRZYCISK PODMIANA
        private void button_replace_Click(object sender, EventArgs e)
        {
            Dispose();

            using (var context = new ImageDBEntities())
            {
                int delete = context.Database.ExecuteSqlCommand("DELETE FROM imagetable");
            }

            helper.BrowseAndAdd();
            
        }

        // PRZYCISK DODANIE
        private void button_add_Click(object sender, EventArgs e)
        {
            Dispose();

            helper.BrowseAndAdd();
        }
    }
}
