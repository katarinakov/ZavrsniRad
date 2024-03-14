using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DijkstraApp
{
    public partial class Form2 : Form
    {
        public string tekst;
        public Form2(string tekst)
        {
            InitializeComponent();
            this.tekst = tekst;
            richTextBox1.Text = tekst;
            richTextBox1.ReadOnly = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
