using MangoRead.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Account.Manage.ContentManagement
{
    public class ContentManagementViewModel
    {
        public string FolderName { get; set; } = string.Empty;

        public List<Volume> Volumes { get; set; } = new List<Volume>();

        public int ManuscriptId { get; set; }
    }
}
