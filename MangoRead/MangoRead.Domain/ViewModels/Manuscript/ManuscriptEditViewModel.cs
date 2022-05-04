using MangoRead.Domain.Enums;
using MangoRead.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Manuscript
{
    public class ManuscriptEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public byte[] TitleImage { get; set; }

        public IFormFile TitlePicture { get; set; }

        public string Author { get; set; } = string.Empty;

        [Required]
        public string Publisher { get; set; } = string.Empty;

        public string Translator { get; set; } = string.Empty;

        public string OriginCountry { get; set; } = string.Empty;

        [Required]
        public ManuscriptType Type { get; set; } = ManuscriptType.Other;

        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public bool IsRequireLegalAge { get; set; } = false;

        public Genre[]? Genres { get; set; }

        public IEnumerable<SelectListItem>? GenresList { get; set; }

        public ManuscriptContent? Content { get; set; }
    }
}
