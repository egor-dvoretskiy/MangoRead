using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Entities
{
    public class Manuscript
    {
        [ForeignKey("Content")]
        public int Id { get; set; }

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
        public ManuscriptType Type { get; set; } = ManuscriptType.Etc;

        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public bool IsRequireLegalAge { get; set; } = false;

        public Guid Key { get; set; } = Guid.NewGuid();

        public IList<Genre> Genres { get; set; } = new List<Genre>();

        public virtual ManuscriptContent? Content { get; set; }
    }
}
