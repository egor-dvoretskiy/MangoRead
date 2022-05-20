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

        public List<ChapterManagementViewModel> Chapters { get; set; } = new List<ChapterManagementViewModel>();

        public int ManuscriptContentId { get; set; }

        public VolumeManagementViewModel(Volume volume)
        {
            VolumeNumber = volume.VolumeNumber;
            Name = volume.Name;
            ManuscriptContentId = volume.ManuscriptContentId;

            foreach (var chapter in volume.Chapters)
            {
                Chapters.Add(new ChapterManagementViewModel(chapter));
            }
        }
    }
}
