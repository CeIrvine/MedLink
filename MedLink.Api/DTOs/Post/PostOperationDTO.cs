namespace MedLink.Api.DTOs.Post
{
    public class PostOperationDTO
    {
        public string OperationName { get; set; }
        public string DocNote { get; set; }
        public int DocId { get; set; }
        public int PatientId { get; set; }
    }
}
