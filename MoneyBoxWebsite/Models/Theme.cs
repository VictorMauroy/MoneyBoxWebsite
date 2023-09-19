namespace MoneyBoxWebsite.Models
{
    public class Theme
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }


        /*      RELATIONS       */

        public List<Client> ThemeClients { get; set; } = new List<Client>();
    }
}
