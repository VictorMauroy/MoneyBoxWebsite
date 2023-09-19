namespace MoneyBoxWebsite.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        
        public required string Name { get; set; }


        /*      RELATIONS       */

        public List<Client> Users { get; set; } = new List<Client>();
    }
}
