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
            btn_view.IsEnabled = false;
            btn_save.IsEnabled = false;
            btn_clear.IsEnabled = false;
        }

        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            AddMessage addMessage = new AddMessage();

            if (addMessage.ShowDialog() == true)
            {
                insertMessage(addMessage.getMessage());
                btn_save.IsEnabled = true;
                btn_clear.IsEnabled = true;
            }

            addMessage.Close();
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to clear all messages?", "Alert", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                clearLists();
            }
        }

        private void clearLists()
        {
            list_messages.Items.Clear();
            list_hastags.Items.Clear();
            list_mentions.Items.Clear();
            list_incidents.Items.Clear();
            list_quarantine.Items.Clear();
            btn_save.IsEnabled = false;
            btn_clear.IsEnabled = false;
            btn_view.IsEnabled = false;
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
                    clearLists();

                    while (!sr.EndOfStream)
                    {
                        string messageString = sr.ReadLine();

                        try
                        {
                            Message message = JSONHelper.JsonDeserialize<Message>(messageString);
                            insertMessage(message);
                        }
                        catch (Exception ex)
                        {
                            messageError = true;
                        }
                    }

                    sr.Close();
                    btn_save.IsEnabled = true;
                    btn_clear.IsEnabled = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Cannot read file.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if(messageError)
                    MessageBox.Show("There was a problem reading some messages.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void insertMessage(Message message)
        {
            if (message.GetType() == typeof(Tweet))
            {
                addHashtagsAndMentions((Tweet)message);
                list_messages.Items.Add(message);
            }
            else if (message.GetType() == typeof(SIR))
            {
                list_incidents.Items.Add((SIR)message);
            }
            else if (message.GetType() == typeof(Email))
            {
                list_messages.Items.Add(message);
                addQuarantine((Email)message);
            }
            else
            {
                list_messages.Items.Add(message);
            }
        }

        private void addQuarantine(Email email)
        {
            foreach(string url in email.URLs)
            {
                Tuple<string, string> urlTuple = new Tuple<string, string>(email.MessageID, url);
                list_quarantine.Items.Add(urlTuple);
            }
        }

        private void addHashtagsAndMentions(Tweet tweet)
        {
            Dictionary<string, int> hashtags = new Dictionary<string, int>();
            Dictionary<string, int> mentions = new Dictionary<string, int>();

            list_hastags.Items.Clear();
            list_mentions.Items.Clear();
 
            foreach (KeyValuePair<string, int> kv in tweet.Hashtags)
            {
                foreach (KeyValuePair<string, int> item in list_hastags.Items)
                {
                    var selectedItem = (dynamic)item;
                    hashtags.Add(selectedItem.Key, Convert.ToInt32(selectedItem.Value));
                }

                //If duplicate then add to count instead of adding new entry
                if (hashtags.ContainsKey(kv.Key))
                {
                    hashtags[kv.Key] += kv.Value;
                }
                else
                {
                    hashtags.Add(kv.Key, kv.Value);
                }
            }

            foreach (KeyValuePair<string, int> kv in tweet.Mentions)
            {
                foreach (KeyValuePair<string, int> item in list_mentions.Items)
                {
                    var selectedItem = (dynamic)item;
                    mentions.Add(selectedItem.Key, Convert.ToInt32(selectedItem.Value));
                }

                if (mentions.ContainsKey(kv.Key))
                {
                    mentions[kv.Key] += kv.Value;
                }
                else
                {
                    mentions.Add(kv.Key, kv.Value);
                }
            }

            foreach (KeyValuePair<string, int> kv in hashtags)
            {
                list_hastags.Items.Add(kv);
            }
            foreach (KeyValuePair<string, int> kv in mentions)
            {
                list_mentions.Items.Add(kv);
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

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            if (list_messages.SelectedItem != null)
            {
                ViewMessage window = new ViewMessage((Message)list_messages.SelectedItem);
                window.Show();
            }
        }

        private void list_messages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_view.IsEnabled = true;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
