﻿using Skaitykla._Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skaitykla.MVC.Models
{
    public class NewBookViewModel
    {
        [Required]
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
    }
}
