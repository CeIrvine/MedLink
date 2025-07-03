namespace MedLink.Api.DTOs.Post
{
    public class PostOperationDto
    {
        public string Name { get; set; }
        public string DocNote { get; set; }
        public int DocId { get; set; }
        public int PatientId { get; set; }
    }
}
