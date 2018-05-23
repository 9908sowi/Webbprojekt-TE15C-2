using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IGEN.Models
{
    public class Article
    {
        /*All info required for articles.*/
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
        /*Counts how many visits the specific page gets.*/
        public int? Visits { get; set; }
        /*Property to choose if the article should be available to subscribers only or not.*/
        public bool IsLocked { get; set; }
    }
}