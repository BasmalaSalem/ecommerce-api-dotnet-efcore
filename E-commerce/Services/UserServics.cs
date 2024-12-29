namespace E_commerce.Services;
using E_commerce.Contracts;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public User AddUser(User user)
    {
        try
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while adding a new user.", e);
        }
    }

    public List<User> GetAllUsers()
    {
        try
        {
            return _context.Users.ToList();
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while retrieving all users.", e);
        }
    }

    public User UpdateUser(User user)
    {
        try
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while updating user information.", e);
        }
    }
    public User DeleteUser(int userId)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new ApplicationException($"User with ID {userId} not found.");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while deleting user.", e);
        }
    }
    
}