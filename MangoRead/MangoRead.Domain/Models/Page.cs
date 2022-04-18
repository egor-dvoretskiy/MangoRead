using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Models
{
    public class Page
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Extension { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public int ManuscriptContentId { get; set; }

        public ManuscriptContent Content { get; set; }
    }
}
