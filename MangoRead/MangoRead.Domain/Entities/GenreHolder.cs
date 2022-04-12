using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Entities
{
    public class GenreHolder
    {
        public int Id { get; set; }

        public ManuscriptType Genre { get; set; }

        public int ManuscriptId { get; set; }

        public Manuscript Manuscript { get; set; }
    }
}
