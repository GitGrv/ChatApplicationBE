using System.ComponentModel.DataAnnotations;

namespace UserServices.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        [Required, MinLength(3)]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }=string.Empty;

    }
}
