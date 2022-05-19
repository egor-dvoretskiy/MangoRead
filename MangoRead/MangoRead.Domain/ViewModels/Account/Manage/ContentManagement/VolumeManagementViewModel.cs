using MangoRead.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Account.Manage.ContentManagement
{
    public class VolumeManagementViewModel
    {
        public int VolumeNumber { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Chapter> Chapters { get; set; } = new List<Chapter>();

        public int ManuscriptContentId { get; set; }
    }
}
