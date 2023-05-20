namespace Split.Engine.Models
{
    public record User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
    }
}
