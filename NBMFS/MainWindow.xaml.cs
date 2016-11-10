using Microsoft.Win32;
using Newtonsoft.Json;
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

            if (dialog.ShowDialog() == true)
            {
                System.IO.StreamReader sr = new
                System.IO.StreamReader(dialog.FileName);
                while (!sr.EndOfStream)
                {
                    string messageString = sr.ReadLine();

                    Message message = JsonConvert.DeserializeObject(messageString, typeof(Message),
                                                                        new JsonSerializerSettings
                                                                        {
                                                                            TypeNameHandling = TypeNameHandling.Objects
                                                                        });
                    list_messages.Items.Add(message);
                }

                sr.Close();
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
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
