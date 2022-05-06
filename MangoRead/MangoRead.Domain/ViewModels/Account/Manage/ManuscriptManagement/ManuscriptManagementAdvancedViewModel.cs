using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Account.Manage
{
    public class ManuscriptManagementAdvancedViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }

        public string Publisher { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ApprovalDate { get; set; } = null;

        public ManuscriptType Type { get; set; } = ManuscriptType.Other;

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.InProgress;
    }
}
