using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Home
{
    public class IndexReviewViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime UpdateDate { get; set; }

        public string UserName { get; set; }

        public int Rating { get; set; }
    }
}
