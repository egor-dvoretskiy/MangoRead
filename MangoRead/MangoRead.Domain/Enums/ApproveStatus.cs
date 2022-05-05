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
        /// Not seen by admins.
        /// </summary>
        [Display(Name = "")]
        None,

        /// <summary>
        /// Everything is good, manuscript has its confirmation.
        /// </summary>
        [Display(Name = "Approved")]
        Approved,

        /// <summary>
        /// The request still processing.
        /// </summary>
        [Display(Name = "In progress")]
        InProgress,

        /// <summary>
        /// Unfortunately, the request has been rejected.
        /// </summary>
        [Display(Name = "Rejected")]
        Rejected
    }
}
