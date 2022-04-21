using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Models.Account
{
    public class ApplicationUser : IdentityUser
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
        [Display(Name = "Username change limit")]
        public int UsernameChangeLimit { get; set; } = 3;

        public byte[]? ProfilePicture { get; set; }
    }
}
