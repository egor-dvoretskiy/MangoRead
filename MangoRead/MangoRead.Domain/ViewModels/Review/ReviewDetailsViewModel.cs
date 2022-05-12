using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Review
{
    public class ReviewDetailsViewModel
    {
        public int Id { get; set; }

        public int ManuscriptId { get; set; }

        public string Content { get; set; }

        public DateTime UploadDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string UserName { get; set; }

        [Range(1, 5, ErrorMessage = "Possible range: from 1 to 5.")]
        public int Rating { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ApprovalDate { get; set; } = null;

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.InProgress;
    }
}
