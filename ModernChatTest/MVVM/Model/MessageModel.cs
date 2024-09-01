using System;

namespace ModernChatTest.MVVM.Model
{
    public class MessageModel
    {
        public string Username { get; set; }
        public string UsernameColor { get; set; }
        public string ImageSource { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public bool IsNativeOrigin { get; set; }
        public bool? FirstMessage { get; set; }

        public MessageModel(string username, string usernameColor, string imageSource, string message, DateTime time, bool isNativeOrigin, bool? firstMessage = null)
        {
            Username = username;
            UsernameColor = usernameColor;
            ImageSource = imageSource;
            Message = message;
            Time = time;
            IsNativeOrigin = isNativeOrigin;
            FirstMessage = firstMessage;
        }
    }
}
