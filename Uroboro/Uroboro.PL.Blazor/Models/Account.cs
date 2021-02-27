using System;
using System.ComponentModel.DataAnnotations;

namespace Uroboro.PL.Blazor.Models
{
    public class Account
    {
        [Required]
        [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }
        [Required]
        public string BirthPlace { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Code invalid (1-100).")]
        public int Code { get; set; }
        [Required, EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "This form disallows unregistered users.")]
        public bool IsRegistered { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Username=[{Username}]\n" +
                $"Password=[{Password}]\n" +
                $"Name=[{Name}]\n" +
                $"Surname=[{Surname}]\n" +
                $"BirthDate=[{BirthDate}]\n" +
                $"BirthPlace=[{BirthPlace}]\n" +
                $"Category=[{Category}]\n" +
                $"Code=[{Code}]\n" +
                $"Gender=[{Gender}]\n" +
                $"IsRegistered=[{IsRegistered}]\n" +
                $"Message=[{Message}]";
        }
    }

    public enum Gender { Male, Female }
}
