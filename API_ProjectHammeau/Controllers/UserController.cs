using API_ProjectHammeau.Moddels;
using API_ProjectHammeau.Tools;
using Labo_BLL.Interfaces;
using Labo_Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API_ProjectHammeau.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenGenerator _tokenGenerator;

        public UserController(IUserService userService, TokenGenerator tokenGenerator)
        {
            _userService = userService;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginForm loginInfo)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                User_DB connectedUser = _userService.Login(loginInfo.Email, loginInfo.Password);
                string token = _tokenGenerator.GenerateToken(connectedUser);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Register(UserRegisterForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                _userService.Register(form.Name, form.FirstName, form.Email, form.Password, form.Pseudo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("IsAdmin")]
        public IActionResult UpdateIsAdmin(int id)
        {
            try
            {
                _userService.UpdateIsAdmin(id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Authorize("isConnectedPolicy")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById()
        {
            try
            {
                string tokenFromRequest = HttpContext.Request.Headers["Authorization"];
                string tokenOk = tokenFromRequest.Substring(7, tokenFromRequest.Length - 7);
                JwtSecurityToken jwt = new JwtSecurityToken(tokenOk);
                int id = int.Parse(jwt.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
                return Ok(_userService.GetById(id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}

