namespace MedLink.Api.DTOs.Post
{
    public class PostSurgeryDto
    {
        public int OperationId { get; set; }
        public int Note { get; set; }
        public int PatientId { get; set; }
        public int DocId { get; set; }
    }
}
