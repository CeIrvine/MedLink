namespace medLinkMaui.Model;

public class Patient
{
    public int Id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public DateTime lastModified { get; set; }
    public DateTime createdAt {  get; set; }
    public string patientNote { get; set; }
}
