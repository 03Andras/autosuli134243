public class Pouzivatel
{
    public long id { get; set; }
    public string meno { get; set; } = "";
    public string email { get; set; } = "";
    public string hesloHash { get; set; } = "";
    public string hesloSalt { get; set; } = "";
}
