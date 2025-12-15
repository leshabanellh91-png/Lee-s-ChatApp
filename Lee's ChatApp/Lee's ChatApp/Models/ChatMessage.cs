namespace LeratosChatServer1.Models
{
    public class ChatMessage
    {
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime SentAt { get; set; }
    }
}
