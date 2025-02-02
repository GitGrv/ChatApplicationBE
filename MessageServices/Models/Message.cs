using System.ComponentModel.DataAnnotations;

namespace MessageServices.Models
{
    public class Message
    {
        [Key]
        public Guid MessageID { get; set; }

        [Required]
        public Guid SenderID { get; set; } // User ID of the sender

        [Required]
        public Guid ReceiverID { get; set; } // User ID of the receiver

        [Required]
        [MaxLength(1000)] // Limit message length
        public string MessageContent { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; } = DateTime.UtcNow; // Auto-set time
    }
}
