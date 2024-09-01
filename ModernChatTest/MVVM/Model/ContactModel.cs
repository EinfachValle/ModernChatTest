using System.Collections.ObjectModel;
using System.Linq;

namespace ModernChatTest.MVVM.Model
{
    public class ContactModel
    {
        public string Username { get; set; }
        public string ImageSource { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; }
        public string LastMessage => Messages.Any() ? Messages.Last().Message : "No messages yet";

        public void AddMessage(MessageModel message)
        {
            if (Messages.Count == 0 || Messages.Last().Username != message.Username)
            {
                message.FirstMessage = true;
            }
            Messages.Add(message);
        }
    }
}
