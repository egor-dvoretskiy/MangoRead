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

        public List<PageManagementViewModel> Pages { get; set; } = new List<PageManagementViewModel>();

        public int AmountOfRequestedPages { get; set; }

        public int VolumeId { get; set; }

        public ChapterManagementViewModel(Chapter chapter)
        {
            ChapterNumber = chapter.ChapterNumber;
            Name = chapter.Name;
            VolumeId = chapter.VolumeId;

            foreach(var page in chapter.Pages)
            {
                Pages.Add(new PageManagementViewModel(page));
            }

            AmountOfRequestedPages = chapter.Pages.Count;
        }
    }
}
