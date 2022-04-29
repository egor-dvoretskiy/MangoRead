using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Models
{
    public class ManuscriptReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public string AuthorUserName { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Possible range: from 1 to 5.")]
        public int Rating { get; set; }

        [Required]
        public Guid CouplingGuid { get; set; }
    }
}
