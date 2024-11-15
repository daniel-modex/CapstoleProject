﻿using authApiNew.models;
using authApiNew.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace authApiNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public AuthApiController(IRegisterService registerService)
        {
            _registerService = registerService;
        }



        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterRequestDto register)
        {
            var result = await _registerService.RegisterUser(register);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var result = await _registerService.Login(loginRequest);
            return Ok(result);
        }
        
    }
}
