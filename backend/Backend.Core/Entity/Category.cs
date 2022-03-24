using backend.Entity;
using System;
using System.Collections.Generic;

namespace backend.Models
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Img_Url { get; set; }
        public DateTime Created_Date { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
