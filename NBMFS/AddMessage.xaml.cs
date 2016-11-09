using System;
using System.Collections.Generic;
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

namespace NBMFS
{
    /// <summary>
    /// Interaction logic for AddMessage.xaml
    /// </summary>
    public partial class AddMessage : Window
    {
        private Message _message;

        public AddMessage()
        {
            InitializeComponent();
            txt_subject.IsEnabled = false;
        }

        public Message getMessage()
        {
            return _message;
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            txt_id.Clear();
            txt_sender.Clear();
            txt_subject.Clear();
            txt_message.Clear();
        }

        private void txt_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txt_id.Text.ToLower().Contains("e"))
            {
                txt_subject.IsEnabled = true;
            }
            else
            {
                txt_subject.IsEnabled = false;
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageFactory mf = new MessageFactory();

                _message = mf.CreateMessage(txt_id.Text, txt_sender.Text, txt_message.Text.Trim(), txt_subject.Text);

                DialogResult = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
