using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogicalLayer.IServices;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;
using WebPresentationLayer.Services;

namespace WebPresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User user)
        {
            DataResponse<User> dataResponseUserToLogin = await _service.Authetication(user.Login.Email, user.Login.Password);

            if (!dataResponseUserToLogin.Success)
            {
                return new { message = dataResponseUserToLogin.Erros };
            }

            if (dataResponseUserToLogin.Data[0] == null)
            {
                return NotFound(new { message = "Email ou senha incorreto" });
            }

            string token = TokenService.GenerateToken(dataResponseUserToLogin.Data[0]);
            return new
            {
                user = dataResponseUserToLogin,
                token = token
            };
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<ActionResult<dynamic>> Register([FromBody]User user)
        {
            return null;
        }
    }
}