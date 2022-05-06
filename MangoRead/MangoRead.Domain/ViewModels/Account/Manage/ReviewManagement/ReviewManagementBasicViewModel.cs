using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MangoRead.Domain.ViewModels.Account.Manage.ReviewManagement
{
    public class ReviewManagementBasicViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime UpdateDate { get; set; }

        [Range(1, 5, ErrorMessage = "Possible range: from 1 to 5.")]
        public int Rating { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.InProgress;
    }
}
