namespace TaskAuth.Models
{
    public class CustomersData
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public long created_at { get; set; }
        public long update_at { get; set; }
    }
}