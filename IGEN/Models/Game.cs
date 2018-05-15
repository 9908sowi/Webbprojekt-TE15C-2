using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IGEN.Models
{
    public class Game
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string CoverArt { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Developer { get; set; }
    }
}