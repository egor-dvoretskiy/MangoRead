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

        public List<VolumeManagementViewModel> Volumes { get; set; } = new List<VolumeManagementViewModel>();

        public int AmountOfRequestedVolumes { get; set; }

        public int AmountOfRequestedChapters { get; set; }

        public int AmountOfRequestedPages { get; set; }

        public int ManuscriptId { get; set; }

        public ContentManagementViewModel(ManuscriptContent content)
        {
            FolderName = content.FolderName;
            ManuscriptId = content.ManuscriptId;

            foreach(var volume in content.Volumes)
            {
                Volumes.Add(new VolumeManagementViewModel(volume));
            }

            AmountOfRequestedVolumes = content.Volumes.Count;
            AmountOfRequestedChapters = content.Volumes.Sum(x => x.Chapters.Count);
            AmountOfRequestedPages = content.Volumes.Sum(x => x.Chapters.Sum(y => y.Pages.Count));
        }
    }
}
