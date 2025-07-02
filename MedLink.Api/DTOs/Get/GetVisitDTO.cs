namespace MedLink.Api.DTOs.Get
{
    public class GetVisitDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int OperationId { get; set; }
        public int DocId { get; set; }
        public int IllnessId { get; set; }
        public string Note { get; set; }
        public string Conclusion { get; set; }
    }
}
