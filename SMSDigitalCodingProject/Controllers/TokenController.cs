using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SMSDigitalCodingProject.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SMSDigitalCodingProject.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;

        public TokenController(ILogger<CityController> logger, IConfiguration config, DatabaseContext context)
        {
            _logger = logger;
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserInfo _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                //This function will provide username and email exists then proceed to ceate token
                var user = GetUser(_userData.Email, _userData.Password).Result;

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.DisplayName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    _logger.LogInformation("Token Generated");
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    string msg = "Invalid credentials";
                    _logger.LogInformation(msg);
                    return BadRequest(msg);
                }
            }
            else
            {
                _logger.LogInformation("User credentials not provided");
                return BadRequest();
            }
        }

        private async Task<UserInfo> GetUser(string email, string password)
        {
            if(email == "abhishek.sahu@xebia.com" &&  password == "secret")
            {
                return await Task.FromResult(new UserInfo() { UserId = 1, DisplayName = "abhishek", UserName = "abhishek", Email = "abhishek.sahu@xebia.com" });
            }
            return null;
        }
    }
}
