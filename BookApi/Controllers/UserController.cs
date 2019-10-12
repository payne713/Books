using BookApi.Interface;
using BookApi.Request;
using BookApi.Result;
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
        public async Task<BaseResult> Post(LoginRequest loginRequest)
        {
            return await _userService.Login(loginRequest.UserName,loginRequest.Password);
        }

        [HttpGet]
        public int Get()
        {
            return 1;
        }

    }
}