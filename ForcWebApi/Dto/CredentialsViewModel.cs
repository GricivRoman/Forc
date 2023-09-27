namespace ForcWebApi.Dto
{
    public class CredentialsViewModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
