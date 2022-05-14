using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MangoRead.Domain.Models;

namespace MangoRead.Domain.ViewModels.Manuscript
{
    public class ManuscriptContentViewModel
    {
        public string FolderName { get; set; } = string.Empty;

        public IFormFile File { get; set; }

        public int ManuscriptId { get; set; }

        public MangoRead.Domain.Models.Manuscript Manuscript { get; set; } // navigational property
    }
}
