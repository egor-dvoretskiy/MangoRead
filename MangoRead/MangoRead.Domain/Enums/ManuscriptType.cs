using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.Enums
{
    public enum ManuscriptType
    {
        [Display(Name = "")]
        Other,

        [Display(Name = "Comix")]
        Comix,

        [Display(Name = "Manga")]
        Manga,

        [Display(Name = "Manhwa")]
        Manhwa,

        [Display(Name = "Manhua")]
        Manhua,

        [Display(Name = "Webtoon")]
        Webtoon,

        [Display(Name = "One-shot")]
        Oneshot,
    }
}
