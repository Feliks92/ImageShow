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
using System.Xml;
using System.IO;

namespace ImageShow
{

    public partial class MenuForm : Form
    {
       private string configlocation = @"C:\Users\Felek\Documents\Visual Studio 2017\Projects\ImageShow\ImageShow\ImageShow.config";
       private XmlDocument configxml = new XmlDocument();
       
        
        public MenuForm()
        {
            configxml.Load(configlocation.ToString());
            Helper.MaxImageWidth = int.Parse(configxml.DocumentElement.SelectSingleNode("/configuration/resolution/width").InnerText);
            Helper.MaxImageHeight = int.Parse(configxml.DocumentElement.SelectSingleNode("/configuration/resolution/height").InnerText);
            Helper.SlideTime = int.Parse(configxml.DocumentElement.SelectSingleNode("/configuration/showtime").InnerText);
            
            InitializeComponent();
        }


        // PRZYCISK SHOW
        private void button_show_click(object sender, EventArgs e)
        {
            Helper helper = new Helper();
            
            using (var context = new ImageDBEntities())
            {
                var IDs = context.Database.SqlQuery<int>(" SELECT ID FROM Imagetable").ToList();
                helper.ShowImages(IDs, Helper.SlideTime, Helper.MaxImageWidth, Helper.MaxImageHeight);
            }
        }

        
        // PRZYCISK BROWSE
        private void button_browse_click(object sender, EventArgs e)
        {
            BrowseForm browse = new BrowseForm();
            browse.Show();
        }

        
        // PRZYCISK DELETE
        private void button_delete_Click(object sender, EventArgs e)
        {
            using(var context = new ImageDBEntities())
            {
                var delete = context.Database.ExecuteSqlCommand("DELETE FROM Imagetable");
                MessageBox.Show("DataBase cleared");
            }
        }
    }

}
