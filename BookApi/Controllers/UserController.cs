using BookApi.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<bool> Post(string username,string passsword)
        {
            return await _userService.Login(username,passsword);
        }

        [HttpGet]
        public int Get()
        {
            return 1;
        }

    }
}