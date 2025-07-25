namespace MedLink.Logic.DTOs.Push
{
    public class PutBiometricDto
    {
        public byte[]? Fingerprint { get; set; }
        public byte[]? FaceId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string BloodType { get; set; }
        public string Gender { get; set; }
    }
}
