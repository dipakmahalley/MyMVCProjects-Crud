using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcDemo4_Crud.Models
{
    public class product
    {
        [Display(Name = "Product Id")]
        public int product_id { get; set; }
        [Display(Name = "Category Id")]
        public int category_id { get; set; }
        [Display(Name = "Product Name")]
        public string product_name { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Video URL")]
        public string video_url { get; set; }
        [Display(Name = "Price")]
        public int price { get; set; }
        [Display(Name = "Product Posted Date")]
        public string product_posted_date { get; set; }
        [Display(Name = "Product Image URL")]
        public string product_image { get; set; }

    }
}