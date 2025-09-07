namespace Product.Models
{
    public class InMemoryUser
    {
        public string UserName { get; set; }
        public string Password { get; set; } // plain text only for demo
        public string Role { get; set; }
    }

    public static class UserStore
    {
        public static List<InMemoryUser> Users = new List<InMemoryUser>
    {
        new InMemoryUser { UserName = "admin", Password = "Admin@123", Role = "Admin" },
        new InMemoryUser { UserName = "manager1", Password = "Manager@123", Role = "Manager" }
    };
    }

}
