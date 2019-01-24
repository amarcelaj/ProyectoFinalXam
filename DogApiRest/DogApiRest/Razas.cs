using System;
using System.Collections.Generic;
using System.Text;

namespace DogApiRest
{
    public class Razas
    {
        public int id { get; set; }
        public string brand { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string price_sign { get; set; }
        public string currency { get; set; }
        public string image_link { get; set; }
        public string product_link { get; set; }
        public string website_link { get; set; }
        public string description { get; set; }
        public double? rating { get; set; }
        public string category { get; set; }
        public string product_type { get; set; }
        public List<object> tag_list { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string product_api_url { get; set; }
        public string api_featured_image { get; set; }
        public List<object> product_colors { get; set; }
    }
}
