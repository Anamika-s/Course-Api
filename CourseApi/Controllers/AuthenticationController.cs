using CourseApi.Context;
using CourseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        AppDbContext _context;
        IConfiguration _configuration;
        public AuthenticationController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
         IActionResult response = Unauthorized();
         User obj = FindUser(user);
            if(obj!=null)
            {
                var tokenString =  GenerateWebToken(obj);
                response = Ok(new { token = tokenString });
            }
         return response;

        }

        string GenerateWebToken(User user)
        {
            string role = GetRoleName(user.RoleId);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, role.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, "JWT");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            foreach (var temp in _context.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, temp.RoleName)); ;
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"],
                Expires = DateTime.Now.AddMinutes(120),
                Subject = claimsPrincipal.Identity as ClaimsIdentity,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;


        }

        string GetRoleName(int roleId)
        {
            string roleName = (from x in _context.Roles
                               where x.RoleId == roleId
                               select x.RoleName
                                ).FirstOrDefault();
            return roleName;
        }
        User  FindUser(User user)
        {
            return _context.Users.FirstOrDefault(x=>x.UserName==user.UserName && x.Password==user.Password);    
        }
    }
}
