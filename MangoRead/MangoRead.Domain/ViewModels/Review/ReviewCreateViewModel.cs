﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.Domain.ViewModels.Review
{
    public class ReviewCreateViewModel
    {
        public int IdCouple { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; } = "Jesus Christ";

        [Range(1, 5, ErrorMessage = "Possible range: from 1 to 5.")]
        public int Rating { get; set; }
    }
}