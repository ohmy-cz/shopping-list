namespace Backend.Hubs
{
  public class User
  {
    public Guid Id { get; set; }
    public bool Connected { get; set; } = true;
    public string? ConnectionId { get; set; }
    public string? Initials { get; set; }
    public string? AvatarColor { get; set; }
    public DateTime LastSeen { get; set; } = DateTime.Now;
  }
}