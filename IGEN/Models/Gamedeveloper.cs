using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IGEN.Models
{
    public class Gamedeveloper
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is Required.")]
        public string Name { get; set; }
        public  string Logo { get; set; }

    }
}