using System.ComponentModel.DataAnnotations;

namespace Uroboro.Common.Models
{
    public class JwtAuthRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
