namespace MedLink.Api.DTOs.Post
{
    public class PostVisitDto
    {
        public int PatientId { get; set; }
        public int OperationId { get; set; }
        public int DocId { get; set; }
        public int IllnessId { get; set; }
        public string Note { get; set; }
        public string Conclusion { get; set; }
    }
}
