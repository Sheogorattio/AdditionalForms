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

namespace AdditionalForms
{
    public partial class Form1 : Form
    {
        string pathToFolder = "C:\\";
        string mask = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                mask = this.textBox1.Text;
                if(mask.Length <1) { throw new Exception("Wrong file search mask."); }
                DialogResult res = folderBrowserDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    pathToFolder = folderBrowserDialog1.SelectedPath;
                }
                string[] files = Directory.GetFiles(pathToFolder, mask);
                foreach (string file in files) { listBox1.Items.Add(file); }
                mask = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
