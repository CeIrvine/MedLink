namespace MedLink.Logic.DTOs.Post
{
    public class PostBiometricDto
    {
        public int PatientId { get; set; }
        public byte[]? Fingerprint { get; set; }
        public byte[]? FaceId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string BloodType { get; set; }
        public string Gender { get; set; }
    }
}
