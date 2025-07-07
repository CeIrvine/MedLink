namespace MedLink.Api.DTOs.Get
{
    public class GetSurgeryDto
    {
        public int Id { get; set; }
        public int OperationId { get; set; }
        public int PatientId { get; set; }
        public int DocId { get; set; }
        public string Note { get; set; }
    }
}
