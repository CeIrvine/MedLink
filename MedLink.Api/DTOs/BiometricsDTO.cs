namespace MedLink.Api.DTOs
{
    public class BiometricsDTO
    {
        public byte[] Fingerprint { get; set; }
        public byte[] FaceId { get; set; }
    }
}
