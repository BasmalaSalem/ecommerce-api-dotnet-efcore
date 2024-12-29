using Microsoft.AspNetCore.Mvc;
using E_commerce.Contracts;
namespace E_commerce.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public IActionResult GetAllUsers(){
        var users = _userService.GetAllUsers();
        return Ok(users);
    }
    
    [HttpPost]
    public IActionResult AddUser(User user){
        var addedUser = _userService.AddUser(user);
        return Ok(addedUser);
    }

}