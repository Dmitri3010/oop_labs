using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value =textBox1.Text;
            listView1.Clear();
            StreamReader str = new StreamReader(@"C:\Users\Dima\Documents\Zoopark\11231221232123112321313123123131233.txt", Encoding.UTF8);
            while (!str.EndOfStream)
            {
                string st = str.ReadLine();
                if (st.Contains(value))
                {
                    listView1.Items.Add(st);
                    
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
