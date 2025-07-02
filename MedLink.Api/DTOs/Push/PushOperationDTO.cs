namespace MedLink.Api.DTOs.Push
{
    public class PushOperationDto
    {
        public string Name { get; set; }
        public string DocNote { get; set; }
        public int DocId { get; set; }
        public int PatientId { get; set; }
    }
}
