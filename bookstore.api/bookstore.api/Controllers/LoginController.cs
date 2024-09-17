using bookstore.api.Models;
using bookstore.api.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace bookstore.api.Controllers
{
	[Controller]
	[Route("/api/[controller]")]
	public class LoginController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly DatabaseContext _databaseContext;

		public LoginController(IConfiguration configuration, DatabaseContext databaseContext)
		{
			_configuration = configuration;
			_databaseContext = databaseContext;
		}

		[HttpPost]
		public IActionResult Login([FromBody] UserLogin userLogin)
		{
			var user = _databaseContext.Users.FirstOrDefault(u => u.Email == userLogin.Email && u.Password == userLogin.Password);
			
			if(user != null)
			{
				var token = GenerateJwtToken(user.Email, user.Role);
				return Ok(new { token });
			}

			return Unauthorized();
		}


		private string GenerateJwtToken(string username, string role)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, username),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.Role, role)
			};

			var token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(2),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
