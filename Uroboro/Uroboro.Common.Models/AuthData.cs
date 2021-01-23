using System.ComponentModel.DataAnnotations;

namespace Uroboro.Common.Models
{
    public class AuthData
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
