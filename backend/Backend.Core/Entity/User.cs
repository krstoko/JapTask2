namespace backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public byte[] Password_Has { get; set; }

        public byte[] Password_Salt { get; set; }

    }
}
