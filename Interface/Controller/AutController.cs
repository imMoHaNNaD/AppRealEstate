using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Interface.Message;
using Interface.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Interface.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutController : ControllerBase
    {
        private readonly AutService _service;

        private readonly IMapper _mapper;
        public AutController(IMapper mapper)
        {
            _service = new AutService(mapper);
            _mapper = mapper;
        }
      
        [HttpPost("Login")]
        public BaseResponse<string> Login(string user, string password)
        {
            return _service.Login(user,password);
        }

        [HttpPost("ValadtionToken")]
        public BaseResponse<bool> ValadtionToken(string token)
        {
            return _service.ValadtionToken(token);
        }

       
    }
}
