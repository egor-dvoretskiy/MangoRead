using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Enums
{
    public enum ApproveStatus
    {
        /// <summary>
        /// The request still processing.
        /// </summary>
        [Display(Name = "In progress")]
        InProgress,

        /// <summary>
        /// Everything is good, manuscript has its confirmation.
        /// </summary>
        [Display(Name = "Approved")]
        Approved,

        /// <summary>
        /// Unfortunately, the request has been rejected.
        /// </summary>
        [Display(Name = "Rejected")]
        Rejected
    }
}
