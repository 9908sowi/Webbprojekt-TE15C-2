using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IGEN.Models
{
    public class HomeEdit
    {
        public int ID { get; set; }
        public int? FrontPicID { get; set; }
        public virtual Article FrontPic { get; set; }
        public int? CardPic1ID { get; set; }
        public virtual Article CardPic1 { get; set; }
        public int? CardPic2ID { get; set; }
        public virtual Article CardPic2 { get; set; }
        public int? CardPic3ID { get; set; }
        public virtual Article CardPic3 { get; set; }
        public int? CardPic4ID { get; set; }
        public virtual Article CardPic4 { get; set; }
        public int? CardPic5ID { get; set; }
        public virtual Article CardPic5 { get; set; }
        public int? CardPic6ID { get; set; }
        public virtual Article CardPic6 { get; set; }
    }
}