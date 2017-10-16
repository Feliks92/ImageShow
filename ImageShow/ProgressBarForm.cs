using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageShow;

namespace ImageShow
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm(int max)
        {
            InitializeComponent();
            ProgressB.Maximum = max; 
        }

        // METODA AKTUALIZUJĄCA PASEK POSTĘPU
        public void increment()
        {
            ProgressB.Increment(1);
        }

        // METODA AKTUALIZUJĄCA TEKST POSTĘPU
        public void progress(int max, int actual)
        {
            PostepLabel.Text = "Progress " + actual + "/" + max + " images";
        }

        
    }
}
