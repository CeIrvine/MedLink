namespace MedLink.Api.DTOs.Get
{
    public class GetPatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Note { get; set; }
        public string MedHistory { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
