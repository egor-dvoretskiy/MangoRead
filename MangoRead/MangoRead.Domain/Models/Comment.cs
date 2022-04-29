using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
                
        public int PageId { get; set; }

        [ForeignKey("PageId")]
        public Page Page { get; set; }
    }
}
