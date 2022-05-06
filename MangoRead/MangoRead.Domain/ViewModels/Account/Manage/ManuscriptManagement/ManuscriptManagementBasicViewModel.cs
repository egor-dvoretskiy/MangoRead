using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Account.Manage
{
    public class ManuscriptManagementBasicViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ApprovingDate { get; set; } = null;

        public ManuscriptType Type { get; set; } = ManuscriptType.Other;

        public ApprovalStatus IsApproved { get; set; } = ApprovalStatus.InProgress;
    }
}
