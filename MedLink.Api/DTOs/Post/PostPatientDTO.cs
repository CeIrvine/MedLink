namespace MedLink.Api.DTOs.Post
{
    public class PostPatientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Note { get; set; }
        public string MedHistory { get; set; }
    }
}
