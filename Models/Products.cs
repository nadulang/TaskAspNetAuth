using System;

namespace TaskAuth.Models
{
    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }
    }
}