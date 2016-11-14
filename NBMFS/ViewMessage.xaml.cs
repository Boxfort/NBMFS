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
    /// Interaction logic for ViewMessage.xaml
    /// </summary>
    public partial class ViewMessage : Window
    {
        public ViewMessage(Message message)
        {
            InitializeComponent();
            if(message.GetType() == typeof(Email))
            {
                Email email = (Email)message;
                txt_subject.Text = email.Subject;
            }
                
            txt_id.Text = message.MessageID;
            txt_message.Text = message.ProcessedMessage;
            txt_sender.Text = message.Sender;

            txt_id.IsReadOnly = true;
            txt_message.IsReadOnly = true;
            txt_sender.IsReadOnly = true;
            txt_subject.IsReadOnly = true;
        }
    }
}
