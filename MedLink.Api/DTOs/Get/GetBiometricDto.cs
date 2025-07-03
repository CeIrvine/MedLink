namespace MedLink.Api.DTOs.Get
{
    public class GetBiometricDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public byte[] Fingerprint { get; set; }
        public byte[] FaceId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string BloodType { get; set; }
        public string Gender { get; set; }
    }
}
