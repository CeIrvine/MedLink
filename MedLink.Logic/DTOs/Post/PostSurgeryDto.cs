namespace MedLink.Logic.DTOs.Post
{
    public class PostSurgeryDto
    {
        public int OperationId { get; set; }
        public string? Note { get; set; }
        public int PatientId { get; set; }
        public int DocId { get; set; }
    }
}
