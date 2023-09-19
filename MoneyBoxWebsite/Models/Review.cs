namespace MoneyBoxWebsite.Models
{
    public class Review
    {
        public Guid Id { get; set; }

        public required string Message { get; set; }

        public bool IsValidate { get; set; } = false;



        /*      RELATIONS       */

        public required Client Creator { get; set; }

        public required Product LinkedProduct { get; set; }
    }
}
