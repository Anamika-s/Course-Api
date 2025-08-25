using CourseApi.Context;
using CourseApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
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
            string Msg = "Hi ! This is DailyMailSchedulerService mail.";//whatever msg u want to send write here.  
                                                                        // Here you can write the   


 


            SendEmail("anamika.sawhney22@gmail.com", "shrutikumari7644@gmail.com", "a@live.com", "Daily Report of DailyMailSchedulerService on " + DateTime.Now.ToString("dd-MMM-yyyy"), Msg);


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


        public   void SendEmail(String ToEmail, string cc, string bcc, String Subj, string Message)
        {
            //Reading sender Email credential from web.config file  

            string HostAdd = _configuration["Mail:Host"];
            string FromEmailid = _configuration["Mail:From"];
            string Pass = _configuration["Mail:Password"].ToString();
            //creating the object of MailMessage  

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmailid); //From Email Id  
            mailMessage.Subject = Subj; //Subject of Email  
            mailMessage.Body = Message; //body or message of Email  
            //mailMessage.IsBodyHtml = true;

            //string[] ToMuliId = ToEmail.Split(',');
            //foreach (string ToEMailId in ToMuliId)
            //{
            //    mailMessage.To.Add(new MailAddress(ToEMailId)); //adding multiple TO Email Id  
            //}


            string[] CCId = cc.Split(',');

            foreach (string CCEmail in CCId)
            {
                mailMessage.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id  
            }

            //string[] bccid = bcc.Split(',');

            //foreach (string bccEmailId in bccid)
            //{
            //    mailMessage.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id  
            //}
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;// creating object of smptpclient  
            smtp.Host = HostAdd;              //host of emailaddress for example smtp.gmail.com etc  

            //network and security related credentials  

            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = mailMessage.From.Address;
            //            Console.WriteLine(NetworkCred.UserName);
            NetworkCred.Password = "zbtl yioc ulnp dued";
            //          smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
           
            smtp.Send(mailMessage); //sending Email  
        }

    }
}
