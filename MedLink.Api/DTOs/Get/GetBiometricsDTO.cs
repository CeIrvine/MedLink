namespace MedLink.Api.DTOs.Get
{
    public class GetBiometricsDTO
    {
        public byte[] Fingerprint { get; set; }
        public byte[] FaceId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string BloodType { get; set; }
    }
}
