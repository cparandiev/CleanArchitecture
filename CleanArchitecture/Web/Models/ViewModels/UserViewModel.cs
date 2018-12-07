namespace Web.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public RoleViewModel Role { get; set; }
    }
}
