﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IGEN.Models
{
    public class Game
    {
        /*Basic game info class used in article pages (on the right hand side of article text). ICollection used to connect games to articles.*/
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string CoverArt { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Developer { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}