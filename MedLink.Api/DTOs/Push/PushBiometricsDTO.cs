namespace MedLink.Api.DTOs.Push
{
    public class PushBiometricsDto
    {
        public byte[] Fingerprint { get; set; }
        public byte[] FaceId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string BloodType { get; set; }   
    }
}
