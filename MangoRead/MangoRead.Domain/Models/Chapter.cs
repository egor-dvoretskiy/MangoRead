using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Models
{
    public class Chapter
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Page> Pages { get; set; } = new List<Page>();

        public int VolumeId { get; set; }

        [ForeignKey("VolumeId")]
        public Volume Volume { get; set; }
    }
}
