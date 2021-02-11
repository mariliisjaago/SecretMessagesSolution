namespace SecretMessages_Library.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public bool IsRead { get; set; }

    }
}
