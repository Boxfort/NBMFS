using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace NBMFS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            list_messages.Items.Add(new Tweet("S123456789", "@JackAndHerSon", "This is a tweet"));
        }

        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            AddMessage addMessage = new AddMessage();

            if (addMessage.ShowDialog() == true)
            {
                list_messages.Items.Add(addMessage.getMessage());
            }

            addMessage.Close();
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to clear all messages?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                list_messages.Items.Clear();
            }
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool messageError = false;
            dialog.Filter = "JSON Files|*.json";

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    StreamReader sr = new StreamReader(dialog.FileName);
                    list_messages.Items.Clear();

                    while (!sr.EndOfStream)
                    {
                        string messageString = sr.ReadLine();

                        try
                        {
                            Message message = JSONHelper.JsonDeserialize<Message>(messageString);
                            list_messages.Items.Add(message);
                        }
                        catch(Exception ex)
                        {
                            messageError = true;
                        }
                    }

                    sr.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Cannot read file.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if(messageError)
                    MessageBox.Show("There was a problem reading some messages.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JSON Files|*.json";
            dialog.AddExtension = true;
            dialog.DefaultExt = ".json";

            if (dialog.ShowDialog() == true)
            {
                if (!File.Exists(dialog.FileName))
                {
                    var newFile = File.Create(dialog.FileName);
                    newFile.Close();
                }

                StreamWriter sw = new StreamWriter(dialog.FileName);
                foreach (Message m in list_messages.Items)
                {
                    sw.WriteLine(JSONHelper.JsonSerializer(m));
                }

                sw.Flush();
                sw.Close();
            } 
        }
    }
}
