using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Over 18?")]
        public bool IsOverEighteen { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nickname")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Username change limit")]
        public int UsernameChangeLimit { get; set; } = 3;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords dont match")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public byte[]? ProfilePicture { get; set; } = new byte[16];

        public string? ReturnUrl { get; set; }
    }
}
