using Backend.Hubs;

public interface IClient
{
  Task UsersOnline(IList<User> users);
  Task User(User user);
}