using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Example_20_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Untitle";
            openFileDialog1.Filter = "All Text Files(*.txt)|*.txt";
            saveFileDialog1.Filter = "All Text Files(*.txt)|*.txt";
            this.Tag = "";
        }
        //-----------------------------------------------------
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            this.Tag = "";
            this.Text = "Untitle";
        }
        //-----------------------------------------------------
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
                this.Text = openFileDialog1.SafeFileName;
                this.Tag = openFileDialog1.FileName;
            }
        }
        //-----------------------------------------------------
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Tag.ToString() == "")//untitle file
            {
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    //savefiledialog dont have safefilename property
                    this.Text = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                    this.Tag = saveFileDialog1.FileName;
                    System.IO.File.AppendAllText(this.Tag.ToString(),richTextBox1.Text);
                }
            }
            else
                System.IO.File.AppendAllText(this.Tag.ToString(),richTextBox1.Text);
        }
    }
}
