using ModernChatTest.Core;
using ModernChatTest.MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ModernChatTest.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<ContactModel> Contacts { get; set; }
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set { _selectedContact = value; OnPropertyChanged(); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(_ =>
            {
                Console.WriteLine("SendCommand executed!");
                if (string.IsNullOrWhiteSpace(Message))
                {
                    Console.WriteLine("Message is empty or null.");
                }
                if (SelectedContact == null)
                {
                    Console.WriteLine("SelectedContact is null.");
                }

                if (!string.IsNullOrWhiteSpace(Message) && SelectedContact != null)
                {
                    Console.WriteLine($"Adding message: {Message}");
                    var newMessage = new MessageModel(
                        username: "EinfachValle", // Replace with actual current user name
                        usernameColor: "#ffa500",
                        imageSource: "https://i.imgur.com/ZrKq1OO.png", // Replace with actual image source
                        message: Message,
                        time: DateTime.Now,
                        isNativeOrigin: true);

                    SelectedContact.AddMessage(newMessage);

                    Message = "";
                    Console.WriteLine("Message sent and input cleared.");
                }
            });

            var sampleMessages = new ObservableCollection<MessageModel>
            {
                new MessageModel("EmmaEinhorn", "#FFC0CB", "https://i.imgur.com/yMWvLXd.png", "Test", DateTime.Now, false, true),
                new MessageModel("Sakuya", "#403aff", "https://i.imgur.com/5ZpVuogl.png", "Test", DateTime.Now, true),
                new MessageModel("Sakuya", "#403aff", "https://i.imgur.com/5ZpVuogl.png", "Last", DateTime.Now, true)
            };

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"EmmaEinhorn {i}",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Messages = new ObservableCollection<MessageModel>(sampleMessages)
                });
            }

            SelectedContact = Contacts.FirstOrDefault(); // Set a default selected contact
        }
    }
}
