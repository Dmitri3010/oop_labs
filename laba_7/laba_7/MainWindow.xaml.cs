using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace laba_7
{

    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable zoobase;
        string NameZoo, Type, Opisanie, Kurator, Otryad, RedBook, Areal, Date, image2;
        int Age, Id;
        bool Bd = false;
            


        private void Create_Database()
        {
            String str;
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            str = "CREATE DATABASE MyDatabase ON PRIMARY " +
                "(NAME = MyDatabase_Data, " +
                "FILENAME = 'E:\\учеба\\2 Сем\\BD\\MyDatabaseData2.mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = MyDatabase_Log, " +
                "FILENAME = 'E:\\учеба\\2 Сем\\BD\\MyDatabaseLog2.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully");

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButton.OK);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                SqlConnectionStringBuilder connect = new SqlConnectionStringBuilder();
                connectionString = ConfigurationManager.ConnectionStrings["ZooConnectionString"].ConnectionString;
                RedBook = "-";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Insert(int id, string name, string type, string opisanie, string otryad, int age, string image2, string red, string areal, string kurator, string date)
        {

            SqlConnection connect = null;
            connect = new SqlConnection(connectionString);
            connect.Open();
            try
            {
                // Оператор SQL
                string sql = string.Format("Insert Into zoobase" +
                       "([ID Животного], Название, Тип,Описание,Отряд,Возраст, Фото, [Есть ли в красной книге],[Ареал обитания], Куратор,[Дата поступления]) Values(@Id, @Name, @type, @opisanie,@otryad,@age,@image, @red,@areal, @kurator, @date)");

                using (SqlCommand cmd = new SqlCommand(sql, connect))
                {
                    // Добавить параметры										
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@opisanie", opisanie);
                    cmd.Parameters.AddWithValue("@otryad", otryad);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@image", image2);
                    cmd.Parameters.AddWithValue("@red", red);
                    cmd.Parameters.AddWithValue("@areal", areal);
                    cmd.Parameters.AddWithValue("@kurator", kurator);
                    cmd.Parameters.AddWithValue("@date", date);


                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateDB();
        }

        private void UpdateDB()
        {
            string sql = "SELECT [ID Животного], Название, Тип,Описание,Отряд,Возраст, Фото, [Есть ли в красной книге],[Ареал обитания], Куратор,[Дата поступления] FROM zoobase";
            zoobase = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);



                connection.Open();
                adapter.Fill(zoobase);
                this.ZooGrid.ItemsSource = zoobase.DefaultView;
                MessageBox.Show("Data is refresh sucsess");
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }


        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("База данных зоопарка. ver 1.1");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Insert(Id, NameZoo, Type, Opisanie, Otryad, Age, image2, RedBook, Areal, Kurator, Date);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            UpdateDB();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            string sql = "SELECT[ID Животного], Название, Тип,Описание,Отряд,Возраст, Фото, [Есть ли в красной книге],[Ареал обитания], Куратор,[Дата поступления] FROM zoobase ";
            zoobase = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);



                connection.Open();
                adapter.Fill(zoobase);
                this.ZooGrid.ItemsSource = zoobase.DefaultView;
                MessageBox.Show("Data is load succses");
                Bd = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (!Bd)
            {
                MessageBox.Show("Баззы данных не существует, создаем новую");
                Create_Database();
            }
            }

        }

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (ID.Text.Length != 0)
                {
                    Id = Convert.ToInt32(ID.Text);
                }
            }

            catch (FormatException)
            {
                MessageBox.Show("Id может быть только ключом,и не может повторяться");
            }
        }

        private void red_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ZooGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            UpdateDB();
        }

        private void kurator_TextChanged(object sender, TextChangedEventArgs e)
        {
            Kurator = kurator.Text;
        }

        private void areal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            Areal = selectedItem.Content.ToString();
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameZoo = text1.Text;
        }

        public void text2_TextChanged(object sender, TextChangedEventArgs e)
        {
            Type = text2.Text;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            SqlConnection connect = null;
            connect = new SqlConnection(connectionString);
            connect.Open();
            string delete = ZooGrid.SelectedIndex.ToString();
            MessageBox.Show(delete);
            string sql = string.Format("Delete from zoobase where [ID Животного] = '{0}'", delete);
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            UpdateDB();         
            

        }

        private void btnCreateDatabase_Click(object sender, RoutedEventArgs e)
        {
            Create_Database();
        }

        private void text3_TextChanged(object sender, TextChangedEventArgs e)
        {
           Opisanie = text3.Text;
        }

        private void foto_Click(object sender, RoutedEventArgs e)
        {


            Microsoft.Win32.OpenFileDialog dlg =
            new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            byte[] data = null;

            using (FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length));

                fs.Close();
            }

            string path = dlg.FileName;
                        image2 = path;






        }

        private void text4_TextChanged(object sender, TextChangedEventArgs e)
        {
           Otryad = text4.Text;
        }

        private void age_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            Age=Convert.ToInt32(selectedItem.Content);
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = calendar1.SelectedDate;

            Date=selectedDate.Value.Date.ToShortDateString();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }

        void Handle(CheckBox checkBox)
        {
            // Use IsChecked.
            bool flag = checkBox.IsChecked.Value;

            // Assign Window Title.
            if (flag)
            {
                RedBook = "+";
            }
            else RedBook = "-";
        }
    
      


        private void delete_Click(object sender, RoutedEventArgs e)
        {   
             SqlConnection connect = null;
             connect = new SqlConnection(connectionString);
            connect.Open();
            string sql = string.Format("Delete from zoobase");
            using (SqlCommand cmd = new SqlCommand(sql, connect))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            UpdateDB();
        }
    }
}

