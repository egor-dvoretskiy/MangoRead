using MangoRead.Domain.Models;
using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels
{
    public class ManuscriptViewModel
    {
        [Key]
        public int Id { get; set; }

        public Guid Index { get; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; }

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

        public List<GenreHolder> Genres { get; set; } = new List<GenreHolder>();

        public ManuscriptContent? Content { get; set; }
    }
}
