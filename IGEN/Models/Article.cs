using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IGEN.Models
{
    public class Article
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Header { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string BigPic { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Author { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Text { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int? GameID { get; set; }
        public virtual Game Game { get; set; }
        public virtual ICollection<HomeEdit> HomeEdits { get; set; }
        public int? Visits { get; set; }
        public bool IsLocked { get; set; }
    }
}