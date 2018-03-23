using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
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
    }
}
