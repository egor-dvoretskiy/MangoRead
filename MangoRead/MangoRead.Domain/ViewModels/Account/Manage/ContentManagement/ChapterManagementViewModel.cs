using MangoRead.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Account.Manage.ContentManagement
{
    public class ChapterManagementViewModel
    {
        public int ChapterNumber { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Page> Pages { get; set; } = new List<Page>();

        public int VolumeId { get; set; }
    }
}
