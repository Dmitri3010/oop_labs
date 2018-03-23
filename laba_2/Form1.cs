using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;


namespace laba_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
           открытьПутьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
           сохранитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            выходToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
           textBox1.Validating += textBox1_Validating;
            infoLabel = new ToolStripLabel();
        
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();


        }
        string name, type, opisanie, otryad, kurator, data, klass, red_book, areal, poisk, lines;
        int age;
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        Timer timer;


        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Не указано название!");
            }

            else
            {
                errorProvider1.Clear();
            }
        }

       
      

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            data = "";
            data = string.Format(dateTimePicker1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if ((textBox1.Text.Length == 0) || (textBox2.Text.Length == 0) || (textBox3.Text.Length == 0) || (textBox4.Text.Length == 0) || (textBox5.Text.Length == 0) || (textBox6.Text.Length == 0))
            
            {
                MessageBox.Show("Не все данные введены");
                
         
            }
            else
                dataGridView1.Rows.Add(name, type, opisanie, otryad, age, klass, red_book, areal, kurator, data);
        }
            
        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            opisanie = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            otryad = textBox4.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try { age = Convert.ToInt32(numericUpDown1.Value); }
            catch (Exception)
            {
                MessageBox.Show("Возраст может быть только число!");
            }
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            kurator = textBox6.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            poisk = textBox7.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                int del = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(del);
            }
            catch (Exception )
            {
                MessageBox.Show("упс, строка и так пуста");
            }

        }

        private void SaveDocToFileXML(String TR4FileName)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(TR4FileName, System.Text.Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                //Запись данных о версии
                writer.WriteStartElement("DocInfo");
                writer.WriteAttributeString("DocType", "TepRast4Doc");
                writer.WriteAttributeString("Version", "tr4d_r1");
                //Запись данных
                writer.WriteStartElement("Table");
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    writer.WriteStartElement("Row");
                    writer.WriteAttributeString("Наименование", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    writer.WriteAttributeString("Тип", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    writer.WriteAttributeString("Описание", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    writer.WriteAttributeString("Отряд", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    writer.WriteAttributeString("Возраст", dataGridView1.Rows[i].Cells[4].Value.ToString());
                    writer.WriteAttributeString("Класс", dataGridView1.Rows[i].Cells[5].Value.ToString());
                    writer.WriteAttributeString("Занесен_ли_в_красную книгу", dataGridView1.Rows[i].Cells[6].Value.ToString());
                    writer.WriteAttributeString("Ареал_обитания", dataGridView1.Rows[i].Cells[7].Value.ToString());
                    writer.WriteAttributeString("Куратор", dataGridView1.Rows[i].Cells[8].Value.ToString());
                    writer.WriteAttributeString("Дата_поступления", dataGridView1.Rows[i].Cells[9].Value.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                MessageBox.Show("Данные записаны в XML");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("author: Volski Dmitri\n version 2.0");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\Users\Dima\Documents\Zoopark";
            Stream myStream;

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
           
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWritet = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount-1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                myWritet.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + " ");
                            }
                            myWritet.WriteLine();
                        }

                        MessageBox.Show("Данные сохранены");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWritet.Close();
                    }

                    myStream.Close();
                }
            }

        }

        private void открытьПутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"c:\Users\Dima\Documents\Zoopark";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
           
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                           
                            StreamReader myread = new StreamReader(myStream);
                            string[] str;
                            int num = 0;

                            try
                            {
                                string[] str1 = myread.ReadToEnd().Split('\n');
                                num = str1.Count();
                                dataGridView1.RowCount = num;
                                for(int i= 0; i<num-1; i++)
                                {
                                    str = str1[i].Split(' ');
                                    for (int j = 0; j< dataGridView1.ColumnCount; j++)
                                    {
                                        try {
                                            dataGridView1.Rows[i].Cells[j].Value = str[j];
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Ошибка: " + ex.Message);
                                        }

                                        finally
                                        {
                                            myread.Close();
                                        }
                                    }
                                }

                        
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("error load data " + ex.Message);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void поКлассуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
           
        }

        private void message(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void очиститьТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            
            
        }

        private void удалитьСтрокуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int del = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(del);
            }
            catch (Exception ex)
            {
                MessageBox.Show("упс, строка и так пуста");
            }
        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void поГодуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

      

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            SaveDocToFileXML(@"C:\Users\Dima\Documents\Zoopark\xml.xml");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            poisk = textBox7.Text;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(poisk))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            red_book = " - ";
            CheckBox checkBox = (CheckBox)sender; 
            if (checkBox.Checked)
            {
                red_book = "+";
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            areal = selectedState;
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            klass = textBox5.Text;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            type = textBox2.Text;
        }

        private void во(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zooparkDataSet.Zoo". При необходимости она может быть перемещена или удалена.
           
         

        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
