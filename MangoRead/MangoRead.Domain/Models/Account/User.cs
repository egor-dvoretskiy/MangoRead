using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Models.Account
{
    public class User : IdentityUser
    {
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
