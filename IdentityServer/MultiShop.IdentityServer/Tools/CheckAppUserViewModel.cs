namespace MultiShop.IdentityServer.Tools
{
    public class CheckAppUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}