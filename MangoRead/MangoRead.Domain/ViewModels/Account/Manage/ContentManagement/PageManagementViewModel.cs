﻿using MangoRead.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Account.Manage.ContentManagement
{
    public class PageManagementViewModel
    {
        public int PageNumber { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Extension { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public int ChapterId { get; set; }

        public PageManagementViewModel(Page page)
        {
            PageNumber = page.PageNumber;
            Name = page.Name;
            Extension = page.Extension;
            Path = page.Path;
            ChapterId = page.ChapterId;
        }
    }
}