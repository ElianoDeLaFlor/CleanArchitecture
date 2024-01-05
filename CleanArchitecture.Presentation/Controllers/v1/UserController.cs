using Asp.Versioning;
using CleanArchitecture.Application.Features;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Presentation.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtService _jwtService;

        public UserController(UserManager<IdentityUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        // GET: api/<UserController>
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<IdentityUser>> response = new ();
            var users= await _userManager.Users.ToListAsync();

            response.Success = true;
            response.Data = users;
            response.Message = users.Count>0?  "Users retrieved successfully!": "There is no user in the database!";

            return Ok(response);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            ServiceResponse<IdentityUser> response = new();
            
            var user= await _userManager.FindByIdAsync(id);
            
            response.Success = true;
            response.Data = user;
            response.Message = "User retrieved successfully!";

            return Ok(response);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(IdentityUser user)
        {
            ServiceResponse<IdentityUser> response=new();
            if(!ModelState.IsValid)
            {
                response.Success = false;
                response.Data = null;
                response.Message = "Error occured";

                return BadRequest(response);
            }
            var result=await _userManager.CreateAsync(user,user.PasswordHash);
            
            if(result.Succeeded) {
                response.Success = true;
                response.Data = user;
                response.Message = "User create successfully";
                return Ok(response);
            }
            else
            {
                response.Success = false;
                response.Data = null;
                var sb=new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.Append($"|{error.Description}");
                }

                response.Message = sb.ToString();

                return BadRequest(response);
            }

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(string id, IdentityUser user)
        {
        }
        
        // POST api/<UserController>/5
        [HttpPost("Token")]
        public async Task<IActionResult> CreateToken(LoginModel login)
        {
            ServiceResponse<LoginResponse> response = new();
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user,login.Password);
                if (result)
                {
                    response.Success = true;
                    response.Data = _jwtService.CreateToken(user);
                    response.Message = "Operation complete successfully";
                    return Ok(response);
                }
                else
                {
                    response.Success = false;
                    response.Data = null;
                    response.Message = "Incorrect credentials";

                    return BadRequest(response);
                }
            }
            else
            {
                response.Success = false;
                response.Data = null;
                response.Message = "Incorrect credentials";

                return BadRequest(response);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            ServiceResponse<IdentityUser> response = new();

            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                var result= await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    response.Success = true;
                    response.Data = user;
                    response.Message = "User delete successfully";
                    return Ok(response);
                }
                else
                {
                    response.Success = false;
                    response.Data = null;
                    var sb = new StringBuilder();
                    foreach (var error in result.Errors)
                    {
                        sb.Append($"|{error.Description}");
                    }

                    response.Message = sb.ToString();

                    return BadRequest(response);
                }
            }
            else
            {
                response.Success = false;
                response.Data = null;
                response.Message = "User not found!";

                return Ok(response);
            }
            
        }
    }
}
