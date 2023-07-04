using Backend.Hubs;

namespace Backend.Classes
{
  public class OnlineUsersManager
  {
    private readonly ILogger _logger;
    private static readonly List<User> _users = new List<User>();
    private readonly object _writeLock = new object();

    public OnlineUsersManager(ILogger<OnlineUsersManager> logger)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public User Upsert(InputUser user, string connectionId)
    {
      // TODO: verify the hypotesis:
      // If a matching user ID (stored in local storage), or connectionID (provided by SignalR, I assume this can change between browser sessions)
      // Then update the user with the latest connection ID, so the subsequent disconnects and connects match.
      var userIndex = _users.FindIndex(u => u.Id == user.Id || u.ConnectionId == connectionId);
      if (userIndex != -1)
      {
        lock (_writeLock)
        {
          _users[userIndex].Connected = true;
          _users[userIndex].LastSeen = DateTime.Now;
          _users[userIndex].ConnectionId = connectionId;
        }

        return _users[userIndex];
      }

      var newUser = new User
      {
        Id = user.Id ?? Guid.NewGuid(),
        Initials = user.Initials,
        AvatarColor = user.AvatarColor,
        ConnectionId = connectionId
      };

      _logger.LogInformation($"Adding user {newUser.Initials} with connection id {newUser.ConnectionId} and color {newUser.AvatarColor}");

      lock (_writeLock)
      {
        _users.Add(newUser);
      }

      return newUser;
    }

    public void Connect(string connectionId)
    {
      var userIndex = _users.FindIndex(u => u.ConnectionId == connectionId);
      if (userIndex == -1)
      {
        return;
      }

      _logger.LogInformation($"{_users[userIndex].Initials} connected with connection id {connectionId}");

      lock (_writeLock)
      {
        _users[userIndex].Connected = true;
        _users[userIndex].LastSeen = DateTime.Now;
      }
    }

    public void Disconnect(string connectionId)
    {
      var userIndex = _users.FindIndex(u => u.ConnectionId == connectionId);
      if (userIndex == -1)
      {
        return;
      }

      _logger.LogInformation($"{_users[userIndex].Initials} disconnected with connection id {connectionId}");

      lock (_writeLock)
      {
        _users[userIndex].Connected = false;
        _users[userIndex].LastSeen = DateTime.Now;
      }
    }

    public void Update(InputUser user)
    {
      var userIndex = _users.FindIndex(u => u.Id == user.Id);
      if (userIndex == -1)
      {
        return;
      }

      lock (_writeLock)
      {
        _users[userIndex].AvatarColor = user.AvatarColor;
        _users[userIndex].Initials = user.Initials;
        _users[userIndex].LastSeen = DateTime.Now;
      }
    }

    public User GetById(Guid id)
    {
      var user = _users.Where(u => u.Id == id).FirstOrDefault();
      if (user == null)
      {
        throw new Exception("User does not exist.");
      }
      return user;
    }

    public List<User> GetUsers()
    {
      return _users.Where(u => u.Connected).ToList();
    }
  }
}