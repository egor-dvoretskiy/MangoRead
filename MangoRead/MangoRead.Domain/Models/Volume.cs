using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Models
{
    public class Volume
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Chapter> Chapters { get; set; } = new List<Chapter> ();

        public int ManuscriptContentId { get; set; }

        [ForeignKey("ManuscriptContentId")]
        public ManuscriptContent ManuscriptContent { get; set; }
    }
}
