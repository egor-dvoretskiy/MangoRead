using MangoRead.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Models
{
    public class ManuscriptContent
    {
        public int Id { get; set; }

        public string FolderName { get; set; } = string.Empty;

        public List<Volume> Volumes { get; set; } = new List<Volume>();

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.InProgress;

        public DateTime? ApprovalDate { get; set; } = null;

        public int ManuscriptId { get; set; }

        [ForeignKey("ManuscriptId")]
        public Manuscript Manuscript { get; set; } // navigational property
    }
}
