namespace Relationships
{
    public class Adress
    {
        public int Id { get; set; }
        public string FullAdress { get; set; }
        public User User { get; set; } // navigation property
        public int UserId { get; set; }
    }
}