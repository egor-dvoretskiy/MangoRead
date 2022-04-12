using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Entities
{
    public class ManuscriptContent
    {
        public int Id { get; set; }

        /*public string ManuscriptTitle { get; set; } = string.Empty;*/

        public string FolderName { get; set; } = string.Empty;

        public List<Page> Pages { get; set; } = new List<Page>();

        public int PagesAmount { get; set; }

        public int ManuscriptId { get; set; }

        [ForeignKey("ManuscriptId")]
        public Manuscript Manuscript { get; set; } // navigational property
    }
}
