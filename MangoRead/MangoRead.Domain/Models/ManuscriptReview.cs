using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DateTime UploadDate { get; set; }

        [Required]
        public DateTime UpdateDate { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Possible range: from 1 to 5.")]
        public int Rating { get; set; }

        public DateTime? ApprovalDate { get; set; } = null;

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.InProgress;

        public int ManuscriptId { get; set; }

        [ForeignKey("ManuscriptId")]
        public Manuscript Manuscript { get; set; } // navigational property
    }
}
