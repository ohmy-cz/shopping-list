using Backend.Classes;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs
{
  public class OnlineUsersHub : Hub<IClient>
  {
    private readonly OnlineUsersManager _onlineUsersManager;
    private readonly ILogger<OnlineUsersHub> _logger;

    public OnlineUsersHub(OnlineUsersManager onlineUsersManager, ILogger<OnlineUsersHub> logger) : base()
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      _onlineUsersManager = onlineUsersManager ?? throw new ArgumentNullException(nameof(onlineUsersManager));
    }

    public async Task Connect(InputUser user)
    {
      var newUser = _onlineUsersManager.Upsert(user, Context.ConnectionId);
      await Clients.All.UsersOnline(_onlineUsersManager.GetUsers());
      await Clients.Caller.User(newUser);
    }

    public async Task UpdateUser(InputUser user)
    {
      if (user.Id == null)
      {
        throw new Exception("No user id provided.");
      }

      _onlineUsersManager.Update(user);

      await Clients.All.UsersOnline(_onlineUsersManager.GetUsers());
      await Clients.Caller.User(_onlineUsersManager.GetById((Guid)user.Id));
    }

    public override Task OnConnectedAsync()
    {
      _onlineUsersManager.Connect(Context.ConnectionId);
      Clients.All.UsersOnline(_onlineUsersManager.GetUsers());
      return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
      _onlineUsersManager.Disconnect(Context.ConnectionId);
      Clients.All.UsersOnline(_onlineUsersManager.GetUsers());
      return base.OnDisconnectedAsync(exception);
    }
  }
}