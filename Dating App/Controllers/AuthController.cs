using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dating_App.Data;
using Dating_App.DTOs;
using Dating_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Dating_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegistrationDTO userToRegisterDTO)
        {
            //Validate Request
            if (await _repo.UserExists(userToRegisterDTO.Username))
                ModelState.AddModelError("Username", "Username is already taken"); 

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            userToRegisterDTO.Username = userToRegisterDTO.Username.ToLower();
             
            var userToCreate = new User
            {
                Username = userToRegisterDTO.Username
            };

            var createdUser = await _repo.Register(userToCreate, userToRegisterDTO.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDTO userForLoginDTO)
        {
            var userFromRepo = await _repo.Login(userForLoginDTO.Username, userForLoginDTO.Password);

            if(userFromRepo == null)
              return Unauthorized();

            //generate Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Super Secrete Key");
            var tokenDescription = new SecurityTokenDescriptor { //Payload
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name , userFromRepo.Username)
                }) ,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
            
        }
        

        
    }
}
