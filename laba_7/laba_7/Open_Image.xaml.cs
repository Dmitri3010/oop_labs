using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace laba_7
{
    /// <summary>
    /// Логика взаимодействия для Open_Image.xaml
    /// </summary>
    public partial class Open_Image : Window
    {
        public Open_Image()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg =
            new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            FileStream fs = new FileStream(dlg.FileName, FileMode.Open,
             FileAccess.Read);

            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));

            fs.Close();
            MemoryStream memorystream = new MemoryStream();
            memorystream.Write(data, 0, (int)data.Length);

            BitmapImage imgsource = new BitmapImage();
            imgsource.BeginInit();
            imgsource.StreamSource = memorystream;
            imgsource.EndInit();
            imagebox.Source = imgsource; 
        }
    }
}
