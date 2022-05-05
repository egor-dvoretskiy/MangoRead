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
    public class Manuscript
    {
        [Key]
        public int Id { get; set; }

        public Guid Index { get; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public byte[] TitleImage { get; set; }

        public string Author { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ApprovingDate { get; set; } = null;

        [Required]
        public string Publisher { get; set; } = string.Empty;

        public string Translator { get; set; } = string.Empty;

        public string OriginCountry { get; set; } = string.Empty;

        [Required]
        public ManuscriptType Type { get; set; } = ManuscriptType.Other;

        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public bool IsRequireLegalAge { get; set; } = false;

        public ApprovalStatus IsApproved { get; set; } = ApprovalStatus.InProgress;

        public List<GenreHolder> Genres { get; set; } = new List<GenreHolder>();

        public ManuscriptContent? Content { get; set; }
    }
}
