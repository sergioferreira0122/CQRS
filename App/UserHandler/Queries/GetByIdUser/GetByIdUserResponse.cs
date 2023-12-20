namespace App.UserHandler.Queries.GetByIdUser
{
    public class GetByIdUserResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public DateOnly BirthdayDate { get; set; }
    }
}
